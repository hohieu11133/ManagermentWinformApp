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
    }
}
