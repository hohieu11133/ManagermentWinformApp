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
        private int currentTableId;
        private DataGridViewRow _editingRow = null;
        public OrderControl()
        {
            InitializeComponent();
            menuBLL = new MenuBLL();
            orderBLL = new OrderBLL();

            this.OrderGridView.AutoGenerateColumns = false;
        }

        private void OrderControl_Load(object sender, EventArgs e)
        {
            // Tắt tự động tạo cột cho GridView một lần duy nhất
            this.OrderGridView.AutoGenerateColumns = false;

            // Tải danh sách món và danh mục cho việc lọc
            LoadMenuItemsToOrder();
            LoadCategoriesForFilter();
        }

        #region --- Data Loading and Display ---

        // Tải danh sách món ăn từ Menu lên ListView để người dùng chọn
        private void LoadMenuItemsToOrder(string keyword = "", int? categoryId = null)
        {
            menuListView.Items.Clear();
            DataTable dt = menuBLL.SearchMenuItems(keyword, categoryId);

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Name"].ToString());
                item.SubItems.Add(row["Category"].ToString()); // Giả sử tên cột là Category
                item.SubItems.Add(Convert.ToDecimal(row["Price"]).ToString("N0"));
                item.Tag = row["MenuItemID"]; // Dùng Tag để lưu ID, rất hiệu quả
                menuListView.Items.Add(item);
            }
        }

        // Tải danh sách Category để lọc menu
        private void LoadCategoriesForFilter()
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

        // Được gọi khi chọn một bàn để tạo order mới hoặc xem order cũ
        public void LoadTableInfo(int tableId, string tableName)
        {
            this.lblTableNumberValue.Text = tableName;
            this.lblSelectedTable.Text = tableName;
            this.currentTableId = tableId; // Lưu ID bàn

            // Lấy hoặc tạo order cho bàn, sau đó tải thông tin chi tiết
            DataTable order = orderBLL.GetOrCreateOrder(tableId);
            if (order != null && order.Rows.Count > 0)
            {
                int orderId = Convert.ToInt32(order.Rows[0]["OrderID"]);
                LoadExistingOrder(orderId); // Dùng lại hàm tải order có sẵn
            }
        }

        // Được gọi khi xem một order đã có từ trước (ví dụ từ màn hình quản lý)
        public void LoadExistingOrder(int orderId)
        {
            currentOrderId = orderId; // Lưu lại orderId hiện tại
            try
            {
                // 1. Tải và hiển thị danh sách món ăn đã gọi
                LoadOrderItems(orderId);

                // 2. Tải và hiển thị thông tin tóm tắt
                DataRow summary = orderBLL.GetOrderSummary(orderId);
                if (summary != null)
                {
                    lblOrderIdValue.Text = "#" + summary["OrderID"].ToString();
                    lblTableNumberValue.Text =  summary["TableNumber"].ToString();
                    lblTotalAmountValue.Text = Convert.ToDecimal(summary["TotalAmount"]).ToString("N0") + " VND";
                    lblOrderStatusValue.Text = summary["Status"].ToString();
                    UpdateStatusLabelColor(lblOrderStatusValue.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ TỐI ƯU: Hàm tải danh sách món trong order, luôn dùng DataSource
        private void LoadOrderItems(int orderId)
        {
            try
            {
                DataTable dt = orderBLL.GetOrderItems(orderId);
                OrderGridView.DataSource = dt;

                // Gán thuộc tính DataPropertyName để biết cột nào hiển thị dữ liệu nào
                // Tên trong "" phải khớp với tên cột trả về từ BLL/DAL
                OrderGridView.Columns["MenuItemID"].DataPropertyName = "MenuItemID";
                OrderGridView.Columns["ItemName"].DataPropertyName = "ItemName";
                OrderGridView.Columns["Quantity"].DataPropertyName = "Quantity";
                OrderGridView.Columns["Price"].DataPropertyName = "Price";
                OrderGridView.Columns["Total"].DataPropertyName = "Total";
                UpdateGrandTotal();
                UpdateOrderSummary(); // Cập nhật lại tổng tiền sau khi tải
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách món trong order: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật các label tóm tắt (đặc biệt là tổng tiền)
        private void UpdateOrderSummary()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in OrderGridView.Rows)
            {
                if (row.Cells["Total"].Value != null && row.Cells["Total"].Value != DBNull.Value)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            lblTotalAmountValue.Text = totalAmount.ToString("N0") + " VND";
        }

        #endregion

        #region --- Button Click Events ---

        // Thêm món từ menu vào giỏ hàng (OrderGridView)
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (menuListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một món trong menu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListViewItem selectedItem = menuListView.SelectedItems[0];
            int menuItemId = Convert.ToInt32(selectedItem.Tag);
            string itemName = selectedItem.SubItems[0].Text;
            // Dùng TryParse để an toàn hơn khi chuyển đổi
            decimal.TryParse(selectedItem.SubItems[2].Text.Replace(",", ""), out decimal price);

            // Lấy DataTable từ DataSource
            DataTable dt = OrderGridView.DataSource as DataTable;
            if (dt == null) return; // An toàn nếu DataSource chưa được thiết lập

             foreach (DataRow dataRow in dt.Rows)
            {
                // Kiểm tra xem món này đã có trong DataTable chưa
                if ((int)dataRow["MenuItemID"] == menuItemId)
                {
                    int currentQty = Convert.ToInt32(dataRow["Quantity"]);
                    dataRow["Quantity"] = currentQty + 1; // Sửa dữ liệu gốc
                    dataRow["Total"] = (currentQty + 1) * price; // Cập nhật tổng

                    UpdateOrderSummary();
                    return; // Thoát sau khi cập nhật số lượng
                }
            }

            // Nếu chưa có, logic thêm dòng mới của bạn đã ĐÚNG, giữ nguyên
            DataRow newRow = dt.NewRow();
            newRow["MenuItemID"] = menuItemId;
            newRow["ItemName"] = itemName;
            newRow["Quantity"] = 1;
            newRow["Price"] = price;
            newRow["Total"] = price * 1;
            dt.Rows.Add(newRow);

            UpdateOrderSummary();
        }

        // ✅ TỐI ƯU: Logic xóa món an toàn hơn
        private void btnRemoveItem_Click_1(object sender, EventArgs e)
        {
            if (OrderGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn cần click vào ô ở bên trái ngoài cùng để chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = OrderGridView.SelectedRows[0];
            string itemName = selectedRow.Cells["ItemName"].Value?.ToString();

            // ✅ TỐI ƯU: Lấy ID trực tiếp từ cột ẩn, không query lại DB
            int menuItemId = Convert.ToInt32(selectedRow.Cells["MenuItemID"].Value);

            var result = MessageBox.Show($"Bạn có chắc muốn xóa món '{itemName}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    orderBLL.RemoveOrderItem(currentOrderId, menuItemId);

                    // ✅ AN TOÀN HƠN: Tải lại toàn bộ grid từ DB để đảm bảo đồng bộ
                    LoadOrderItems(currentOrderId);
                    MessageBox.Show("Đã xóa món thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConfirmOrder_Click_1(object sender, EventArgs e)
        {
            if (OrderGridView.Rows.Count == 0)
            {
                MessageBox.Show("Order không có món nào để xác nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy DataTable từ DataSource của GridView
                DataTable currentItems = (DataTable)OrderGridView.DataSource;

                //  GỌI HÀM ĐỒNG BỘ HÓA MỚI
                orderBLL.SyncOrderItems(currentOrderId, currentItems);

                // Cập nhật trạng thái Order và Bàn
                orderBLL.UpdateOrderStatus(currentOrderId, "In Progress");
                orderBLL.UpdateTableStatus(currentTableId, "Occupied");

                MessageBox.Show("Order đã được cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrderItems(currentOrderId); // Tải lại để chắc chắn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận order: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelOrder_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn hủy toàn bộ đơn hàng này?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    orderBLL.UpdateOrderStatus(currentOrderId, "Cancelled");
                    orderBLL.UpdateTableStatus(currentTableId, "Available"); // Chuyển bàn về trống
                    MessageBox.Show("Đơn hàng đã được hủy thành công!");
                    LoadOrderItems(currentOrderId); // Tải lại để thấy order trống
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region --- Filter and Other Events ---

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryComboBox.SelectedValue is int || categoryComboBox.SelectedValue is long)
            {
                int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                string keyword = txtSearch.Text.Trim();
                LoadMenuItemsToOrder(keyword, categoryId == 0 ? (int?)null : categoryId);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (categoryComboBox.SelectedValue is int || categoryComboBox.SelectedValue is long)
            {
                int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                string keyword = txtSearch.Text.Trim();
                LoadMenuItemsToOrder(keyword, categoryId == 0 ? (int?)null : categoryId);
            }
        }

     

        #endregion

        #region --- Empty Event Handlers for Designer ---

        private void UpdateStatusLabelColor(string status)
        {
            switch (status)
            {
                case "Completed": lblOrderStatusValue.ForeColor = Color.Green; break;
                case "Cancelled": lblOrderStatusValue.ForeColor = Color.Red; break;
                case "In Progress": lblOrderStatusValue.ForeColor = Color.Blue; break;
                default: lblOrderStatusValue.ForeColor = Color.OrangeRed; break;
            }
        }
        // ✅ Dán 2 hàm này vào file OrderControl.cs

        /// <summary>
        /// Vòng lặp qua toàn bộ GridView để tính lại tổng tiền và cập nhật Label.
        /// </summary>
        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;
            foreach (DataGridViewRow row in OrderGridView.Rows)
            {
                // Kiểm tra xem ô Total có giá trị hợp lệ không
                if (row.Cells["Total"].Value != null && row.Cells["Total"].Value != DBNull.Value)
                {
                    grandTotal += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            lblTotalAmountValue.Text = grandTotal.ToString("N0") + " VND";
        }

        /// <summary>
        /// Sự kiện này được kích hoạt khi giá trị của một ô trong GridView thay đổi.
        /// </summary>
        private void OrderGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu không có hàng nào được chỉnh sửa hoặc thay đổi xảy ra ở header
            if (e.RowIndex < 0) return;

            // Chỉ thực hiện khi cột "Quantity" thay đổi
            if (OrderGridView.Columns[e.ColumnIndex].Name == "Quantity")
            {
                DataGridViewRow editedRow = OrderGridView.Rows[e.RowIndex];

                try
                {
                    // Lấy giá trị số lượng mới và giá của món
                    int quantity = Convert.ToInt32(editedRow.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(editedRow.Cells["Price"].Value);

                    // Tự động tính toán và cập nhật lại giá trị cho ô "Total"
                    editedRow.Cells["Total"].Value = quantity * price;

                    // Gọi hàm để cập nhật lại tổng tiền của cả đơn hàng
                    UpdateGrandTotal();
                }
                catch (FormatException)
                {
                    // Bỏ qua lỗi nếu người dùng nhập chữ thay vì số, 
                    // lỗi này sẽ được xử lý khi nhấn nút "Edit Item"
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e) { if (currentOrderId > 0) LoadExistingOrder(currentOrderId); }
        // Đây là sự kiện Click của nút btnEditItem
        // Dán code này vào sự kiện click của nút btnEditItem
        private void btnEditItem_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào đang trong chế độ chỉnh sửa không
            if (_editingRow == null)
            {
                MessageBox.Show("Vui lòng bấm nút 'Edit' trên một món hàng trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int menuItemId = Convert.ToInt32(_editingRow.Cells["MenuItemID"].Value);
                int newQuantity = Convert.ToInt32(_editingRow.Cells["Quantity"].Value);

                if (newQuantity <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ LOGIC ĐÚNG: Chỉ cập nhật một món duy nhất
                orderBLL.UpdateOrderItem(currentOrderId, menuItemId, newQuantity);

                // Reset lại trạng thái chỉnh sửa
                _editingRow = null;
                OrderGridView.ReadOnly = true;

                MessageBox.Show("Cập nhật số lượng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật món hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _editingRow = null;
                OrderGridView.ReadOnly = true;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu bấm vào header
            if (e.RowIndex < 0) return;

            // Chỉ thực hiện khi bấm vào cột nút "Editbtn"
            if (OrderGridView.Columns[e.ColumnIndex].Name == "Editbtn")
            {
                // Lưu lại hàng đang được chọn để chỉnh sửa
                _editingRow = OrderGridView.Rows[e.RowIndex];

                // 1. Tạm thời cho phép chỉnh sửa toàn bộ GridView
                OrderGridView.ReadOnly = false;

                // 2. Khóa tất cả các ô trong hàng này...
                foreach (DataGridViewCell cell in _editingRow.Cells)
                {
                    cell.ReadOnly = true;
                }

                // 3. ...ngoại trừ ô "Quantity"
                _editingRow.Cells["Quantity"].ReadOnly = false;

                // 4. Di chuyển con trỏ vào ô Quantity để người dùng sửa ngay
                OrderGridView.CurrentCell = _editingRow.Cells["Quantity"];
                OrderGridView.BeginEdit(true);

                MessageBox.Show("Vui lòng sửa số lượng và nhấn nút 'Edit Item' để lưu.", "Chế độ chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OrderGridView_CellClick(object sender, DataGridViewCellEventArgs e) { }
        private void OrderGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) { }
        private void updateTimer_Tick(object sender, EventArgs e) { }
        private void orderSummaryPanel_Paint(object sender, PaintEventArgs e) { }
        private void lblMenuTitle_Click(object sender, EventArgs e) { }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void mainPanel_Paint(object sender, PaintEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void headerPanel_Paint(object sender, PaintEventArgs e) { }
        private void actionPanel_Paint(object sender, PaintEventArgs e) { }
        private void orderItemsPanel_Paint(object sender, PaintEventArgs e) { }
        #endregion
    }
}