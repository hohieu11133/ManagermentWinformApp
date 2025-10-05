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
        /// <summary>
        /// Lấy tổng COGS của các đơn hàng đã hoàn thành trong năm.
        /// </summary>
        public decimal GetYearlyCOGS(int year)
        {
            decimal totalCOGS = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT SUM(TotalCOGS) 
                    FROM [RestaurantManagementDB].[dbo].[Orders]
                    WHERE Status = 'Completed'
                      AND YEAR(OrderTime) = @Year";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                        totalCOGS = Convert.ToDecimal(result);
                }
            }
            return totalCOGS;
        }

        /// <summary>
        /// Tính tổng Lợi nhuận gộp của các đơn hàng đã hoàn thành trong năm.
        /// Lợi nhuận = Doanh thu - COGS.
        /// </summary>
        public decimal GetYearlyProfit(int year)
        {
            // Lợi nhuận = Doanh thu năm - COGS năm
            decimal yearlyRevenue = GetYearlyRevenue(year);
            decimal yearlyCOGS = GetYearlyCOGS(year);
            return yearlyRevenue - yearlyCOGS;
        }

        /// <summary>
        /// Tính tổng Lợi nhuận gộp của các đơn hàng đã hoàn thành theo tháng.
        /// Lợi nhuận = Doanh thu tháng - COGS tháng.
        /// </summary>
        public decimal GetMonthlyProfit(int year, int month)
        {
            // Lợi nhuận = Doanh thu tháng - COGS tháng
            decimal monthlyRevenue = GetMonthlyRevenue(year, month);
            decimal monthlyCOGS = GetMonthlyCOGS(year, month);
            return monthlyRevenue - monthlyCOGS;
        }

        /// <summary>
        /// Lấy tổng COGS của các đơn hàng đã hoàn thành trong tháng.
        /// </summary>
        public decimal GetMonthlyCOGS(int year, int month)
        {
            decimal totalCOGS = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT SUM(TotalCOGS) 
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
                    if (result != DBNull.Value && result != null)
                        totalCOGS = Convert.ToDecimal(result);
                }
            }
            return totalCOGS;
        }
        // <summary>
        /// Tính tổng Giá vốn hàng bán (COGS) cho một đơn hàng đã hoàn thành, 
        /// có tính đến tỉ lệ chuyển đổi đơn vị giữa Công thức và Kho.
        /// </summary>
        /// <param name="orderId">ID của đơn hàng.</param>
        /// <returns>Tổng COGS của đơn hàng đó.</returns>
        public decimal GetOrderCOGS(int orderId)
        {
            decimal totalCOGS = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Truy vấn tính COGS sử dụng LEFT JOIN với UnitConversions để lấy tỉ lệ
                string query = @"
            SELECT 
                SUM(
                    OI.Quantity * -- Số suất ăn trong Order
                    OMI.QuantityUsed *-- Định lượng NVL cho 1 suất (Theo đơn vị OMI.UnitID)
                    I.CostPerUnit * -- Chi phí 1 đơn vị NVL (Theo đơn vị I.UnitID)
                    
                    -- LẤY TỈ LỆ CHUYỂN ĐỔI CHÍNH XÁC
                    ISNULL(
                        UC.ConversionFactor, 
                        -- Nếu không tìm thấy tỉ lệ, kiểm tra xem đơn vị có khớp không.
                        -- 1.00 nếu khớp (ví dụ: cái -> cái)
                        -- 0.00 nếu không khớp và không có quy tắc (để tránh tính sai)
                        CASE WHEN OMI.UnitID = I.UnitID THEN 1.00 ELSE 0.00 END 
                    )
                ) AS TotalCOGS
            FROM 
                OrderItems OI
            JOIN 
                MenuItemIngredients OMI ON OI.MenuItemID = OMI.MenuItemID
            JOIN
                Ingredients I ON OMI.IngredientID = I.IngredientID
            LEFT JOIN
                UnitConversions UC ON UC.FromUnitID = OMI.UnitID  -- Đơn vị NGUỒN (Công thức)
                                    AND UC.ToUnitID = I.UnitID     -- Đơn vị ĐÍCH (Kho/Chi phí)
            WHERE 
                OI.OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    // Xử lý trường hợp DB trả về NULL nếu không có OrderItems
                    if (result != DBNull.Value && result != null)
                    {
                        totalCOGS = Convert.ToDecimal(result);
                    }
                }
            }
            return totalCOGS;
        }
        /// <summary>
        /// Lấy Bảng tổng hợp Doanh thu, COGS và Lợi nhuận gộp theo tháng trong năm.
        /// </summary>
        public DataTable GetProfitAndRevenueByYear(int year)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                MONTH(OrderTime) AS OrderMonth, 
                SUM(TotalAmount) AS MonthlyRevenue,
                SUM(TotalCOGS) AS MonthlyCOGS,
                SUM(TotalAmount) - SUM(TotalCOGS) AS MonthlyProfit -- Lợi nhuận gộp
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
        /// <summary>
        /// Lấy Bảng tổng hợp Doanh thu và Lợi nhuận theo tháng trong năm.
        /// </summary>
        public DataTable GetProfitAndRevenueByMonth(int year)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        MONTH(OrderTime) AS OrderMonth, 
                        SUM(TotalAmount) AS MonthlyRevenue,
                        SUM(TotalCOGS) AS MonthlyCOGS,
                        SUM(TotalAmount) - SUM(TotalCOGS) AS MonthlyProfit -- Lợi nhuận tính trực tiếp trên DB
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
