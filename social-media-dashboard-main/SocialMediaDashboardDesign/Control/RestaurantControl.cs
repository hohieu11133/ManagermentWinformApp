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
    public partial class RestaurantControl : UserControl
    {
        private TableBLL tableBLL;

        public RestaurantControl()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
        }

        private void RestaurantControl_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private int selectedTableId = -1;
        private string selectedTableNumber = "";

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
                    // Lưu bàn được chọn
                    selectedTableId = tableId;
                    selectedTableNumber = tableNumber;
                    lblSelectedTable.Text = $"Selected: {tableNumber}";
                };

                tablesFlowPanel.Controls.Add(btn);
            }
        }


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
    

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void tablePanel_Click(object sender, EventArgs e)
        {

        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            OrderControl orderCtrl = new OrderControl();
            //  Sửa ở đây: Bỏ tham số thứ ba (false)
            orderCtrl.LoadTableInfo(selectedTableId, selectedTableNumber);

            // Phần còn lại giữ nguyên
            Panel parentPanel = this.Parent as Panel; // Tối ưu: Dùng this.Parent để linh hoạt hơn
            if (parentPanel != null)
            {
                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(orderCtrl);
                orderCtrl.Dock = DockStyle.Fill;
            }
        }
        private void btnTakeOrder_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            OrderControl orderCtrl = new OrderControl();
            //  Sửa
            orderCtrl.LoadTableInfo(selectedTableId, selectedTableNumber);

            // Phần còn lại giữ nguyên
            Panel parentPanel = this.Parent as Panel;
            if (parentPanel != null)
            {
                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(orderCtrl);
                orderCtrl.Dock = DockStyle.Fill;
            }
        }

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
                    // Sau khi thanh toán thì update bàn sang Available
                    tableBLL.UpdateTableStatus(selectedTableId, "Cleaning");
                    LoadTables();
                }
            }
        }


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

                // TRƯỜNG HỢP 1: Bàn đang trống -> Chuyển thành Đặt trước
                if (currentStatus.Equals("Available", StringComparison.OrdinalIgnoreCase))
                {
                    tableBLL.UpdateTableStatus(selectedTableId, "Reserved");
                    LoadTables(); // Tải lại giao diện để cập nhật màu sắc
                    MessageBox.Show($"Bàn {selectedTableNumber} đã được đặt trước!");
                }
                // ✅ TRƯỜNG HỢP 2 (MỚI): Bàn đã đặt trước -> Chuyển thành Có khách
                else if (currentStatus.Equals("Reserved", StringComparison.OrdinalIgnoreCase))
                {
                    tableBLL.UpdateTableStatus(selectedTableId, "Occupied");
                    LoadTables(); // Tải lại giao diện để cập nhật màu sắc
                    MessageBox.Show($"Khách đã đến! Bàn {selectedTableNumber} đã chuyển sang trạng thái có khách.");
                }
                // TRƯỜNG HỢP 3: Các trạng thái khác (Có khách, Đang dọn)
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



        private void updateTimer_Tick(object sender, EventArgs e)
        {

        }

        private void tablesFlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tablesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSelectedTable_Click(object sender, EventArgs e)
        {

        }
    }
}