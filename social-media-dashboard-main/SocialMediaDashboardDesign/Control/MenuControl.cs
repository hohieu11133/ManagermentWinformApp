using SocialMediaDashboardDesign.DataAccess;
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
    public partial class MenuControl : UserControl
    {
        private MenuDAL menuDAL;

        public MenuControl()
        {
            InitializeComponent();
            menuDAL = new MenuDAL();
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {
            LoadCategories();
            categoryComboBox.SelectedIndex = 0; // mặc định chọn "All"
            LoadMenuItems();
        }

        private void LoadCategories()
        {
            DataTable dt = menuDAL.GetCategories(); // load từ DB

            // Thêm dòng "All" vào DataTable
            DataRow allRow = dt.NewRow();
            allRow["CategoryID"] = 0;   // 0 = đại diện cho "All"
            allRow["Name"] = "All";
            dt.Rows.InsertAt(allRow, 0);  // thêm vào đầu

            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "CategoryID";
            categoryComboBox.DataSource = dt;
        }


        private void LoadMenuItems()
        {
            menuItemsListView.Items.Clear();
            DataTable dt = menuDAL.GetMenuItems();

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Name"].ToString());
                item.SubItems.Add(row["Category"].ToString());
                item.SubItems.Add(row["Price"].ToString());
                item.SubItems.Add((Convert.ToBoolean(row["IsAvailable"]) ? "Available" : "Unavailable"));
                item.Tag = row["MenuItemID"]; // gắn ID để xử lý edit/delete
                menuItemsListView.Items.Add(item);
            }
        }

        private void FilterMenuItems()
        {
            string keyword = txtSearch.Text.Trim();
            int? categoryId = null;

            if (categoryComboBox.SelectedIndex > 0) // 0 = All
                categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            DataTable dt = menuDAL.SearchMenuItems(keyword, categoryId);

            menuItemsListView.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Name"].ToString());
                item.SubItems.Add(row["Category"].ToString());
                item.SubItems.Add(row["Price"].ToString());
                item.SubItems.Add((Convert.ToBoolean(row["IsAvailable"]) ? "Available" : "Unavailable"));
                item.Tag = row["MenuItemID"];
                menuItemsListView.Items.Add(item);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search items...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search items...";
                txtSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Filter menu items based on search text
            if (txtSearch.Text != "Search items...")
            {
                FilterMenuItems();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Trigger search
            FilterMenuItems();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filter menu items based on selected category
            FilterMenuItems();
        }

        private void menuItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);
                DataRow row = menuDAL.GetMenuItemById(id); // DAL viết thêm

                if (row != null)
                {
                    txtName.Text = row["Name"].ToString();
                    comboBox1.SelectedValue = Convert.ToInt32(row["CategoryID"]);
                    txtPrice.Text = row["Price"].ToString();
                    txtAvailability.Text = Convert.ToBoolean(row["IsAvailable"]) ? "Available" : "Unavailable";

                    string imageUrl = row["ImageURL"].ToString();
                    if (!string.IsNullOrEmpty(imageUrl) && System.IO.File.Exists(imageUrl))
                    {
                        pictureBox1.Image = Image.FromFile(imageUrl);
                        pictureBox1.ImageLocation = imageUrl; // giữ đường dẫn để sau này update
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.holderpic;
                        pictureBox1.ImageLocation = null; // không có file ảnh
                    }

                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
            decimal price = decimal.Parse(txtPrice.Text.Trim());
            bool isAvailable = txtAvailability.Text.Trim().ToLower() == "available";
            string imageUrl = (pictureBox1.Image != null && pictureBox1.ImageLocation != null)
                                ? pictureBox1.ImageLocation
                                : null;

            if (menuDAL.AddMenuItem(name, categoryId, price, isAvailable, imageUrl))
            {
                MessageBox.Show("Item added successfully!");
                LoadMenuItems();
            }
            else
            {
                MessageBox.Show("Failed to add item!");
            }
        }


        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);

                string name = txtName.Text.Trim();
                int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                decimal price = decimal.Parse(txtPrice.Text.Trim());
                bool isAvailable = txtAvailability.Text.Trim().ToLower() == "available";
                string imageUrl = (pictureBox1.Image != null && pictureBox1.ImageLocation != null)
                                    ? pictureBox1.ImageLocation
                                    : null;

                if (menuDAL.UpdateMenuItem(id, name, categoryId, price, isAvailable, imageUrl))
                {
                    MessageBox.Show("Item updated successfully!");
                    LoadMenuItems();
                }
                else
                {
                    MessageBox.Show("Failed to update item!");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Open a form to edit the selected menu item
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);
                if (menuDAL.DeleteMenuItem(id))
                {
                    MessageBox.Show("Item deleted successfully!");
                    LoadMenuItems();
                }
            }
        }

        private void btnToggleAvailability_Click(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);
                if (menuDAL.ToggleAvailability(id))
                {
                    LoadMenuItems();
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            // Refresh menu items periodically
            LoadMenuItems();
        }

       
        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}