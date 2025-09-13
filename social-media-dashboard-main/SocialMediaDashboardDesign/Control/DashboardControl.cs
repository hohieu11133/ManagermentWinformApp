using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration; // Để đọc connectionString từ App.config

namespace SocialMediaDashboardDesign
{
    public partial class DashboardControl : UserControl
    {
        private string connectionString;

        private int selectedYear = DateTime.Now.Year; // Năm mặc định
        private int selectedMonth = DateTime.Now.Month; // Tháng mặc định

        public DashboardControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string not found in App.config!");
            }
            LoadCharts();
            // Gán sự kiện click cho sataBarChart1
            this.sataBarChart1.Click += new System.EventHandler(this.sataBarChart1_Click);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý gì đặc biệt
        }

        private void sataBarChart1_Load(object sender, EventArgs e)
        {
            LoadCharts();
        }

        private void sataLineChart1_Load(object sender, EventArgs e)
        {
            LoadCharts();
        }
        private void sataLineChart1_Load_1(object sender, EventArgs e)
        {

        }
        private void LoadCharts()
        {
            LoadBarChart();
            LoadLineChart();
        }

        private void LoadBarChart()
        {
            try
            {
                List<string> monthLabels = new List<string>();
                List<float> monthlyRevenueData = new List<float>();
                Dictionary<int, decimal> monthlyRevenue = new Dictionary<int, decimal>(); // Key: MM (1-12)

                // Tạo nhãn tháng
                for (int i = 1; i <= 12; i++)
                {
                    monthLabels.Add(new DateTime(selectedYear, i, 1).ToString("MMM")); // "Jan", "Feb", etc.
                }

                // Truy vấn dữ liệu tháng từ DB cho năm được chọn
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            MONTH(OrderTime) AS OrderMonth,
                            SUM(TotalAmount) AS MonthlyTotal
                        FROM [RestaurantManagementDB].[dbo].[Orders]
                        WHERE Status = 'Completed'
                            AND YEAR(OrderTime) = @Year
                        GROUP BY MONTH(OrderTime)
                        ORDER BY OrderMonth;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Year", selectedYear);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int month = reader.GetInt32(0);
                                decimal total = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                                monthlyRevenue[month] = total;
                            }
                        }
                    }
                }

                // Gán giá trị cho từng tháng
                for (int i = 1; i <= 12; i++)
                {
                    decimal revenue = monthlyRevenue.ContainsKey(i) ? monthlyRevenue[i] : 0;
                    monthlyRevenueData.Add((float)revenue);
                }

                this.sataBarChart1.CustomXAxis = monthLabels.ToArray();
                this.sataBarChart1.DataPoints = monthlyRevenueData.ToArray();
                float maxMonthlyRevenue = monthlyRevenueData.Max();
                this.sataBarChart1.MaxValue = maxMonthlyRevenue > 0 ? maxMonthlyRevenue * 1.1f : 75f;
                this.sataBarChart1.BarColor = System.Drawing.Color.FromArgb(8, 79, 165);
                this.sataBarChart1.RoundedBars = true;
                this.sataBarChart1.BarSpacing = 10;
                this.sataBarChart1.AutoMaxValue = false;
                this.sataBarChart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bar chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLineChartOnly()
        {
            LoadLineChart();
        }

        private void LoadLineChart()
        {
            try
            {
                int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
                List<string> dayLabels = new List<string>();
                List<float> dailyRevenueData = new List<float>();
                Dictionary<int, decimal> dailyRevenue = new Dictionary<int, decimal>(); // Key: Ngày (1-31)

                for (int day = 1; day <= daysInMonth; day++)
                {
                    dayLabels.Add(day.ToString());
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            DAY(OrderTime) AS OrderDay,
                            SUM(TotalAmount) AS DailyTotal
                        FROM [RestaurantManagementDB].[dbo].[Orders]
                        WHERE Status = 'Completed'
                            AND MONTH(OrderTime) = @Month
                            AND YEAR(OrderTime) = @Year
                        GROUP BY DAY(OrderTime)
                        ORDER BY OrderDay;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Month", selectedMonth);
                        cmd.Parameters.AddWithValue("@Year", selectedYear);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int day = reader.GetInt32(0);
                                decimal total = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                                dailyRevenue[day] = total;
                            }
                        }
                    }
                }

                for (int day = 1; day <= daysInMonth; day++)
                {
                    decimal revenue = dailyRevenue.ContainsKey(day) ? dailyRevenue[day] : 0;
                    dailyRevenueData.Add((float)revenue);
                }

                this.sataLineChart1.CustomXAxis = dayLabels.ToArray();
                this.sataLineChart1.DataPoints = dailyRevenueData.ToArray();
                float maxDailyRevenue = dailyRevenueData.Max();
                this.sataLineChart1.MaxValue = maxDailyRevenue > 0 ? maxDailyRevenue * 1.1f : 150f;
                this.sataLineChart1.ChartLineColor = System.Drawing.Color.FromArgb(8, 79, 165);
                this.sataLineChart1.PointColor = System.Drawing.Color.FromArgb(8, 79, 165);
                this.sataLineChart1.GradientBackground = true;
                this.sataLineChart1.UseBezier = true;
                this.sataLineChart1.ShortDates = true;
                this.sataLineChart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading line chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sataPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void sataBarChart1_Click(object sender, EventArgs e)
        {
          
        }


        private void YearcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra null để tránh lỗi nếu control không tồn tại
            if (YearcomboBox != null && YearcomboBox.SelectedItem != null)
            {
                selectedYear = int.Parse(YearcomboBox.SelectedItem.ToString());
                LoadCharts(); // Cập nhật cả hai chart
            }
            else
            {
                MessageBox.Show("YearcomboBox is not initialized or has no selected item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MonthcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MonthcomboBox != null && MonthcomboBox.SelectedItem != null)
            {
                selectedMonth = MonthcomboBox.SelectedIndex + 1; // 1-based index
                LoadLineChartOnly(); // Chỉ cập nhật sataLineChart1
            }
            else
            {
                MessageBox.Show("MonthcomboBox is not initialized or has no selected item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
