using SocialMediaDashboardDesign.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign
{
    public partial class MenuControl : UserControl
    {
        private MenuBLL menuBLL;

        public MenuControl()
        {
            InitializeComponent();
            menuBLL = new MenuBLL();
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {
            LoadCategories();        // cho filter (categoryComboBox, có "All")
            LoadCategoriesForEdit(); // cho Add/Edit (comboBox1, không có "All")
            categoryComboBox.SelectedIndex = 0;
            LoadMenuItems();
        }

        private void LoadCategories()
        {
            DataTable dt = menuBLL.GetCategories(); // gọi BLL thay vì DAL

            // Thêm dòng "All"
            DataRow allRow = dt.NewRow();
            allRow["CategoryID"] = 0;
            allRow["Name"] = "All";
            dt.Rows.InsertAt(allRow, 0);

            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "CategoryID";
            categoryComboBox.DataSource = dt;
        }

        private void LoadCategoriesForEdit()
        {
            DataTable dt = menuBLL.GetCategories();

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DataSource = dt;
        }

        private void LoadMenuItems()
        {
            menuItemsListView.Items.Clear();
            DataTable dt = menuBLL.GetMenuItems();

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

        private void FilterMenuItems()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Search items...")
                keyword = "";

            int? categoryId = null;
            if (categoryComboBox.SelectedIndex > 0)
                categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            DataTable dt = menuBLL.SearchMenuItems(keyword, categoryId);

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
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search items...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Search items...")
            {
                FilterMenuItems();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterMenuItems();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FilterMenuItems();
        }
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterMenuItems();
        }

        private void menuItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);
                DataRow row = menuBLL.GetMenuItemById(id);

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
                        pictureBox1.ImageLocation = imageUrl;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.holderpic;
                        pictureBox1.ImageLocation = null;
                    }
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                decimal price = decimal.Parse(txtPrice.Text.Trim());
                bool isAvailable = txtAvailability.Text.Trim().ToLower() == "available";
                string imageUrl = (pictureBox1.Image != null && pictureBox1.ImageLocation != null)
                                    ? pictureBox1.ImageLocation
                                    : null;

                if (menuBLL.AddMenuItem(name, categoryId, price, isAvailable, imageUrl))
                {
                    MessageBox.Show("Item added successfully!");
                    LoadMenuItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);
                    string name = txtName.Text.Trim();
                    int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                    decimal price = decimal.Parse(txtPrice.Text.Trim());
                    bool isAvailable = txtAvailability.Text.Trim().ToLower() == "available";
                    string imageUrl = (pictureBox1.Image != null && pictureBox1.ImageLocation != null)
                                        ? pictureBox1.ImageLocation
                                        : null;

                    if (menuBLL.UpdateMenuItem(id, name, categoryId, price, isAvailable, imageUrl))
                    {
                        MessageBox.Show("Item updated successfully!");
                        LoadMenuItems();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);
                if (menuBLL.DeleteMenuItem(id))
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
                if (menuBLL.ToggleAvailability(id))
                {
                    LoadMenuItems();
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            LoadMenuItems();
        }

        private void headerPanel_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void mainPanel_Paint(object sender, PaintEventArgs e) { }
    }
}
