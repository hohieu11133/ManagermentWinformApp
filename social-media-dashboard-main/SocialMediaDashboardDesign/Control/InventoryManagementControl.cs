using SocialMediaDashboardDesign.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign.Control
{
    public partial class InventoryManagementControl : UserControl
    {
        private readonly InventoryBLL inventoryBLL; // Khai báo BLL

        public InventoryManagementControl()
        {
            InitializeComponent();
            inventoryBLL = new InventoryBLL(); // Khởi tạo BLL
            LoadIngredientsData(); // Gọi phương thức tải dữ liệu khi control được khởi tạo
        }

        /// <summary>
        /// Tải dữ liệu Nguyên vật liệu và hiển thị lên DataGridView.
        /// </summary>
        private void LoadIngredientsData()
        {
            try
            {
                // Lấy dữ liệu từ BLL
                DataTable dt = inventoryBLL.LoadInventoryData();

                // Gán nguồn dữ liệu cho DGV
                dgvIngredient.DataSource = dt;

           
         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dgvIngredient_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra: Đảm bảo người dùng click vào CỘT NÚT BẤM
            // Tên cột nút bấm là "colActions" (được khai báo trong Designer)
            if (e.RowIndex >= 0 && dgvIngredient.Columns[e.ColumnIndex].Name == "colActions")
            {
                // 2. Lấy ID của Nguyên vật liệu từ dòng hiện tại
                // Giả sử cột ID là "colIngredientID" hoặc sử dụng tên cột từ DataTable: "IngredientID"

                // Cách an toàn nhất là sử dụng tên cột từ DataTable (IngredientID)
                if (dgvIngredient.Rows[e.RowIndex].Cells["ingredientIDDataGridViewTextBoxColumn"].Value == null)
                {
                    MessageBox.Show("Không tìm thấy ID Nguyên vật liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int ingredientId = (int)dgvIngredient.Rows[e.RowIndex].Cells["ingredientIDDataGridViewTextBoxColumn"].Value;

                // 3. Mở form AddInventoryForm để chỉnh sửa
                OpenAddInventoryForm(ingredientId);

      
            }
        }

        /// <summary>
        /// Mở form AddInventoryForm dưới dạng chỉnh sửa/nhập kho.
        /// </summary>
        private void OpenAddInventoryForm(int ingredientId)
        {
            // Truyền ID vào Constructor của form. 
            // Bạn cần sửa đổi AddInventoryForm để chấp nhận tham số ID này.
            AddInventoryForm editForm = new AddInventoryForm(ingredientId);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Tải lại DataGridView sau khi chỉnh sửa thành công
                LoadIngredientsData();
            }
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form nhập liệu
            AddInventoryForm addForm = new AddInventoryForm();
            // Hiển thị form dưới dạng hộp thoại (modal dialog). 
            addForm.ShowDialog();
            // Sau khi form AddInventoryForm đóng, tải lại dữ liệu để cập nhật DGV

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có hàng nào được chọn không
            if (dgvIngredient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nguyên vật liệu để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID của hàng được chọn (chỉ lấy hàng đầu tiên nếu chọn nhiều)
            int rowIndex = dgvIngredient.SelectedRows[0].Index;

            // Lấy IngredientID. SỬ DỤNG TÊN CỘT CHÍNH XÁC TỪ DATATABLE!
            // (Giả định cột này có tên là "IngredientID" hoặc "ingredientIDDataGridViewTextBoxColumn" nếu dùng tên cột Designer)
            // Tên cột an toàn nhất sau khi gán DataSource là "IngredientID"
            if (dgvIngredient.Rows[rowIndex].Cells["ingredientIDDataGridViewTextBoxColumn"].Value == null)
            {
                MessageBox.Show("Không tìm thấy ID Nguyên vật liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ingredientId = (int)dgvIngredient.Rows[rowIndex].Cells["ingredientIDDataGridViewTextBoxColumn"].Value;
            string ingredientName = dgvIngredient.Rows[rowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString(); // Lấy tên để hiển thị

            // 2. Xác nhận xóa
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nguyên vật liệu '{ingredientName}'? Thao tác này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // 3. Gọi BLL để thực hiện xóa
                    string result = inventoryBLL.DeleteIngredient(ingredientId);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show($"Đã xóa nguyên vật liệu '{ingredientName}' thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 4. Tải lại dữ liệu
                        LoadIngredientsData();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi hệ thống khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

