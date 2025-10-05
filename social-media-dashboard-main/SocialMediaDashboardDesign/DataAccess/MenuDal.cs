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
        // <summary>
        /// Thực hiện giao dịch cập nhật món ăn (MenuItem) và thay thế công thức (MenuItemIngredients) trong một Transaction.
        /// </summary>
        public bool ExecuteUpdateMenuItemTransaction(int menuItemId, string name, int categoryId, decimal price,
                                                    bool isAvailable, string imageUrl, DataTable recipeData)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // A. Cập nhật thông tin món ăn cơ bản (MenuItem)
                    string updateItemQuery = @"
                UPDATE MenuItems SET 
                    Name = @Name, CategoryID = @CategoryID, Price = @Price, 
                    IsAvailable = @IsAvailable, ImageURL = @ImageURL
                WHERE MenuItemID = @MenuItemID";

                    var updateCmd = new SqlCommand(updateItemQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@Name", name);
                    updateCmd.Parameters.AddWithValue("@CategoryID", categoryId);
                    updateCmd.Parameters.AddWithValue("@Price", price);
                    updateCmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                    updateCmd.Parameters.AddWithValue("@ImageURL", (object)imageUrl ?? DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@MenuItemID", menuItemId);

                    updateCmd.ExecuteNonQuery();

                    // B. XÓA công thức cũ (Master-Detail Delete)
                    string deleteRecipeQuery = "DELETE FROM MenuItemIngredients WHERE MenuItemID = @MenuItemID";
                    var deleteCmd = new SqlCommand(deleteRecipeQuery, conn, transaction);
                    deleteCmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                    deleteCmd.ExecuteNonQuery(); // Không cần kiểm tra số hàng bị ảnh hưởng

                    // C. CHÈN công thức mới (Sử dụng logic tương tự AddRecipeItems)
                    string insertRecipeQuery = @"
                INSERT INTO MenuItemIngredients (MenuItemID, IngredientID, QuantityUsed, UnitID) 
                VALUES (@MenuItemID, @IngredientID, @QuantityUsed, @UnitID)";

                    var insertCmd = new SqlCommand(insertRecipeQuery, conn, transaction);

                    foreach (DataRow row in recipeData.Rows)
                    {
                        insertCmd.Parameters.Clear();
                        insertCmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                        insertCmd.Parameters.AddWithValue("@IngredientID", row.Field<int>("IngredientID"));
                        insertCmd.Parameters.AddWithValue("@QuantityUsed", row.Field<decimal>("QuantityUsed"));
                        insertCmd.Parameters.AddWithValue("@UnitID", row.Field<int>("UnitID"));

                        insertCmd.ExecuteNonQuery();
                    }

                    // D. Nếu mọi thứ đều thành công, COMMIT TRANSACTION
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có bất kỳ lỗi nào xảy ra, ROLLBACK và ném lỗi
                    transaction.Rollback();
                    // Tùy chọn: Log lỗi ex.Message ở đây
                    throw new Exception("Lỗi giao dịch cập nhật món ăn và công thức.", ex);
                }
            }
        }
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
        /// Lấy chi tiết công thức (nguyên vật liệu và số lượng) của một món ăn cụ thể.
        /// </summary>
        /// <param name="menuItemId">ID của món ăn.</param>
        /// <returns>DataTable chứa IngredientID, QuantityUsed, và UnitID.</returns>
        public DataTable GetRecipeByMenuItemId(int menuItemId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                OMI.IngredientID, 
                OMI.QuantityUsed, 
                OMI.UnitID
                -- Có thể thêm I.Name AS IngredientName, U.Name AS UnitName 
                -- để debugging hoặc hiển thị nếu cần
            FROM 
                MenuItemIngredients OMI
            WHERE 
                OMI.MenuItemID = @MenuItemID
            ORDER BY 
                OMI.IngredientID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MenuItemID", menuItemId);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// Thêm các mục công thức vào bảng MenuItemIngredients.
        /// </summary>
        /// <param name="menuItemId">ID của món ăn vừa được tạo.</param>
        /// <param name="recipeData">DataTable chứa các cột: IngredientID, QuantityUsed, UnitID.</param>
        /// <returns>True nếu tất cả các dòng đều được chèn thành công.</returns>
        public bool AddRecipeItems(int menuItemId, DataTable recipeData)
        {
            if (recipeData == null || recipeData.Rows.Count == 0) return true;

            int totalRowsAffected = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Bắt đầu một Transaction để đảm bảo tất cả dòng công thức được chèn
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string query = @"
                INSERT INTO MenuItemIngredients (MenuItemID, IngredientID, QuantityUsed, UnitID) 
                VALUES (@MenuItemID, @IngredientID, @QuantityUsed, @UnitID)";

                    var cmd = new SqlCommand(query, conn, transaction);

                    foreach (DataRow row in recipeData.Rows)
                    {
                        // Thêm tham số cho mỗi dòng
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MenuItemID", menuItemId);
                        cmd.Parameters.AddWithValue("@IngredientID", row.Field<int>("IngredientID"));
                        cmd.Parameters.AddWithValue("@QuantityUsed", row.Field<decimal>("QuantityUsed"));
                        cmd.Parameters.AddWithValue("@UnitID", row.Field<int>("UnitID"));

                        totalRowsAffected += cmd.ExecuteNonQuery();
                    }

                    // Nếu không có lỗi, commit Transaction
                    transaction.Commit();

                    // Trả về true nếu số hàng bị ảnh hưởng bằng số dòng trong DataTable
                    return totalRowsAffected == recipeData.Rows.Count;
                }
                catch (Exception)
                {
                    // Nếu có lỗi, rollback Transaction
                    transaction.Rollback();
                    throw; // Ném lại lỗi để tầng BLL xử lý
                }
            }
        }
        /// <summary>
        /// Thêm một món ăn mới vào cơ sở dữ liệu và trả về MenuItemID.
        /// </summary>
        /// <returns>MenuItemID vừa được thêm, hoặc -1 nếu thất bại.</returns>
        public int AddMenuItemAndGetID(string name, int categoryId, decimal price, bool isAvailable, string imageUrl)
        {
            int newMenuItemID = -1;
            using (var conn = new SqlConnection(connectionString))
            {
                // Sử dụng SCOPE_IDENTITY() để lấy ID vừa được tạo
                string query = @"
            INSERT INTO MenuItems (Name, CategoryID, Price, IsAvailable, ImageURL) 
            VALUES (@name, @categoryId, @price, @isAvailable, @imageUrl);
            SELECT SCOPE_IDENTITY();";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@imageUrl", (object)imageUrl ?? DBNull.Value);

                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    newMenuItemID = Convert.ToInt32(result);
                }
            }
            return newMenuItemID;
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
        /// <summary>
        /// Kiểm tra xem món ăn đã tồn tại chưa. Có thể loại trừ món đang chỉnh sửa.
        /// </summary>
        /// <param name="name">Tên món ăn.</param>
        /// <param name="excludeId">ID món ăn cần loại trừ (Mặc định là 0 cho chế độ thêm mới).</param>
        /// <returns>True nếu món ăn trùng tên tồn tại.</returns>
        public bool MenuItemExists(string name, int excludeId = 0)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*) 
            FROM MenuItems 
            WHERE Name = @Name AND MenuItemID != @ExcludeId";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ExcludeId", excludeId); // Loại trừ ID món đang chỉnh sửa

                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        #endregion
    }
}