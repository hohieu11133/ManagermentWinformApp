using SocialMediaDashboardDesign.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign.Control
{
    /// <summary>
    /// UserControl chịu trách nhiệm quản lý danh sách đơn hàng (lọc, tìm kiếm, hiển thị).
    /// </summary>
    public partial class OrderManagermentControl : UserControl
    {
        private OrderBLL orderBLL;

        #region Constructors

        public OrderManagermentControl()
        {
            InitializeComponent();
            orderBLL = new OrderBLL();
            this.dgvOrders.AutoGenerateColumns = false;
        }

        #endregion

        #region Event Handlers

        private void OrderManagermentControl_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho bộ lọc
            dtpDateFrom.Value = DateTime.Today;
            dtpDateTo.Value = DateTime.Today;
            cmbStatusFilter.SelectedIndex = 0; // Chọn "Tất cả"

            // Tải danh sách đơn hàng khi form mở
            LoadOrders();

            // Gán sự kiện cho các control
            btnApplyFilters.Click += btnApplyFilters_Click;
            txtSearchBox.KeyDown += txtSearchBox_KeyDown;
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu click header

            if (dgvOrders.Columns[e.ColumnIndex].Name == "colActions")
            {
                int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["colOrderId"].Value);

                OrderControl orderDetailControl = new OrderControl();
                orderDetailControl.LoadExistingOrder(orderId);

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

        #endregion

        #region Private Methods

        private void LoadOrders()
        {
            try
            {
                string searchTerm = txtSearchBox.Text.Trim();
                string status = cmbStatusFilter.SelectedItem != null ? cmbStatusFilter.SelectedItem.ToString() : "All";
                DateTime dateFrom = dtpDateFrom.Value.Date;
                DateTime dateTo = dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1);

                DataTable ordersDataTable = orderBLL.GetOrdersByFilter(searchTerm, status, dateFrom, dateTo);

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
            dgvOrders.Columns["colOrderId"].DataPropertyName = "OrderID";
            dgvOrders.Columns["colTableNumber"].DataPropertyName = "TableNumber";
            dgvOrders.Columns["colTotalAmount"].DataPropertyName = "TotalAmount";
            dgvOrders.Columns["colStatus"].DataPropertyName = "Status";
            dgvOrders.Columns["colOrderTime"].DataPropertyName = "OrderTime";

            dgvOrders.Columns["colOrderId"].HeaderText = "Order ID";
            dgvOrders.Columns["colTableNumber"].HeaderText = "Table";
            dgvOrders.Columns["colTotalAmount"].HeaderText = "Total Amount";
            dgvOrders.Columns["colStatus"].HeaderText = "Status";
            dgvOrders.Columns["colOrderTime"].HeaderText = "Time";

            dgvOrders.Columns["colTotalAmount"].DefaultCellStyle.Format = "N0";
            dgvOrders.Columns["colTotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        #endregion

        #region Empty Handlers for Designer
        private void filtersPanel_Paint(object sender, PaintEventArgs e) { }
        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e) { }
        #endregion
    }
}
