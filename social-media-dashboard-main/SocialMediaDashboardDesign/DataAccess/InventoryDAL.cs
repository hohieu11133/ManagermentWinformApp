using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SocialMediaDashboardDesign.DataAccess
{
    /// <summary>
    /// Lớp Data Access Layer (DAL) để xử lý các hoạt động cơ sở dữ liệu liên quan đến Nguyên vật liệu (Inventory/Ingredients).
    /// </summary>
    public class InventoryDAL
    {
        #region Fields

        private readonly string connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo một instance mới của lớp InventoryDAL.
        /// </summary>
        /// <exception cref="Exception">Ném ra nếu không tìm thấy chuỗi kết nối.</exception>
        public InventoryDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string 'DefaultConnection' not found in App.config!");
            }
        }

        #endregion

        #region Read Methods

        /// <summary>
        /// Lấy danh sách tất cả các nguyên vật liệu, bao gồm tên đơn vị tương ứng.
        /// Dữ liệu này được dùng để hiển thị lên DataGridView quản lý tồn kho.
        /// </summary>
        /// <returns>Một DataTable chứa thông tin chi tiết của tất cả nguyên vật liệu.</returns>
        public DataTable GetIngredientsWithUnits()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // Truy vấn JOIN Ingredients và Units để lấy tên đơn vị (UnitName)
                string query = @"
                    SELECT 
                        I.IngredientID, 
                        I.Name, 
                        I.CurrentStock, 
                        U.Name AS UnitName,  -- Đặt alias là UnitName để dễ dàng map với cột DGV
                        I.CostPerUnit,
                        I.MinStockLevel
                    FROM 
                        Ingredients I
                    JOIN 
                        Units U ON I.UnitID = U.UnitID
                    ORDER BY 
                        I.Name";

                var da = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Có thể thêm các phương thức khác như GetIngredientByID, UpdateStock, v.v. ở đây

        #endregion

        #region Inventory Transaction Methods
        /// <summary>
        /// Kiểm tra xem Nguyên vật liệu có đang được sử dụng trong bất kỳ công thức nào không.
        /// </summary>
        public bool IsIngredientUsedInRecipe(int ingredientId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM MenuItemIngredients WHERE IngredientID = @IngredientID";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IngredientID", ingredientId);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        /// <summary>
        /// Xóa nguyên vật liệu khỏi bảng Ingredients.
        /// </summary>
        public bool DeleteIngredientById(int ingredientId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ingredients WHERE IngredientID = @IngredientID";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IngredientID", ingredientId);
                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Lấy danh sách nguyên vật liệu và số lượng cần dùng cho tất cả các món trong một đơn hàng.
        /// </summary>
        /// <param name="orderId">ID của đơn hàng.</param>
        /// <returns>DataTable chứa IngredientID, QuantityUsed, UnitID và Quantity trong OrderItem.</returns>
        public DataTable GetIngredientsToDeduct(int orderId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // Truy vấn: OrderItems -> MenuItems -> MenuItemIngredients
                string query = @"
                SELECT 
                    OMI.IngredientID,
                    OMI.QuantityUsed,      -- Định lượng NVL cho 1 suất ăn
                    OMI.UnitID AS RecipeUnitID,
                    OI.Quantity AS OrderQuantity  -- Số lượng suất ăn trong Order
                FROM 
                    OrderItems OI
                JOIN 
                    MenuItemIngredients OMI ON OI.MenuItemID = OMI.MenuItemID
                WHERE 
                    OI.OrderID = @OrderID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// Thêm một nguyên vật liệu mới vào cơ sở dữ liệu.
        /// </summary>
        /// <returns>True nếu thêm thành công, ngược lại là false.</returns>
        public bool AddIngredient(string name, int unitId, decimal stock, decimal cost, decimal minStock)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO Ingredients 
                (Name, UnitID, CurrentStock, CostPerUnit, MinStockLevel) 
            VALUES 
                (@Name, @UnitID, @CurrentStock, @CostPerUnit, @MinStockLevel)";

                var cmd = new SqlCommand(query, conn);

                // Thêm tham số
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@UnitID", unitId);
                cmd.Parameters.AddWithValue("@CurrentStock", stock);
                cmd.Parameters.AddWithValue("@CostPerUnit", cost);

                // Xử lý MinStockLevel, cho phép NULL nếu giá trị là 0 hoặc không hợp lệ
                if (minStock <= 0)
                {
                    cmd.Parameters.AddWithValue("@MinStockLevel", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinStockLevel", minStock);
                }

                conn.Open();
                // ExecuteNonQuery trả về số hàng bị ảnh hưởng
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một Nguyên vật liệu dựa vào ID.
        /// </summary>
        /// <param name="id">ID của nguyên vật liệu cần tìm.</param>
        /// <returns>Một DataRow chứa thông tin nguyên vật liệu, hoặc null nếu không tìm thấy.</returns>
        public DataRow GetIngredientById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // Truy vấn chính (chỉ cần lấy dữ liệu từ bảng Ingredients)
                string query = "SELECT * FROM Ingredients WHERE IngredientID = @id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }
        /// <summary>
        /// Lấy danh sách tất cả các đơn vị tính từ cơ sở dữ liệu.
        /// </summary>
        /// <returns>Một DataTable chứa UnitID và Name của các đơn vị.</returns>
        public DataTable GetUnits()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UnitID, Name FROM Units ORDER BY Name";
                var da = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// Lấy thông tin chi tiết của một Nguyên vật liệu dựa vào Tên.
        /// </summary>
        /// <param name="name">Tên của nguyên vật liệu cần tìm.</param>
        /// <returns>Một DataRow chứa thông tin nguyên vật liệu, hoặc null nếu không tìm thấy.</returns>
        public DataRow GetIngredientByName(string name)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ingredients WHERE Name = @Name";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }
        /// <summary>
        /// Cập nhật tồn kho, chi phí và mức tồn tối thiểu cho một Nguyên vật liệu đã tồn tại.
        /// </summary>
        /// <param name="id">ID của nguyên vật liệu.</param>
        /// <param name="newStock">Số lượng tồn kho MỚI (đã cộng dồn).</param>
        /// <param name="cost">Chi phí/Đơn vị MỚI (giá vốn mới nhất).</param>
        /// <param name="minStockLevel">Mức tồn kho tối thiểu (có thể là null).</param>
        /// <returns>True nếu cập nhật thành công.</returns>
        public bool UpdateIngredientDetails(int id, decimal newStock, decimal cost, decimal? minStockLevel)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE Ingredients 
            SET CurrentStock = @NewStock, 
                CostPerUnit = @Cost, 
                MinStockLevel = @MinStockLevel
            WHERE IngredientID = @Id";

                var cmd = new SqlCommand(query, conn);

                // Thêm tham số
                cmd.Parameters.AddWithValue("@NewStock", newStock);
                cmd.Parameters.AddWithValue("@Cost", cost);
                cmd.Parameters.AddWithValue("@Id", id);

                // Xử lý giá trị Null cho MinStockLevel
                if (minStockLevel.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinStockLevel", minStockLevel.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MinStockLevel", DBNull.Value);
                }

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Cập nhật số lượng tồn kho của một nguyên vật liệu.
        /// </summary>
        /// <param name="ingredientId">ID nguyên vật liệu.</param>
        /// <param name="deductAmount">Số lượng cần trừ đi (âm).</param>
        /// <returns>True nếu cập nhật thành công.</returns>
        public bool UpdateIngredientStock(int ingredientId, decimal deductAmount)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Ingredients
                SET CurrentStock = CurrentStock + @DeductAmount
                WHERE IngredientID = @IngredientID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DeductAmount", deductAmount);
                cmd.Parameters.AddWithValue("@IngredientID", ingredientId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion
    }
}