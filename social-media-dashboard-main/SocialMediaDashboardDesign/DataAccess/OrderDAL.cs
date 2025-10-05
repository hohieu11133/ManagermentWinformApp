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
        public void UpdateTableStatus(int tableId, string status)
        {
            if (string.IsNullOrEmpty(status))
                throw new Exception("Trạng thái không hợp lệ");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Tables SET Status = @Status WHERE TableID = @TableId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@TableId", tableId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Cập nhật giá trị TotalCOGS vào bảng Orders sau khi tính toán.
        /// </summary>
        /// <param name="orderId">ID của đơn hàng.</param>
        /// <param name="totalCogs">Tổng Giá vốn hàng bán đã tính.</param>
        /// <returns>True nếu cập nhật thành công.</returns>
        public bool UpdateOrderTotalCOGS(int orderId, decimal totalCogs)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Orders SET TotalCOGS = @TotalCOGS WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TotalCOGS", totalCogs);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
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
        public DataTable GetOrdersByFilter(string searchTerm, string status, DateTime dateFrom, DateTime dateTo)
        {
            DataTable dt = new DataTable();
            // Sử dụng using để đảm bảo kết nối được đóng đúng cách
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Câu lệnh SQL cơ bản
                string query = @"SELECT 
                                o.OrderID, 
                                t.TableNumber, 
                                o.TotalAmount, 
                                o.Status, 
                                o.OrderTime
                             FROM 
                                Orders o
                             JOIN 
                                Tables t ON o.TableID = t.TableID
                             WHERE 1=1"; // WHERE 1=1 để dễ dàng nối các điều kiện AND

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // 1. Thêm điều kiện lọc theo ngày (luôn có)
                query += " AND o.OrderTime BETWEEN @DateFrom AND @DateTo";
                cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@DateTo", dateTo);

                // 2. Thêm điều kiện tìm kiếm nếu có
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (CONVERT(varchar, o.OrderID) LIKE @SearchTerm OR CONVERT(varchar, t.TableNumber) LIKE @SearchTerm)";
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                }

                // 3. Thêm điều kiện lọc theo trạng thái nếu có (và không phải 'Tất cả')
                if (!string.IsNullOrEmpty(status) && !status.Equals("All", StringComparison.OrdinalIgnoreCase))
                {
                    query += " AND o.Status = @Status";
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                // Sắp xếp để các đơn hàng mới nhất lên đầu
                query += " ORDER BY o.OrderTime DESC";

                cmd.CommandText = query;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        //// 2. Lấy danh sách món trong order
        //public DataTable GetOrderItems(int orderId)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = @"SELECT oi.OrderItemID, m.Name, oi.Quantity, oi.Price, (oi.Quantity * oi.Price) AS Subtotal
        //                         FROM OrderItems oi
        //                         JOIN MenuItems m ON oi.MenuItemID = m.MenuItemID
        //                         WHERE oi.OrderID = @OrderID";

        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //        da.SelectCommand.Parameters.AddWithValue("@OrderID", orderId);

        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}
        /// <summary>
        /// Lấy thông tin tóm tắt của một đơn hàng cụ thể.
        /// </summary>
        /// <param name="orderId">Mã đơn hàng cần lấy thông tin.</param>
        /// <returns>Một DataRow chứa thông tin tóm tắt.</returns>
        public DataRow GetOrderSummary(int orderId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                            o.OrderID, 
                            t.TableNumber, 
                            o.TotalAmount, 
                            o.Status
                         FROM 
                            Orders o
                         JOIN 
                            Tables t ON o.TableID = t.TableID
                         WHERE 
                            o.OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            // Trả về hàng đầu tiên nếu có, ngược lại trả về null
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        /// <summary>
        /// Lấy toàn bộ thông tin cần thiết cho một hóa đơn trong một lần gọi.
        /// </summary>
        /// <param name="orderId">Mã đơn hàng cần lấy thông tin.</param>
        /// <returns>Một DataSet chứa 2 DataTable: OrderSummary và OrderItems.</returns>
        public DataSet GetBillDetails(int orderId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Câu lệnh 1: Lấy thông tin tóm tắt của Order
                string summaryQuery = @"
            SELECT 
                o.OrderID, 
                t.TableNumber, 
                o.OrderTime,
                o.TotalAmount 
            FROM Orders o
            JOIN Tables t ON o.TableID = t.TableID
            WHERE o.OrderID = @OrderID";

                // Câu lệnh 2: Lấy danh sách các món ăn
                string itemsQuery = @"
            SELECT 
                mi.Name AS ItemName, 
                oi.Quantity, 
                oi.Price,
                (oi.Quantity * oi.Price) AS Subtotal
            FROM OrderItems oi
            JOIN MenuItems mi ON oi.MenuItemID = mi.MenuItemID
            WHERE oi.OrderID = @OrderID";

                // Gộp 2 câu lệnh và thực thi trong 1 lần
                string finalQuery = summaryQuery + "; " + itemsQuery;

                using (SqlCommand cmd = new SqlCommand(finalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Tự động điền vào DataSet với 2 bảng
                        adapter.Fill(ds);
                    }
                }

                // Đặt tên cho các bảng để dễ truy cập
                if (ds.Tables.Count > 0) ds.Tables[0].TableName = "OrderSummary";
                if (ds.Tables.Count > 1) ds.Tables[1].TableName = "OrderItems";
            }
            return ds;
        }
        /// <summary>
        /// Lấy danh sách tất cả các món trong một đơn hàng.
        /// </summary>
        /// <param name="orderId">Mã đơn hàng cần lấy danh sách món.</param>
        /// <returns>DataTable chứa danh sách các món.</returns>
        public DataTable GetOrderItems(int orderId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Câu lệnh SQL này join OrderItems với MenuItems để lấy Tên và Giá,
                // đồng thời tính luôn cột Total cho mỗi món.
                string query = @"SELECT 
                            oi.MenuItemID,
                            mi.Name AS ItemName, 
                            oi.Quantity, 
                            mi.Price,
                            (oi.Quantity * mi.Price) AS Total
                         FROM 
                            OrderItems oi
                         JOIN 
                            MenuItems mi ON oi.MenuItemID = mi.MenuItemID
                         WHERE 
                            oi.OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
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

        public bool UpdateOrderStatus(int orderId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@OrderID", orderId);

                // ExecuteNonQuery trả về số lượng hàng bị ảnh hưởng.
                int rowsAffected = cmd.ExecuteNonQuery();

                // Trả về true nếu có ít nhất một hàng bị cập nhật (thành công)
                return rowsAffected > 0;
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
        // Dán hàm này vào file OrderDAL.cs của bạn

        public void SyncOrderItems(int orderId, DataTable items)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Bắt đầu một giao dịch để đảm bảo an toàn dữ liệu
                // Hoặc cả hai lệnh cùng thành công, hoặc cả hai cùng thất bại
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // --- BƯỚC 1: Xóa tất cả các món cũ của order này ---
                    string deleteQuery = "DELETE FROM OrderItems WHERE OrderID = @OrderID";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction))
                    {
                        deleteCmd.Parameters.AddWithValue("@OrderID", orderId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // --- BƯỚC 2: Thêm lại tất cả các món từ GridView ---
                    string insertQuery = "INSERT INTO OrderItems (OrderID, MenuItemID, Quantity, Price) VALUES (@OrderID, @MenuItemID, @Quantity, @Price)";
                    foreach (DataRow row in items.Rows)
                    {
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@OrderID", orderId);
                            insertCmd.Parameters.AddWithValue("@MenuItemID", row["MenuItemID"]);
                            insertCmd.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                            insertCmd.Parameters.AddWithValue("@Price", row["Price"]);
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    // Nếu mọi thứ thành công, xác nhận giao dịch
                    transaction.Commit();

                    // Cập nhật lại tổng tiền cho Order sau khi đồng bộ
                    UpdateOrderTotal(conn, orderId);
                }
                catch (Exception)
                {
                    // Nếu có bất kỳ lỗi nào, hủy bỏ tất cả thay đổi
                    transaction.Rollback();
                    throw; // Ném lại lỗi để lớp trên có thể bắt được
                }
            }
        }
    }

}
