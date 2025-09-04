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
        public MenuControl()
        {
            InitializeComponent();
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {
            // Initialize the control, load categories and menu items
            categoryComboBox.SelectedIndex = 0; // Select "All" by default
            LoadMenuItems();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh menu items from the database
            LoadMenuItems();
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
            // Enable/disable action buttons based on selection
            bool hasSelection = menuItemsListView.SelectedItems.Count > 0;
            btnEditItem.Enabled = hasSelection;
            btnDeleteItem.Enabled = hasSelection;
            btnToggleAvailability.Enabled = hasSelection;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Open a form to add a new menu item
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            // Open a form to edit the selected menu item
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            // Delete the selected menu item
        }

        private void btnToggleAvailability_Click(object sender, EventArgs e)
        {
            // Toggle the availability of the selected menu item
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            // Refresh menu items periodically
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            // Placeholder: Load menu items from the database
            // Example: menuItemsListView.Items.Clear();
            // Add items with name, category, price, and availability
        }

        private void FilterMenuItems()
        {
            // Placeholder: Filter menu items based on categoryComboBox.SelectedItem and txtSearch.Text
        }
    }
}