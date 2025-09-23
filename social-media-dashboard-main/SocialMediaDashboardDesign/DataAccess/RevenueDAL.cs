using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SocialMediaDashboardDesign.DAL
{
    public class RevenueDAL
    {
        private string connectionString;

        public RevenueDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string not found in App.config!");
        }
        public DataTable GetRevenueByMonthInYear(int year)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT MONTH(OrderTime) AS OrderMonth, SUM(TotalAmount) AS MonthlyTotal
                FROM Orders
                WHERE Status = 'Completed' AND YEAR(OrderTime) = @Year
                GROUP BY MONTH(OrderTime)
                ORDER BY OrderMonth;";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Year", year);
                da.Fill(dt);
            }
            return dt;
        }

        // Hàm mới để lấy doanh thu các ngày trong tháng
        public DataTable GetRevenueByDayInMonth(int year, int month)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT DAY(OrderTime) AS OrderDay, SUM(TotalAmount) AS DailyTotal
                FROM Orders
                WHERE Status = 'Completed' AND YEAR(OrderTime) = @Year AND MONTH(OrderTime) = @Month
                GROUP BY DAY(OrderTime)
                ORDER BY OrderDay;";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Year", year);
                da.SelectCommand.Parameters.AddWithValue("@Month", month);
                da.Fill(dt);
            }
            return dt;
        }
        // Doanh thu cả năm
        public decimal GetYearlyRevenue(int year)
        {
            decimal total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT SUM(TotalAmount) 
                    FROM [RestaurantManagementDB].[dbo].[Orders]
                    WHERE Status = 'Completed'
                      AND YEAR(OrderTime) = @Year";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
            }
            return total;
        }

        // Doanh thu theo tháng
        public decimal GetMonthlyRevenue(int year, int month)
        {
            decimal total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT SUM(TotalAmount) 
                    FROM [RestaurantManagementDB].[dbo].[Orders]
                    WHERE Status = 'Completed'
                      AND YEAR(OrderTime) = @Year
                      AND MONTH(OrderTime) = @Month";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
            }
            return total;
        }
    }
}
