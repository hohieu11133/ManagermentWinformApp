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
    public partial class Form1 : Form
    {
        public Form1()
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
            LoadUserControl(new OrderControl());
        }
        private void menuMenu_Click(object sender, EventArgs e)
        {
            LoadUserControl(new MenuControl());
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

        private void sataButton20_Click(object sender, EventArgs e)
        {
      
        }
    }
}
