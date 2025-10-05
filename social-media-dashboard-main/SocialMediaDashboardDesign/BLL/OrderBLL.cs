using SocialMediaDashboardDesign.BusinessLogic;
using SocialMediaDashboardDesign.DAL;
using SocialMediaDashboardDesign.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaDashboardDesign.BLL
{
    public class OrderBLL
    {
        private OrderDAL orderDAL;
        private readonly InventoryBLL inventoryBLL;
        private readonly RevenueDAL revenueDAL;
        public OrderBLL()
        {
            orderDAL = new OrderDAL();
            inventoryBLL = new InventoryBLL();
            revenueDAL = new RevenueDAL();
        }

        public OrderDAL GetOrderDAL()
        {
            return orderDAL;
        }

        /// <summary>
        /// Xử lý việc hoàn thành đơn hàng, bao gồm cập nhật trạng thái, tính COGS và trừ kho.
        /// </summary>
        public bool CompleteOrder(int orderId)
        {
            // 1. Cập nhật trạng thái Order thành 'Completed'
            bool orderStatusUpdateSuccess = orderDAL.UpdateOrderStatus(orderId, "Completed");

            if (orderStatusUpdateSuccess)
            {
                // 2. TÍNH TOÁN VÀ CẬP NHẬT COGS
                try
                {
                    // a. Tính toán Total COGS (Sử dụng hàm đã định nghĩa trong RevenueDAL)
                    decimal totalCogs = revenueDAL.GetOrderCOGS(orderId);

                    // b. Cập nhật TotalCOGS vào bảng Orders
                    bool cogsUpdateSuccess = orderDAL.UpdateOrderTotalCOGS(orderId, totalCogs);

                    if (!cogsUpdateSuccess)
                    {
                        // Xử lý lỗi: Cảnh báo nếu không cập nhật được COGS
                        Console.WriteLine($"CẢNH BÁO: Không thể cập nhật TotalCOGS cho OrderID {orderId}.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu tính toán COGS thất bại
                    Console.WriteLine($"LỖI: Lỗi khi tính toán/cập nhật COGS cho OrderID {orderId}: {ex.Message}");
                }

                // 3. Trừ kho (Đã thiết kế trước đó)
                bool stockDeductionSuccess = inventoryBLL.DeductStockForCompletedOrder(orderId);

                if (!stockDeductionSuccess)
                {
                    Console.WriteLine($"CẢNH BÁO: Không thể trừ kho cho OrderID {orderId}.");
                }

                return true;
            }

            return false;
        }
        public DataTable GetOrdersByFilter(string searchTerm, string status, DateTime dateFrom, DateTime dateTo)
        {
            // Kiểm tra logic nghiệp vụ cơ bản
            if (dateFrom > dateTo)
            {
                throw new Exception("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
            }

            // Gọi phương thức từ DAL để lấy dữ liệu
            return orderDAL.GetOrdersByFilter(searchTerm, status, dateFrom, dateTo);
        }

        public DataSet GetBillDetails(int orderId)
        {
            return orderDAL.GetBillDetails(orderId);
        }
        public DataRow GetOrderSummary(int orderId)
        {
            return orderDAL.GetOrderSummary(orderId);
        }
        // Lấy hoặc tạo order cho bàn
        public DataTable GetOrCreateOrder(int tableId)
        {
            return orderDAL.GetOrCreateOrder(tableId);
        }
        // Cập nhật trạng thái bàn (gọi qua OrderDAL)
        public void UpdateTableStatus(int tableId, string status)
        {
            if (string.IsNullOrEmpty(status))
                throw new Exception("Trạng thái không hợp lệ");

            orderDAL.UpdateTableStatus(tableId, status);
        }
        // Lấy các món trong order
        public DataTable GetOrderItems(int orderId)
        {
            return orderDAL.GetOrderItems(orderId);
        }

        // Thêm món vào order
        public void AddOrderItem(int orderId, int menuItemId, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Số lượng phải lớn hơn 0");

            orderDAL.AddOrderItem(orderId, menuItemId, quantity);
        }

        // Cập nhật số lượng món
        public void UpdateOrderItem(int orderId, int menuItemId, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Số lượng phải lớn hơn 0");

            orderDAL.UpdateOrderItem(orderId, menuItemId, quantity);
        }

        // Xóa món
        public void RemoveOrderItem(int orderId, int menuItemId)
        {
            orderDAL.RemoveOrderItem(orderId, menuItemId);
        }

        // Cập nhật trạng thái order
        public void UpdateOrderStatus(int orderId, string status)
        {
            if (string.IsNullOrEmpty(status))
                throw new Exception("Trạng thái không hợp lệ");

            orderDAL.UpdateOrderStatus(orderId, status);
        }
        
        public void SyncOrderItems(int orderId, DataTable items)
        {
         

            orderDAL.SyncOrderItems(orderId, items);
        }
    }
}
