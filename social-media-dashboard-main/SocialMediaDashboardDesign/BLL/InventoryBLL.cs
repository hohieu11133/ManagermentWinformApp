using SocialMediaDashboardDesign.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SocialMediaDashboardDesign.BusinessLogic
{
    /// <summary>
    /// Lớp Business Logic xử lý các nghiệp vụ liên quan đến Nguyên vật liệu.
    /// </summary>
    public class InventoryBLL
    {
        private readonly InventoryDAL inventoryDAL;

        public InventoryBLL()
        {
            inventoryDAL = new InventoryDAL();
        }

        public DataRow GetIngredientDetails(int id)
        {
            return inventoryDAL.GetIngredientById(id);
        }

        /// <summary>
        /// Xử lý dữ liệu nhập hàng loạt (Excel/CSV) và thêm hoặc cập nhật vào cơ sở dữ liệu.
        /// </summary>
        public string ProcessAndAddBulkIngredients(DataTable importedData)
        {
            DataTable unitTable = GetUnits();
            int successCount = 0;
            int errorCount = 0;
            StringBuilder log = new StringBuilder();

            if (!importedData.Columns.Contains("Name") || !importedData.Columns.Contains("Unit"))
                return "LỖI CẤU TRÚC: File Excel phải có cột 'Name' và 'Unit'. Quá trình bị hủy.";

            foreach (DataRow row in importedData.Rows)
            {
                string ingredientName = "";

                try
                {
                    ingredientName = row["Name"].ToString().Trim();
                    string unitName = row["Unit"].ToString().Trim();

                    decimal stock = row["CurrentStock"] != DBNull.Value ? Convert.ToDecimal(row["CurrentStock"], CultureInfo.InvariantCulture) : 0m;
                    decimal cost = row["CostPerUnit"] != DBNull.Value ? Convert.ToDecimal(row["CostPerUnit"], CultureInfo.InvariantCulture) : 0m;

                    decimal? minStockLevel = row["MinStockLevel"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["MinStockLevel"].ToString())
                        ? (decimal?)Convert.ToDecimal(row["MinStockLevel"], CultureInfo.InvariantCulture)
                        : null;

                    if (string.IsNullOrWhiteSpace(ingredientName) || string.IsNullOrWhiteSpace(unitName) || cost <= 0)
                    {
                        log.AppendLine($"LỖI: Dòng [{errorCount + successCount + 1}] - Thiếu dữ liệu hoặc giá trị không hợp lệ.");
                        errorCount++;
                        continue;
                    }

                    DataRow unitRow = unitTable.AsEnumerable()
                        .FirstOrDefault(r => r.Field<string>("Name").Equals(unitName, StringComparison.OrdinalIgnoreCase));

                    if (unitRow == null)
                    {
                        log.AppendLine($"LỖI: Dòng [{errorCount + successCount + 1}] - Không tìm thấy đơn vị '{unitName}'.");
                        errorCount++;
                        continue;
                    }

                    int unitId = unitRow.Field<int>("UnitID");
                    DataRow existingIngredient = inventoryDAL.GetIngredientByName(ingredientName);

                    if (existingIngredient != null)
                    {
                        decimal existingStock = existingIngredient.Field<decimal>("CurrentStock");
                        int existingId = existingIngredient.Field<int>("IngredientID");
                        decimal newStock = existingStock + stock;

                        if (inventoryDAL.UpdateIngredientDetails(existingId, newStock, cost, minStockLevel))
                        {
                            log.AppendLine($"CẬP NHẬT: '{ingredientName}' - Tồn mới: {newStock:N2}.");
                            successCount++;
                        }
                        else
                        {
                            log.AppendLine($"LỖI DB: Cập nhật '{ingredientName}' thất bại.");
                            errorCount++;
                        }
                    }
                    else
                    {
                        if (inventoryDAL.AddIngredient(ingredientName, unitId, stock, cost, minStockLevel.GetValueOrDefault(0)))
                        {
                            log.AppendLine($"THÊM MỚI: '{ingredientName}' - Tồn kho: {stock:N2}.");
                            successCount++;
                        }
                        else
                        {
                            log.AppendLine($"LỖI DB: Thêm mới '{ingredientName}' thất bại.");
                            errorCount++;
                        }
                    }
                }
                catch (FormatException)
                {
                    log.AppendLine($"LỖI: Dòng [{errorCount + successCount + 1}] - Định dạng số không hợp lệ.");
                    errorCount++;
                }
                catch (Exception ex)
                {
                    log.AppendLine($"LỖI: Xử lý '{ingredientName}' thất bại. Chi tiết: {ex.Message}");
                    errorCount++;
                }
            }

            return $"--- KẾT QUẢ IMPORT ---\nThành công: {successCount}\nLỗi: {errorCount}\n\nLOG:\n{log}";
        }

        /// <summary>
        /// Xóa nguyên vật liệu sau khi kiểm tra ràng buộc sử dụng.
        /// </summary>
        public string DeleteIngredient(int ingredientId)
        {
            if (inventoryDAL.IsIngredientUsedInRecipe(ingredientId))
                return "LỖI: Nguyên vật liệu đang được sử dụng trong công thức.";

            return inventoryDAL.DeleteIngredientById(ingredientId)
                ? "SUCCESS"
                : "LỖI: Không thể xóa. Nguyên vật liệu không tồn tại hoặc lỗi DB.";
        }

        public DataTable GetIngredientsWithUnits()
        {
            return inventoryDAL.GetIngredientsWithUnits();
        }

        public DataTable LoadInventoryData()
        {
            return inventoryDAL.GetIngredientsWithUnits();
        }

        public DataTable GetUnits()
        {
            return inventoryDAL.GetUnits();
        }

        public bool AddIngredient(string name, int unitId, decimal stock, decimal cost, decimal minStock)
        {
            return inventoryDAL.AddIngredient(name, unitId, stock, cost, minStock);
        }

        /// <summary>
        /// Trừ kho nguyên vật liệu sau khi đơn hàng hoàn thành.
        /// </summary>
        public bool DeductStockForCompletedOrder(int orderId)
        {
            DataTable dtIngredients = inventoryDAL.GetIngredientsToDeduct(orderId);
            if (dtIngredients == null || dtIngredients.Rows.Count == 0) return true;

            var deductionSummary = new Dictionary<int, decimal>();

            foreach (DataRow row in dtIngredients.Rows)
            {
                int ingredientId = (int)row["IngredientID"];
                decimal quantityUsed = (decimal)row["QuantityUsed"];
                int orderQuantity = (int)row["OrderQuantity"];

                decimal totalDeduction = quantityUsed * orderQuantity;

                if (deductionSummary.ContainsKey(ingredientId))
                    deductionSummary[ingredientId] += totalDeduction;
                else
                    deductionSummary.Add(ingredientId, totalDeduction);
            }

            bool success = true;
            foreach (var item in deductionSummary)
            {
                decimal deductAmount = -item.Value;
                if (!inventoryDAL.UpdateIngredientStock(item.Key, deductAmount))
                    success = false;
            }

            return success;
        }
    }
}
