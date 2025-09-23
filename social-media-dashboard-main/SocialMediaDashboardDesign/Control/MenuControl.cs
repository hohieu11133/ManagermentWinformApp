using SocialMediaDashboardDesign.BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign
{
    public partial class MenuControl : UserControl
    {
        private readonly MenuBLL menuBLL;

        #region --- Constructor & Load Events ---

        public MenuControl()
        {
            InitializeComponent();
            menuBLL = new MenuBLL();
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadCategoriesForEdit();
            LoadMenuItems();
            if (categoryComboBox.Items.Count > 0)
            {
                categoryComboBox.SelectedIndex = 0;
            }
        }

        #endregion

        #region --- Data Loading and Filtering ---

        private void LoadCategories()
        {
            DataTable dt = menuBLL.GetCategories();
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
            PopulateListView(dt);
        }

        private void FilterMenuItems()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Search items...")
            {
                keyword = "";
            }

            int? categoryId = null;
            if (categoryComboBox.SelectedIndex > 0)
            {
                categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            }

            DataTable dt = menuBLL.SearchMenuItems(keyword, categoryId);
            menuItemsListView.Items.Clear();
            PopulateListView(dt);
        }

        /// <summary>
        /// Helper method to populate the ListView from a DataTable.
        /// </summary>
        private void PopulateListView(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Name"].ToString());
                item.SubItems.Add(row["Category"].ToString());
                item.SubItems.Add(Convert.ToDecimal(row["Price"]).ToString("N0"));
                item.SubItems.Add(Convert.ToBoolean(row["IsAvailable"]) ? "Available" : "Unavailable");
                item.Tag = row["MenuItemID"];
                menuItemsListView.Items.Add(item);
            }
        }

        #endregion

        #region --- UI Event Handlers (Filter & Selection) ---

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
            if (txtSearch.Focused && txtSearch.Text != "Search items...")
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
            txtSearch.Text = "Search items...";
            txtSearch.ForeColor = Color.Gray;
            categoryComboBox.SelectedIndex = 0;
            LoadMenuItems();
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
                    txtPrice.Text = Convert.ToDecimal(row["Price"]).ToString();
                    txtAvailability.Text = Convert.ToBoolean(row["IsAvailable"]) ? "Available" : "Unavailable";

                    string imageUrl = row["ImageURL"].ToString();
                    if (!string.IsNullOrEmpty(imageUrl) && File.Exists(imageUrl))
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

        #endregion

        #region --- CRUD Button Events ---

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn ảnh cho món ăn";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string appPath = Application.StartupPath;
                        string destFolder = Path.Combine(appPath, "Images");

                        if (!Directory.Exists(destFolder))
                        {
                            Directory.CreateDirectory(destFolder);
                        }

                        string sourceFile = ofd.FileName;
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(sourceFile);
                        string destFile = Path.Combine(destFolder, uniqueFileName);

                        File.Copy(sourceFile, destFile);

                        pictureBox1.Image = Image.FromFile(destFile);
                        pictureBox1.ImageLocation = destFile;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xử lý ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                bool isAvailable = txtAvailability.Text.Trim().Equals("Available", StringComparison.OrdinalIgnoreCase);
                string imageUrl = pictureBox1.ImageLocation;

                if (menuBLL.AddMenuItem(name, categoryId, price, isAvailable, imageUrl))
                {
                    MessageBox.Show("Thêm món thành công!");
                    LoadMenuItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message);
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
                    bool isAvailable = txtAvailability.Text.Trim().Equals("Available", StringComparison.OrdinalIgnoreCase);
                    string imageUrl = pictureBox1.ImageLocation;

                    if (menuBLL.UpdateMenuItem(id, name, categoryId, price, isAvailable, imageUrl))
                    {
                        MessageBox.Show("Cập nhật món thành công!");
                        LoadMenuItems();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để sửa.");
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (menuItemsListView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(menuItemsListView.SelectedItems[0].Tag);
                string name = menuItemsListView.SelectedItems[0].Text;

                var result = MessageBox.Show($"Bạn có chắc muốn xóa '{name}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (menuBLL.DeleteMenuItem(id))
                    {
                        MessageBox.Show("Xóa món thành công!");
                        LoadMenuItems();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để xóa.");
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
            else
            {
                MessageBox.Show("Vui lòng chọn một món để đổi trạng thái.");
            }
        }

        #endregion

        #region --- Empty Event Handlers for Designer ---

        private void updateTimer_Tick(object sender, EventArgs e) { }
        private void headerPanel_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void mainPanel_Paint(object sender, PaintEventArgs e) { }
        private void menuItemsPanel_Paint(object sender, PaintEventArgs e) { }

        #endregion
    }
}