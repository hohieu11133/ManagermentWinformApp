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
    }
}
