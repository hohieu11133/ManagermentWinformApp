using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SocialMediaDashboardDesign.DataAccess
{
    public class OrderDAL
    {
        private string connectionString;

        public OrderDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string not found in App.config!");
        }

        // 1. Lấy hoặc tạo order cho table
        public DataTable GetOrCreateOrder(int tableId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra order còn "Pending" hoặc "In Progress"
                string checkQuery = "SELECT TOP 1 * FROM Orders WHERE TableID = @TableID AND Status IN ('Pending','In Progress')";
                SqlDataAdapter da = new SqlDataAdapter(checkQuery, conn);
                da.SelectCommand.Parameters.AddWithValue("@TableID", tableId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0) // chưa có thì tạo order mới
                {
                    string insertQuery = "INSERT INTO Orders (TableID, Status, TotalAmount) " +
                                         "VALUES (@TableID, 'In Progress', 0.00); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@TableID", tableId);
                    int newOrderId = Convert.ToInt32(cmd.ExecuteScalar());

                    string getQuery = "SELECT * FROM Orders WHERE OrderID = @OrderID";
                    da = new SqlDataAdapter(getQuery, conn);
                    da.SelectCommand.Parameters.AddWithValue("@OrderID", newOrderId);
                    dt = new DataTable();
                    da.Fill(dt);
                }

                return dt;
            }
        }

        // 2. Lấy danh sách món trong order
        public DataTable GetOrderItems(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT oi.OrderItemID, m.Name, oi.Quantity, oi.Price, (oi.Quantity * oi.Price) AS Subtotal
                                 FROM OrderItems oi
                                 JOIN MenuItems m ON oi.MenuItemID = m.MenuItemID
                                 WHERE oi.OrderID = @OrderID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@OrderID", orderId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3. Thêm món vào order
        public void AddOrderItem(int orderId, int menuItemId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy giá món ăn hiện tại
                string priceQuery = "SELECT Price FROM MenuItems WHERE MenuItemID = @MenuItemID";
                SqlCommand cmdPrice = new SqlCommand(priceQuery, conn);
                cmdPrice.Parameters.AddWithValue("@MenuItemID", menuItemId);
                decimal price = Convert.ToDecimal(cmdPrice.ExecuteScalar());

                // Insert OrderItem
                string insertQuery = @"INSERT INTO OrderItems (OrderID, MenuItemID, Quantity, Price)
                                       VALUES (@OrderID, @MenuItemID, @Quantity, @Price)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();

                UpdateOrderTotal(conn, orderId);
            }
        }

        // 4. Cập nhật số lượng món
        public void UpdateOrderItem(int orderId, int menuItemId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE OrderItems SET Quantity = @Quantity WHERE OrderID = @OrderID AND MenuItemID = @MenuItemID";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                cmd.ExecuteNonQuery();

                UpdateOrderTotal(conn, orderId);
            }
        }

        // 5. Xóa món
        public void RemoveOrderItem(int orderId, int menuItemId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string deleteQuery = "DELETE FROM OrderItems WHERE OrderID = @OrderID AND MenuItemID = @MenuItemID";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                cmd.ExecuteNonQuery();

                UpdateOrderTotal(conn, orderId);
            }
        }

        // 6. Cập nhật trạng thái Order
        public void UpdateOrderStatus(int orderId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.ExecuteNonQuery();
            }
        }

        // Helper: cập nhật tổng tiền
        private void UpdateOrderTotal(SqlConnection conn, int orderId)
        {
            string totalQuery = "UPDATE Orders SET TotalAmount = (SELECT SUM(Quantity * Price) FROM OrderItems WHERE OrderID = @OrderID) WHERE OrderID = @OrderID";
            SqlCommand cmd = new SqlCommand(totalQuery, conn);
            cmd.Parameters.AddWithValue("@OrderID", orderId);
            cmd.ExecuteNonQuery();
        }
    }
}
