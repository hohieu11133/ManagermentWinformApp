using SocialMediaDashboardDesign.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign.Control
{
    public partial class OrderManagermentControl : UserControl
    {
        private OrderBLL orderBLL;
        public OrderManagermentControl()
        {
            InitializeComponent();
            orderBLL = new OrderBLL();

            this.dgvOrders.AutoGenerateColumns = false;
        }

        private void OrderManagermentControl_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho bộ lọc
            dtpDateFrom.Value = DateTime.Today; // Từ đầu ngày hôm nay
            dtpDateTo.Value = DateTime.Today;   // Đến cuối ngày hôm nay
            cmbStatusFilter.SelectedIndex = 0;  // Chọn "Tất cả"

            // Tải danh sách đơn hàng trong ngày hôm nay khi form được mở
               LoadOrders();

            // Gán sự kiện cho các control
            btnApplyFilters.Click += btnApplyFilters_Click;
            txtSearchBox.KeyDown += txtSearchBox_KeyDown;
        }
        private void LoadOrders()
        {
            try
            {
                // Lấy các giá trị từ bộ lọc
                string searchTerm = txtSearchBox.Text.Trim();
                string status = cmbStatusFilter.SelectedItem != null ? cmbStatusFilter.SelectedItem.ToString() : "All";
                DateTime dateFrom = dtpDateFrom.Value.Date; // Lấy phần ngày, bỏ qua giờ
                DateTime dateTo = dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1); // Lấy đến cuối ngày (23:59:59)

                // Gọi BLL để lấy dữ liệu
                var ordersDataTable = orderBLL.GetOrdersByFilter(searchTerm, status, dateFrom, dateTo);

                // Gán dữ liệu cho DataGridView
                dgvOrders.DataSource = ordersDataTable;

             
                StyleDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StyleDataGridView()
        {
            // --- Liên kết cột Designer với cột dữ liệu ---
            dgvOrders.Columns["colOrderId"].DataPropertyName = "OrderID";
            dgvOrders.Columns["colTableNumber"].DataPropertyName = "TableNumber";
            dgvOrders.Columns["colTotalAmount"].DataPropertyName = "TotalAmount";
            dgvOrders.Columns["colStatus"].DataPropertyName = "Status";
            dgvOrders.Columns["colOrderTime"].DataPropertyName = "OrderTime";

            // --- Thiết lập HeaderText ---
            dgvOrders.Columns["colOrderId"].HeaderText = "Order ID";
            dgvOrders.Columns["colTableNumber"].HeaderText = "Table";
            dgvOrders.Columns["colTotalAmount"].HeaderText = "Total Amount";
            dgvOrders.Columns["colStatus"].HeaderText = "Status";
            dgvOrders.Columns["colOrderTime"].HeaderText = "Time";

            // Định dạng cột tiền tệ
            dgvOrders.Columns["colTotalAmount"].DefaultCellStyle.Format = "N0";
            dgvOrders.Columns["colTotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ✅ Cập nhật logic tô màu theo trạng thái tiếng Anh
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["colStatus"].Value != null)
                {
                    string status = row.Cells["colStatus"].Value.ToString();
                    Color foreColor;
                    switch (status)
                    {
                        case "Completed":
                            foreColor = Color.Green;
                            break;
                        case "Cancelled":
                            foreColor = Color.Red;
                            break;
                        case "In Progress":
                            foreColor = Color.FromArgb(0, 123, 255);
                            break;
                        case "Pending":
                            foreColor = Color.OrangeRed;
                            break;
                        default:
                            foreColor = Color.Black;
                            break;
                    }
                    row.Cells["colStatus"].Style.ForeColor = foreColor;
                    row.Cells["colStatus"].Style.Font = new Font(this.Font, FontStyle.Bold);
                }
            }
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu người dùng bấm vào header của bảng
            if (e.RowIndex < 0)
            {
                return;
            }

            // Chỉ thực hiện khi bấm vào cột có tên là "colActions"
            if (dgvOrders.Columns[e.ColumnIndex].Name == "colActions")
            {
                // Lấy OrderID từ ô "colOrderId" trong cùng một hàng
                int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["colOrderId"].Value);

                // 1. Tạo một thể hiện của OrderControl
                OrderControl orderDetailControl = new OrderControl();

                // 2. Gọi phương thức để tải dữ liệu cho đơn hàng đó
                orderDetailControl.LoadExistingOrder(orderId);

                // 3. Lấy Panel cha đang chứa control này và thực hiện thay thế
                Panel parentPanel = this.Parent as Panel;
                if (parentPanel != null)
                {
                    parentPanel.Controls.Clear();
                    parentPanel.Controls.Add(orderDetailControl);
                    orderDetailControl.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Panel cha để hiển thị chi tiết đơn hàng.", "Lỗi Giao Diện", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void filtersPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
