using SocialMediaDashboardDesign.Control;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Tải DashboardControl làm mặc định
            LoadUserControl(new DashboardControl());
        }

        private void LoadUserControl(UserControl userControl)
        {
            mainPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(userControl);
        }

        private void menuDashboard_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardControl());
        }

       private void menuRestaurant_Click(object sender, EventArgs e)
        {
            LoadUserControl(new RestaurantControl()); // Tạo AnalyticsControl tương tự
        }
        private void menuOrder_Click(object sender, EventArgs e)
        {
            LoadUserControl(new OrderManagermentControl());
        }
        private void menuMenu_Click(object sender, EventArgs e)
        {
            LoadUserControl(new MenuControl());
        }
        private void Inventory_Click(object sender, EventArgs e)
        {
            LoadUserControl(new InventoryManagementControl());

        }

        private void label1_Click(object sender, EventArgs e)
        {
     
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sataButton12_Click(object sender, EventArgs e)
        {

        }

        private void sataButton13_Click(object sender, EventArgs e)
        {

        }

        private void sataButton15_Click(object sender, EventArgs e)
        {

        }

        private void sataButton21_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }



        private void logoutbtn_Click(object sender, EventArgs e)
        {
            // Hiện thông báo xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Mở lại form đăng nhập
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Đóng form chính
                this.Close();
            }
        }

        
    }
}
