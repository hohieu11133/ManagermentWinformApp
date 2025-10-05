using iTextSharp.text;
using iTextSharp.text.pdf;
using SocialMediaDashboardDesign.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign
{
    public partial class DashboardControl : UserControl
    {
        // ====== Các biến toàn cục ======
        private string connectionString;
        private RevenueBLL revenueBLL;
        private int selectedYear = DateTime.Now.Year;    // Năm mặc định
        private int selectedMonth = DateTime.Now.Month; // Tháng mặc định

        public DashboardControl()
        {
            InitializeComponent();

            // Khởi tạo lớp nghiệp vụ (BLL)
            revenueBLL = new RevenueBLL();

            // Lấy connectionString từ App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string not found in App.config!");
            }

            // Load dữ liệu biểu đồ ban đầu
            LoadCharts();

            // Gán sự kiện click cho biểu đồ Bar
            this.sataBarChart1.Click += new System.EventHandler(this.sataBarChart1_Click);

            
        }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void sataPanel5_Paint(object sender, PaintEventArgs e) { }
        private void sataBarChart1_Click(object sender, EventArgs e) { }
        private void sataLineChart1_Load_1(object sender, EventArgs e) { }

        // Load BarChart khi control được load
        private void sataBarChart1_Load(object sender, EventArgs e)
        {
            LoadCharts();
        }

        // Load LineChart khi control được load
        private void sataLineChart1_Load(object sender, EventArgs e)
        {
            LoadCharts();
        }

        // ====== Hàm load cả 2 biểu đồ ======
        private void LoadCharts()
        {
            LoadBarChart();
            LoadLineChart();

            UpdateRevenueAndProfitLabels();
        }

        // Chỉ load LineChart (khi đổi tháng)
        private void LoadLineChartOnly()
        {
            LoadLineChart();

            UpdateRevenueAndProfitLabels();
        }

        // ====== Xử lý khi chọn Năm ======
        private void YearcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YearcomboBox != null && YearcomboBox.SelectedItem != null)
            {
                selectedYear = int.Parse(YearcomboBox.SelectedItem.ToString());
                LoadCharts(); // Cập nhật cả Bar và Line chart
            }
            else
            {
                MessageBox.Show("YearcomboBox is not initialized or has no selected item.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== Xử lý khi chọn Tháng ======
        private void MonthcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MonthcomboBox != null && MonthcomboBox.SelectedItem != null)
            {
                selectedMonth = MonthcomboBox.SelectedIndex + 1; // Chuyển về 1-based index
                LoadLineChartOnly(); // Chỉ cập nhật Line chart
            }
            else
            {
                MessageBox.Show("MonthcomboBox is not initialized or has no selected item.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== Load dữ liệu cho BarChart (Doanh thu theo tháng) ======
        private void LoadBarChart()
        {
            try
            {
                List<string> monthLabels = new List<string>();
                List<float> monthlyRevenueData = new List<float>();
                Dictionary<int, decimal> monthlyRevenue = new Dictionary<int, decimal>();

                // Tạo nhãn tháng ("Jan", "Feb", ...)
                for (int i = 1; i <= 12; i++)
                {
                    monthLabels.Add(new DateTime(selectedYear, i, 1).ToString("MMM"));
                }

                // Lấy dữ liệu từ BLL
                DataTable dt = revenueBLL.GetRevenueByMonthInYear(selectedYear);
                foreach (DataRow row in dt.Rows)
                {
                    monthlyRevenue[(int)row["OrderMonth"]] = (decimal)row["MonthlyTotal"];
                }

                // Đưa dữ liệu vào mảng, tháng không có doanh thu = 0
                for (int i = 1; i <= 12; i++)
                {
                    decimal revenue = monthlyRevenue.ContainsKey(i) ? monthlyRevenue[i] : 0;
                    monthlyRevenueData.Add((float)revenue);
                }

                // Cập nhật BarChart
                this.sataBarChart1.CustomXAxis = monthLabels.ToArray();
                this.sataBarChart1.DataPoints = monthlyRevenueData.ToArray();
                float maxMonthlyRevenue = monthlyRevenueData.Any() ? monthlyRevenueData.Max() : 0;
                this.sataBarChart1.MaxValue = maxMonthlyRevenue > 0 ? maxMonthlyRevenue * 1.2f : 75f;
                this.sataBarChart1.AutoMaxValue = false;
                this.sataBarChart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bar chart: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== Load dữ liệu cho LineChart (Doanh thu theo ngày trong tháng) ======
        private void LoadLineChart()
        {
            try
            {
                int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
                List<string> dayLabels = new List<string>();
                List<float> dailyRevenueData = new List<float>();
                Dictionary<int, decimal> dailyRevenue = new Dictionary<int, decimal>();

                // Tạo nhãn ngày
                for (int day = 1; day <= daysInMonth; day++)
                {
                    dayLabels.Add(day.ToString());
                }

                // Lấy dữ liệu từ BLL
                DataTable dt = revenueBLL.GetRevenueByDayInMonth(selectedYear, selectedMonth);
                foreach (DataRow row in dt.Rows)
                {
                    dailyRevenue[(int)row["OrderDay"]] = (decimal)row["DailyTotal"];
                }

                // Đưa dữ liệu vào mảng, ngày không có doanh thu = 0
                for (int day = 1; day <= daysInMonth; day++)
                {
                    decimal revenue = dailyRevenue.ContainsKey(day) ? dailyRevenue[day] : 0;
                    dailyRevenueData.Add((float)revenue);
                }

                // Cập nhật LineChart
                this.sataLineChart1.CustomXAxis = dayLabels.ToArray();
                this.sataLineChart1.DataPoints = dailyRevenueData.ToArray();
                float maxDailyRevenue = dailyRevenueData.Any() ? dailyRevenueData.Max() : 0;
                this.sataLineChart1.MaxValue = maxDailyRevenue > 0 ? maxDailyRevenue * 1.2f : 150f;
                this.sataLineChart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading line chart: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ====== Hàm cập nhật Doanh thu và Lợi nhuận ======
        private void UpdateRevenueAndProfitLabels()
        {
            try
            {
                // 1. Lấy dữ liệu
                decimal yearlyRevenue = revenueBLL.GetYearlyRevenue(selectedYear);
                decimal monthlyRevenue = revenueBLL.GetMonthlyRevenue(selectedYear, selectedMonth);
                decimal yearlyProfit = revenueBLL.GetYearlyProfit(selectedYear);
                decimal monthlyProfit = revenueBLL.GetMonthlyProfit(selectedYear, selectedMonth);

                // 2. Cập nhật Nhãn Doanh thu
                // Giả sử label8 hiển thị Doanh thu năm, label9 hiển thị Doanh thu tháng

                // Doanh thu Năm (label8)
                label8.Text = $"{selectedYear}: {yearlyRevenue:N0} $";

                // Doanh thu Tháng (label9)
                label9.Text = $" {selectedMonth}/{selectedYear}: {monthlyRevenue:N0} $";

                // 3. Cập nhật Nhãn Lợi nhuận (Giả sử các label mới của bạn)
                // lblyearprofit: Dùng để hiển thị văn bản "Lợi nhuận gộp năm X"
                // lblnumberyearprofit: Dùng để hiển thị giá trị số

                // Lợi nhuận Năm
                lblyearprofit.Text = $"Lợi nhuận gộp năm {selectedYear}:";
                lblnumberyearprofit.Text = $"{yearlyProfit:N0} $";

                // Lợi nhuận Tháng
                lblmonthprofit.Text = $"Lợi nhuận gộp tháng {selectedMonth}/{selectedYear}:";
                lblnumbermonthprofit.Text = $"{monthlyProfit:N0} $";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật số liệu: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ====== Xuất báo cáo PDF (Đã sửa đổi) ======
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Export Profit Report"; // Đổi tên báo cáo
                saveFileDialog.FileName = $"ProfitReport_{selectedYear}_{selectedMonth}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Lấy TỔNG SỐ LIỆU THÁNG từ BLL
                    // LƯU Ý: Bạn cần đảm bảo đã có hàm GetMonthlyCOGS(year, month) trong RevenueDAL
                    decimal totalRevenue = revenueBLL.GetMonthlyRevenue(selectedYear, selectedMonth);
                    decimal totalCOGS = revenueBLL.GetMonthlyCOGS(selectedYear, selectedMonth); // Lấy COGS
                    decimal totalProfit = totalRevenue - totalCOGS; // Tính Lợi nhuận gộp

                    // Font mặc định của iTextSharp (giữ nguyên, lưu ý: không hỗ trợ tiếng Việt có dấu)
                    iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                    doc.Open();

                    // Tiêu đề
                    Paragraph title = new Paragraph("BAO CAO DOANH THU & LOI NHUAN GÔP", titleFont)
                    { Alignment = Element.ALIGN_CENTER };
                    doc.Add(title);
                    doc.Add(new Paragraph($"Thang: {selectedMonth}/{selectedYear}\n\n", normalFont)
                    { Alignment = Element.ALIGN_CENTER });

                    // Lấy dữ liệu chi tiết doanh thu theo ngày
                    DataTable revenueData = revenueBLL.GetRevenueByDayInMonth(selectedYear, selectedMonth);

                    // -------------------------------------------------------------------
                    // BẢNG CHI TIẾT DOANH THU THEO NGÀY
                    // -------------------------------------------------------------------

                    PdfPTable table = new PdfPTable(3);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1, 2, 2 });

                    // Header bảng
                    table.AddCell(new PdfPCell(new Phrase("Ngay", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("Doanh thu (VND)", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("Ghi chu", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                    // Nội dung bảng (Dùng dữ liệu từ GetRevenueByDayInMonth)
                    foreach (DataRow row in revenueData.Rows)
                    {
                        table.AddCell(new Phrase(row["OrderDay"].ToString(), normalFont));
                        decimal dailyTotal = Convert.ToDecimal(row["DailyTotal"]);
                        table.AddCell(new Phrase(dailyTotal.ToString("N0"), normalFont));
                        table.AddCell(new Phrase("", normalFont));
                    }
                    doc.Add(table);

                    // -------------------------------------------------------------------
                    // PHẦN TỔNG KẾT (THỂ HIỆN DOANH THU, COGS, LỢI NHUẬN)
                    // -------------------------------------------------------------------

                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("TONG KET THANG", titleFont) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph("\n"));


                    // Bảng tổng kết 2 cột (Chỉ số và Giá trị)
                    PdfPTable summaryTable = new PdfPTable(2);
                    summaryTable.WidthPercentage = 50; // Chỉ chiếm 50% chiều rộng
                    summaryTable.HorizontalAlignment = Element.ALIGN_CENTER;
                    summaryTable.SetWidths(new float[] { 2, 1.5f });

                    // Tổng Doanh thu
                    summaryTable.AddCell(new PdfPCell(new Phrase("1. TONG DOANH THU (A):", boldFont)));
                    summaryTable.AddCell(new PdfPCell(new Phrase(totalRevenue.ToString("N0") + " VND", boldFont)));

                    // Tổng COGS
                    summaryTable.AddCell(new PdfPCell(new Phrase("2. TONG GIA VON (COGS) (B):", boldFont)));
                    summaryTable.AddCell(new PdfPCell(new Phrase(totalCOGS.ToString("N0") + " VND", boldFont)));

                    // Tổng Lợi nhuận
                    summaryTable.AddCell(new PdfPCell(new Phrase("3. LOI NHUAN GOP (A - B):", boldFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    summaryTable.AddCell(new PdfPCell(new Phrase(totalProfit.ToString("N0") + " VND", boldFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });


                    doc.Add(summaryTable);

                    doc.Add(new Paragraph($"\nNgay xuat bao cao: {DateTime.Now:dd/MM/yyyy}", normalFont));
                    doc.Close();

                    MessageBox.Show("Export report successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting PDF: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}