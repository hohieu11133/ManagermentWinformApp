using SocialMediaDashboardDesign.DAL;
using System;
using System.Data;

namespace SocialMediaDashboardDesign.BLL
{
    public class RevenueBLL
    {
        private readonly RevenueDAL revenueDAL;

        public RevenueBLL()
        {
            revenueDAL = new RevenueDAL();
        }

        // Lấy doanh thu năm
        public decimal GetYearlyRevenue(int year)
        {
            if (year <= 0)
                throw new ArgumentException("Năm không hợp lệ");

            return revenueDAL.GetYearlyRevenue(year);
        }

        // Lấy doanh thu tháng
        public decimal GetMonthlyRevenue(int year, int month)
        {
            if (year <= 0 || month < 1 || month > 12)
                throw new ArgumentException("Tháng/Năm không hợp lệ");

            return revenueDAL.GetMonthlyRevenue(year, month);
        }
        public DataTable GetRevenueByMonthInYear(int year)
        {
            return revenueDAL.GetRevenueByMonthInYear(year);
        }

        public DataTable GetRevenueByDayInMonth(int year, int month)
        {
            return revenueDAL.GetRevenueByDayInMonth(year, month);
        }
        /// <summary>
        /// Lấy tổng lợi nhuận gộp của năm bằng cách gọi DAL.
        /// </summary>
        public decimal GetYearlyProfit(int year)
        {
            // Hàm này gọi GetYearlyProfit() trong RevenueDAL 
            // (Hàm này thực hiện Doanh thu - COGS)
            return revenueDAL.GetYearlyProfit(year);
        }
        public decimal GetMonthlyCOGS(int year, int month)
        {
            // BLL chuyển tiếp yêu cầu đến DAL để thực hiện truy vấn tổng COGS
            return revenueDAL.GetMonthlyCOGS(year, month);
        }
        public DataTable GetProfitAndRevenueByYear(int year)
        {
            // BLL chuyển tiếp yêu cầu đến DAL
            return revenueDAL.GetProfitAndRevenueByYear(year);
        }
        /// <summary>
        /// Lấy tổng lợi nhuận gộp của tháng bằng cách gọi DAL.
        /// </summary>
        public decimal GetMonthlyProfit(int year, int month)
        {
            // Hàm này gọi GetMonthlyProfit() trong RevenueDAL 
            // (Hàm này thực hiện Doanh thu - COGS)
            return revenueDAL.GetMonthlyProfit(year, month);
        }

        // Bạn có thể thêm hàm này nếu muốn sử dụng cho biểu đồ/báo cáo tổng hợp:
        public DataTable GetProfitAndRevenueByMonth(int year)
        {
            return revenueDAL.GetProfitAndRevenueByMonth(year);
        }
        /// <summary>
        /// Tính tổng Lợi nhuận theo tháng cho mục đích báo cáo.
        /// </summary>
        public DataTable GetProfitByMonthInYear(int year)
        {
            DataTable revenueData = revenueDAL.GetRevenueByMonthInYear(year);
            DataTable profitDt = new DataTable();

            // Thêm các cột cần thiết cho bảng Lợi nhuận
            profitDt.Columns.Add("OrderMonth", typeof(int));
            profitDt.Columns.Add("MonthlyRevenue", typeof(decimal));
            profitDt.Columns.Add("MonthlyCOGS", typeof(decimal)); // Cần tính toán
            profitDt.Columns.Add("MonthlyProfit", typeof(decimal));

            // ...
            // BƯỚC NÀY RẤT PHỨC TẠP VÌ: 
            // 1. Bạn phải lấy COGS của TẤT CẢ các đơn hàng Completed trong tháng đó.
            // 2. Không có cách dễ dàng để tính tổng COGS theo tháng bằng một truy vấn đơn giản.
            // Lời khuyên: Để dễ dàng hơn, hãy tính Lợi nhuận trên một Order cụ thể.
            // ...

            return profitDt;
        }

        /// <summary>
        /// Tính Lợi nhuận của một đơn hàng cụ thể.
        /// </summary>
        /// <param name="orderId">ID của đơn hàng.</param>
        /// <param name="totalRevenue">Tổng doanh thu (TotalAmount) của đơn hàng.</param>
        /// <returns>Lợi nhuận gộp của đơn hàng.</returns>
        public decimal CalculateOrderProfit(int orderId, decimal totalRevenue)
        {
            decimal cogs = revenueDAL.GetOrderCOGS(orderId);

            // Lợi nhuận = Doanh thu - Giá vốn
            return totalRevenue - cogs;
        }

    }
}
