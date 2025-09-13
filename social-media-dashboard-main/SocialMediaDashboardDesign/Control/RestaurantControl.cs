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
                default: return Color.LightGray;
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

            // Tạo OrderControl và gửi thông tin bàn
            OrderControl orderCtrl = new OrderControl();
            orderCtrl.LoadTableInfo(selectedTableId, selectedTableNumber);

            // Thay thế UserControl hiện tại bằng OrderControl
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(orderCtrl);
            orderCtrl.Dock = DockStyle.Fill;
        }


        private void btnTakeOrder_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            OrderControl orderCtrl = new OrderControl();
            orderCtrl.LoadTableInfo(selectedTableId, selectedTableNumber);
            // Thay thế UserControl hiện tại bằng OrderControl
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(orderCtrl);
            orderCtrl.Dock = DockStyle.Fill;
        
        }


        private void btnBillPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnCleanTable_Click(object sender, EventArgs e)
        {

        }

        private void btnReserveTable_Click(object sender, EventArgs e)
        {

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