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

namespace SocialMediaDashboardDesign
{
    /// <summary>
    /// UserControl để quản lý giao diện chính của nhà hàng, hiển thị các bàn và cho phép thực hiện các thao tác.
    /// </summary>
    public partial class RestaurantControl : UserControl
    {
        #region Fields

        private TableBLL tableBLL;
        private int selectedTableId = -1;
        private string selectedTableNumber = "";

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor mặc định. Khởi tạo các thành phần và đối tượng BLL cần thiết.
        /// </summary>
        public RestaurantControl()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện Load cho RestaurantControl.
        /// Bắt đầu tải danh sách các bàn khi control được hiển thị lần đầu.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện.</param>
        /// <param name="e">Dữ liệu sự kiện.</param>
        private void RestaurantControl_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        /// <summary>
        /// Xử lý sự kiện click cho nút "Take Order".
        /// Chuyển sang giao diện đặt món cho bàn đã chọn.
        /// </summary>
        private void btnTakeOrder_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            OrderControl orderCtrl = new OrderControl();
            orderCtrl.LoadTableInfo(selectedTableId, selectedTableNumber);

            Panel parentPanel = this.Parent as Panel;
            if (parentPanel != null)
            {
                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(orderCtrl);
                orderCtrl.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click cho nút "View Order".
        /// Chuyển sang giao diện xem/chỉnh sửa order cho bàn đã chọn.
        /// </summary>
        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            OrderControl orderCtrl = new OrderControl();
            orderCtrl.LoadTableInfo(selectedTableId, selectedTableNumber);

            Panel parentPanel = this.Parent as Panel;
            if (parentPanel != null)
            {
                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(orderCtrl);
                orderCtrl.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click cho nút "Bill Payment".
        /// Mở form thanh toán cho bàn đã chọn.
        /// </summary>
        private void btnBillPayment_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            OrderBLL orderBLL = new OrderBLL();
            var order = orderBLL.GetOrCreateOrder(selectedTableId);

            if (order == null || order.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy order cho bàn này!");
                return;
            }

            int orderId = Convert.ToInt32(order.Rows[0]["OrderID"]);

            using (BillForm billForm = new BillForm(orderId))
            {
                if (billForm.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi thanh toán, cập nhật trạng thái bàn thành "Cleaning"
                    tableBLL.UpdateTableStatus(selectedTableId, "Cleaning");
                    LoadTables();
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click cho nút "Reserve Table".
        /// Cho phép đặt bàn nếu bàn đang trống, hoặc xác nhận khách đến nếu bàn đã được đặt.
        /// </summary>
        private void btnReserveTable_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn!");
                return;
            }

            DataRow row = tableBLL.GetTableById(selectedTableId);

            if (row != null)
            {
                string currentStatus = row["Status"].ToString();

                if (currentStatus.Equals("Available", StringComparison.OrdinalIgnoreCase))
                {
                    tableBLL.UpdateTableStatus(selectedTableId, "Reserved");
                    LoadTables();
                    MessageBox.Show($"Bàn {selectedTableNumber} đã được đặt trước!");
                }
                else if (currentStatus.Equals("Reserved", StringComparison.OrdinalIgnoreCase))
                {
                    tableBLL.UpdateTableStatus(selectedTableId, "Occupied");
                    LoadTables();
                    MessageBox.Show($"Khách đã đến! Bàn {selectedTableNumber} đã chuyển sang trạng thái có khách.");
                }
                else
                {
                    MessageBox.Show($"Không thể thực hiện thao tác này. Bàn đang ở trạng thái '{currentStatus}'.");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin bàn!");
            }
        }

        /// <summary>
        /// Xử lý sự kiện click cho nút "Clean Table".
        /// Chuyển trạng thái bàn từ "Cleaning" sang "Available".
        /// </summary>
        private void btnCleanTable_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn!");
                return;
            }

            DataRow row = tableBLL.GetTableById(selectedTableId);

            if (row != null)
            {
                string currentStatus = row["Status"].ToString();

                if (currentStatus.Equals("Cleaning", StringComparison.OrdinalIgnoreCase))
                {
                    tableBLL.UpdateTableStatus(selectedTableId, "Available");
                    LoadTables();
                    MessageBox.Show("Bàn đã được làm sạch, chuyển sang Available!");
                }
                else
                {
                    MessageBox.Show("Chỉ bàn ở trạng thái Cleaning mới chuyển sang Available!");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy bàn!");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Tải và hiển thị tất cả các bàn từ cơ sở dữ liệu lên FlowLayoutPanel.
        /// </summary>
        private void LoadTables()
        {
            tablesFlowPanel.Controls.Clear();
            DataTable dt = tableBLL.GetAllTables();

            foreach (DataRow row in dt.Rows)
            {
                int tableId = Convert.ToInt32(row["TableID"]);
                string tableNumber = row["TableNumber"].ToString();
                string status = row["Status"].ToString();

                Button btn = new Button();
                btn.Text = tableNumber;
                btn.Tag = new { TableID = tableId, TableNumber = tableNumber };
                btn.Width = 100;
                btn.Height = 60;
                btn.Margin = new Padding(10);
                btn.BackColor = GetColorByStatus(status);

                btn.Click += (s, e) =>
                {
                    // Lưu thông tin bàn được chọn
                    selectedTableId = tableId;
                    selectedTableNumber = tableNumber;
                    lblSelectedTable.Text = $"Selected: {tableNumber}";
                };

                tablesFlowPanel.Controls.Add(btn);
            }
        }

        /// <summary>
        /// Trả về một màu sắc dựa trên trạng thái của bàn.
        /// </summary>
        /// <param name="status">Chuỗi trạng thái của bàn (ví dụ: "Available", "Occupied").</param>
        /// <returns>Đối tượng Color tương ứng.</returns>
        private Color GetColorByStatus(string status)
        {
            switch (status.ToLower())
            {
                case "available": return Color.LightGreen;
                case "occupied": return Color.IndianRed;
                case "reserved": return Color.Orange;
                case "cleaning": return Color.LightGray;
                default: return Color.LightGreen;
            }
        }

        #endregion

        #region Empty Handlers for Designer
        // Các phương thức này được giữ lại để tương thích với file designer.
        private void btnRefresh_Click(object sender, EventArgs e) { }
        private void tablePanel_Click(object sender, EventArgs e) { }
        private void updateTimer_Tick(object sender, EventArgs e) { }
        private void tablesFlowPanel_Paint(object sender, PaintEventArgs e) { }
        private void tablesPanel_Paint(object sender, PaintEventArgs e) { }
        private void lblSelectedTable_Click(object sender, EventArgs e) { }
        #endregion
    }
}