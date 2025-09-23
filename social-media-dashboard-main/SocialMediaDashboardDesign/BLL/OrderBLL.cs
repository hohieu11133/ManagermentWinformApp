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

        public OrderBLL()
        {
            orderDAL = new OrderDAL();
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
        // Dán hàm này vào file OrderBLL.cs của bạn

        public void SyncOrderItems(int orderId, DataTable items)
        {
            // Có thể thêm các logic kiểm tra nghiệp vụ ở đây nếu cần
            // Ví dụ: kiểm tra xem tổng số lượng có hợp lệ không, v.v.

            orderDAL.SyncOrderItems(orderId, items);
        }
    }
}
