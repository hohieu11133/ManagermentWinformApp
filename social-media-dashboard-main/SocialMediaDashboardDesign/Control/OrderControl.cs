using SocialMediaDashboardDesign.BLL;
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
    public partial class OrderControl : UserControl
    {
        private MenuBLL menuBLL;
        private OrderBLL orderBLL;
        private int currentOrderId;

        public OrderControl()
        {
            InitializeComponent();
            menuBLL = new MenuBLL();
            orderBLL = new OrderBLL();
        }

        private void OrderControl_Load(object sender, EventArgs e)
        {
            LoadMenuItemsToOrder();
            LoadCategoriesForFilter();
        }

        private void LoadMenuItemsToOrder(string keyword = "", int? categoryId = null)
        {
            menuListView.Items.Clear();

            DataTable dt = menuBLL.SearchMenuItems(keyword, categoryId);

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Name"].ToString());
                item.SubItems.Add(row["Category"].ToString());
                item.SubItems.Add(row["Price"].ToString());
                item.SubItems.Add("1"); // mặc định quantity 1
                item.Tag = row["MenuItemID"];
                menuListView.Items.Add(item);
            }
        }

        private void LoadCategoriesForFilter()
        {
            DataTable dt = menuBLL.GetCategories();

            // thêm option "All"
            DataRow allRow = dt.NewRow();
            allRow["CategoryID"] = 0;
            allRow["Name"] = "All";
            dt.Rows.InsertAt(allRow, 0);

            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "CategoryID";
            categoryComboBox.DataSource = dt;
        }
        public void LoadTableInfo(int tableId, string tableName)
        {
            this.lblTableNumberValue.Text = "Table " + tableName;  // hiển thị tên bàn
            this.lblSelectedTable.Text = "Table: " + tableName;    // header
            this.Tag = tableId; // lưu ID bàn để sau này còn thao tác
            DataTable order = orderBLL.GetOrCreateOrder(tableId);
            currentOrderId = Convert.ToInt32(order.Rows[0]["OrderID"]);
            LoadOrderItems(currentOrderId);   // load các món đã gọi

        }
        private void LoadOrderItems(int orderId)
        {
            OrderGridView.Rows.Clear();
            DataTable dt = orderBLL.GetOrderItems(orderId);

            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = OrderGridView.Rows.Add();
                DataGridViewRow newRow = OrderGridView.Rows[rowIndex];
                newRow.Cells["ItemName"].Value = row["Name"].ToString();
                newRow.Cells["Quantity"].Value = row["Quantity"];
                newRow.Cells["Price"].Value = row["Price"];
                newRow.Cells["Total"].Value = row["Subtotal"];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh order details and menu items
        }

   

        private void btnAddMenuItem_Click(object sender, EventArgs e)
        {
            // Open a form or dialog to add a new menu item
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (menuListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món trong menu!");
                return;
            }

            ListViewItem selectedItem = menuListView.SelectedItems[0];
            string itemName = selectedItem.SubItems[0].Text;
            string category = selectedItem.SubItems[1].Text; // nếu cần
            decimal price = Convert.ToDecimal(selectedItem.SubItems[2].Text);
            int quantity = 1;

            // Kiểm tra xem món này đã có trong OrderGridView chưa
            foreach (DataGridViewRow row in OrderGridView.Rows)
            {
                if (row.Cells["ItemName"].Value != null && row.Cells["ItemName"].Value.ToString() == itemName)
                {
                    int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = currentQty + 1;
                    row.Cells["Total"].Value = (currentQty + 1) * price;
                    return;
                }
            }

            // Nếu chưa có thì thêm mới
            int rowIndex = OrderGridView.Rows.Add();
            DataGridViewRow newRow = OrderGridView.Rows[rowIndex];
            newRow.Cells["ItemName"].Value = itemName;
            newRow.Cells["Quantity"].Value = quantity;
            newRow.Cells["Price"].Value = price;
            newRow.Cells["Total"].Value = price * quantity;
        }
        private DataGridViewRow editingRow = null;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == OrderGridView.Columns["Editbtn"].Index)
            {
                editingRow = OrderGridView.Rows[e.RowIndex];

                // Chỉ mở khóa 2 cột Quantity và Price
                OrderGridView.ReadOnly = false;
                foreach (DataGridViewColumn col in OrderGridView.Columns)
                {
                    if (col.Name != "Quantity" && col.Name != "Price")
                        editingRow.Cells[col.Index].ReadOnly = true;
                }

                MessageBox.Show("Bạn có thể sửa Quantity và Price. Sau đó bấm 'Edit Item' để lưu.");
            }
        }

        private void btnEditItem_Click_1(object sender, EventArgs e)
        {
            if (editingRow == null)
            {
                MessageBox.Show("Chưa chọn dòng nào để chỉnh sửa!");
                return;
            }

            try
            {
                // Bắt buộc commit dữ liệu từ ô đang chỉnh sửa
                OrderGridView.EndEdit();

                // Lấy lại dữ liệu vừa chỉnh
                int quantity = Convert.ToInt32(editingRow.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(editingRow.Cells["Price"].Value);

                // Cập nhật Total
                decimal total = quantity * price;
                editingRow.Cells["Total"].Value = total;

                // Khóa lại row sau khi lưu
                OrderGridView.ReadOnly = true;
                editingRow = null;

                MessageBox.Show("Đã lưu chỉnh sửa và cập nhật Total!");
            }
            catch
            {
                MessageBox.Show("Giá trị nhập không hợp lệ. Hãy nhập số hợp lệ cho Quantity và Price.");
            }
        }


        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (OrderGridView.SelectedRows.Count > 0)
            {
                OrderGridView.Rows.RemoveAt(OrderGridView.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món để xóa!");
            }
        }
        private void OrderGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editingRow != null && (e.ColumnIndex == OrderGridView.Columns["Quantity"].Index
                                    || e.ColumnIndex == OrderGridView.Columns["Price"].Index))
            {
                try
                {
                    int quantity = Convert.ToInt32(editingRow.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(editingRow.Cells["Price"].Value);
                    editingRow.Cells["Total"].Value = quantity * price;
                }
                catch
                {
                    // ignore nếu nhập sai, xử lý sau khi nhấn Edit Item
                }
            }
        }

    

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            // Cancel the order
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            // Update order status or refresh data
        }

        private void orderSummaryPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMenuTitle_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void actionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

  


        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            string keyword = txtSearch.Text.Trim();

            if (selectedCategoryId == 0) // All
                LoadMenuItemsToOrder(keyword, null);
            else
                LoadMenuItemsToOrder(keyword, selectedCategoryId);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            string keyword = txtSearch.Text.Trim();

            if (selectedCategoryId == 0) // All
                LoadMenuItemsToOrder(keyword, null);
            else
                LoadMenuItemsToOrder(keyword, selectedCategoryId);
        }

        private void btnConfirmOrder_Click_1(object sender, EventArgs e)
        {

            int tableId = (int)this.Tag; // lấy từ LoadTableInfo
            OrderBLL orderBLL = new OrderBLL();
            var order = orderBLL.GetOrCreateOrder(tableId);

            int orderId = Convert.ToInt32(order.Rows[0]["OrderID"]);

            foreach (DataGridViewRow row in OrderGridView.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["ItemName"].Value.ToString();
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                // lấy menuItemId từ DB theo name
                var menuItem = menuBLL.SearchMenuItems(name, null).Rows[0];
                int menuItemId = Convert.ToInt32(menuItem["MenuItemID"]);

                orderBLL.AddOrderItem(orderId, menuItemId, qty);
            }

            orderBLL.UpdateOrderStatus(orderId, "In Progress");
            MessageBox.Show("Order đã được xác nhận!");
        }

        private void btnCancelOrder_Click_1(object sender, EventArgs e)
        {
            int tableId = (int)this.Tag; // lấy từ LoadTableInfo
            OrderBLL orderBLL = new OrderBLL();
            var order = orderBLL.GetOrCreateOrder(tableId);
            int orderId = Convert.ToInt32(order.Rows[0]["OrderID"]);
            OrderGridView.Rows.Clear();
            orderBLL.UpdateOrderStatus(orderId, "Cancelled");
            MessageBox.Show("Order đã hủy!");
        }
    }
}
