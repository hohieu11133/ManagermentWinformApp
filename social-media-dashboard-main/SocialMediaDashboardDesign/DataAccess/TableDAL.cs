using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaDashboardDesign.DataAccess
{
    public class TableDAL
    {
        private readonly string connectionString;

        public TableDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string not found in App.config!");
            }
        }

        public DataTable GetAllTables()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TableID, TableNumber, Status FROM Tables";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataRow GetTableById(int tableId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TableID, TableNumber, Status FROM Tables WHERE TableID = @TableID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@TableID", tableId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public bool InsertTable(string tableNumber, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tables (TableNumber, Status) VALUES (@TableNumber, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableNumber", tableNumber);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTable(int tableId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Tables SET Status = @Status WHERE TableID = @TableID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@TableID", tableId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteTable(int tableId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tables WHERE TableID = @TableID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableID", tableId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
