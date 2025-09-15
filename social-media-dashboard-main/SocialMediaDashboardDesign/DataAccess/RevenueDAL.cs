using System;
using System.Configuration;
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
