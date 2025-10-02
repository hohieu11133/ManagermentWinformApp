using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SocialMediaDashboardDesign.DataAccess
{
    /// <summary>
    /// Lớp Data Access Layer (DAL) để xử lý các hoạt động cơ sở dữ liệu liên quan đến menu và các món ăn.
    /// </summary>
    public class MenuDAL
    {
        #region Fields

        private readonly string connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo một instance mới của lớp MenuDAL.
        /// Đọc chuỗi kết nối từ file App.config.
        /// </summary>
        /// <exception cref="Exception">Ném ra nếu không tìm thấy chuỗi kết nối.</exception>
        public MenuDAL()
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
        /// Lấy danh sách tất cả các danh mục (category) từ cơ sở dữ liệu.
        /// </summary>
        /// <returns>Một DataTable chứa CategoryID và Name của các danh mục.</returns>
        public DataTable GetCategories()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CategoryID, Name FROM Categories";
                var da = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một món ăn dựa vào tên.
        /// </summary>
        /// <param name="name">Tên của món ăn cần tìm.</param>
        /// <returns>Một DataRow chứa thông tin món ăn, hoặc null nếu không tìm thấy.</returns>
        public DataRow GetMenuItemByName(string name)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MenuItems WHERE Name = @Name";
                var da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Name", name);

                var dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả các món ăn trong menu.
        /// </summary>
        /// <returns>Một DataTable chứa thông tin chi tiết của tất cả món ăn.</returns>
        public DataTable GetMenuItems()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT m.MenuItemID, m.Name, m.Price, c.Name AS Category, m.IsAvailable
                    FROM MenuItems m
                    LEFT JOIN Categories c ON m.CategoryID = c.CategoryID";
                var da = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Tìm kiếm các món ăn dựa trên từ khóa và/hoặc danh mục.
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm theo tên món ăn.</param>
        /// <param name="categoryId">ID của danh mục để lọc (tùy chọn).</param>
        /// <returns>Một DataTable chứa kết quả tìm kiếm.</returns>
        public DataTable SearchMenuItems(string keyword, int? categoryId = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT m.MenuItemID, m.Name, m.Price, c.Name AS Category, m.IsAvailable
                    FROM MenuItems m
                    LEFT JOIN Categories c ON m.CategoryID = c.CategoryID
                    WHERE m.IsAvailable = 1 AND (@keyword = '' OR m.Name LIKE @keyword)";

                var cmd = new SqlCommand();
                cmd.Connection = conn;

                if (string.IsNullOrWhiteSpace(keyword) || keyword == "Search items...")
                    cmd.Parameters.AddWithValue("@keyword", "");
                else
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    query += " AND m.CategoryID = @categoryId";
                    cmd.Parameters.AddWithValue("@categoryId", categoryId.Value);
                }

                cmd.CommandText = query;

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một món ăn dựa vào ID.
        /// </summary>
        /// <param name="id">ID của món ăn cần tìm.</param>
        /// <returns>Một DataRow chứa thông tin món ăn, hoặc null nếu không tìm thấy.</returns>
        public DataRow GetMenuItemById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MenuItems WHERE MenuItemID = @id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// Thêm một món ăn mới vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="name">Tên món ăn.</param>
        /// <param name="categoryId">ID của danh mục.</param>
        /// <param name="price">Giá món ăn.</param>
        /// <param name="isAvailable">Trạng thái có sẵn.</param>
        /// <param name="imageUrl">URL hình ảnh (tùy chọn).</param>
        /// <returns>True nếu thêm thành công, ngược lại là false.</returns>
        public bool AddMenuItem(string name, int categoryId, decimal price, bool isAvailable, string imageUrl)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO MenuItems (Name, CategoryID, Price, IsAvailable, ImageURL) VALUES (@name, @categoryId, @price, @isAvailable, @imageUrl)";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@imageUrl", (object)imageUrl ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Cập nhật thông tin của một món ăn đã có.
        /// </summary>
        /// <param name="id">ID của món ăn cần cập nhật.</param>
        /// <param name="name">Tên mới.</param>
        /// <param name="categoryId">ID danh mục mới.</param>
        /// <param name="price">Giá mới.</param>
        /// <param name="isAvailable">Trạng thái có sẵn mới.</param>
        /// <param name="imageUrl">URL hình ảnh mới (tùy chọn).</param>
        /// <returns>True nếu cập nhật thành công, ngược lại là false.</returns>
        public bool UpdateMenuItem(int id, string name, int categoryId, decimal price, bool isAvailable, string imageUrl)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE MenuItems SET Name=@name, CategoryID=@categoryId, Price=@price, IsAvailable=@isAvailable, ImageURL=@imageUrl WHERE MenuItemID=@id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@imageUrl", (object)imageUrl ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Đảo ngược trạng thái có sẵn (IsAvailable) của một món ăn.
        /// </summary>
        /// <param name="menuItemId">ID của món ăn cần thay đổi.</param>
        /// <returns>True nếu thay đổi thành công, ngược lại là false.</returns>
        public bool ToggleAvailability(int menuItemId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE MenuItems 
                    SET IsAvailable = CASE WHEN IsAvailable = 1 THEN 0 ELSE 1 END
                    WHERE MenuItemID = @id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", menuItemId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Xóa một món ăn khỏi cơ sở dữ liệu.
        /// </summary>
        /// <param name="menuItemId">ID của món ăn cần xóa.</param>
        /// <returns>True nếu xóa thành công, ngược lại là false.</returns>
        public bool DeleteMenuItem(int menuItemId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MenuItems WHERE MenuItemID = @id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", menuItemId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion
    }
}