using SocialMediaDashboardDesign.BLL;
using System;
using System.Collections.Generic;
using System.Configuration; // để đọc từ App.config
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign.DataAccess
{
    public class MenuDAL
    {
        private string connectionString;

        public MenuDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string not found in App.config!");
            }
        }

        public DataTable GetCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CategoryID, Name FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        // Trong MenuDAL
        public DataRow GetMenuItemByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MenuItems WHERE Name = @Name";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Name", name);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public DataTable GetMenuItems()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT m.MenuItemID, m.Name, m.Price, c.Name AS Category, m.IsAvailable
                                 FROM MenuItems m
                                 LEFT JOIN Categories c ON m.CategoryID = c.CategoryID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable SearchMenuItems(string keyword, int? categoryId = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT m.MenuItemID, m.Name, m.Price, c.Name AS Category, m.IsAvailable
            FROM MenuItems m
            LEFT JOIN Categories c ON m.CategoryID = c.CategoryID
            WHERE (@keyword = '' OR m.Name LIKE @keyword)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Nếu keyword rỗng thì truyền "" để bỏ qua
                if (string.IsNullOrWhiteSpace(keyword) || keyword == "Search items...")
                    cmd.Parameters.AddWithValue("@keyword", "");
                else
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Chỉ lọc khi categoryId > 0
                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    query += " AND m.CategoryID = @categoryId";
                    cmd.Parameters.AddWithValue("@categoryId", categoryId.Value);
                }

                cmd.CommandText = query;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }




        public DataRow GetMenuItemById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MenuItems WHERE MenuItemID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public bool AddMenuItem(string name, int categoryId, decimal price, bool isAvailable, string imageUrl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO MenuItems (Name, CategoryID, Price, IsAvailable, ImageURL) VALUES (@name, @categoryId, @price, @isAvailable, @imageUrl)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@imageUrl", (object)imageUrl ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateMenuItem(int id, string name, int categoryId, decimal price, bool isAvailable, string imageUrl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE MenuItems SET Name=@name, CategoryID=@categoryId, Price=@price, IsAvailable=@isAvailable, ImageURL=@imageUrl WHERE MenuItemID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
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


        public bool ToggleAvailability(int menuItemId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE MenuItems 
                                 SET IsAvailable = CASE WHEN IsAvailable = 1 THEN 0 ELSE 1 END
                                 WHERE MenuItemID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", menuItemId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteMenuItem(int menuItemId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MenuItems WHERE MenuItemID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", menuItemId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
