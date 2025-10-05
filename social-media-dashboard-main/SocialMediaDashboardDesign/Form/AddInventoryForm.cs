using SocialMediaDashboardDesign.BLL; // Đảm bảo bạn có lớp BLL này
using SocialMediaDashboardDesign.BusinessLogic;
using System;
using System.Data;
using System.Windows.Forms;
using ExcelDataReader;
namespace SocialMediaDashboardDesign
{
    public partial class AddInventoryForm : Form
    {
        private readonly InventoryBLL inventoryBLL; // Khai báo BLL

        private int currentIngredientId; // Biến để lưu ID NVL hiện tại

        // 1. Constructor mới để nhận ID
        public AddInventoryForm(int ingredientId)
        {
            InitializeComponent();
            this.currentIngredientId = ingredientId;
            inventoryBLL = new InventoryBLL(); // Khởi tạo BLL
            // Nếu ID > 0, đây là chế độ SỬA/NHẬP KHO, nên tải dữ liệu lên form
            if (ingredientId > 0)
            {
                this.Text = "Cập Nhật Nguyên Vật Liệu";
                btnSave.Text = "Lưu Thay Đổi";
                LoadIngredientDetails(ingredientId); // Hàm tải chi tiết NVL
            }
            else // Constructor cũ (có thể dùng cho chế độ thêm mới)
            {
                this.Text = "Thêm Nguyên Vật Liệu Mới";
                btnSave.Text = "Thêm Mới";
            }

            LoadUnitDropdown();
        }
        public AddInventoryForm()
        {
            InitializeComponent();
            inventoryBLL = new InventoryBLL(); // Khởi tạo BLL
            LoadUnitDropdown(); // Hàm load đơn vị
        }

        // ====== Logic Tải Đơn vị (Unit) ======
        private void LoadUnitDropdown()
        {
            try
            {
                // Gọi hàm BLL để lấy dữ liệu UnitID và Name
                DataTable dt = inventoryBLL.GetUnits();

                // Gán nguồn dữ liệu cho ComboBox
                cmbUnit.DataSource = dt;
                cmbUnit.DisplayMember = "Name";     // Cột hiển thị (tên đơn vị)
                cmbUnit.ValueMember = "UnitID";     // Cột lấy giá trị (ID đơn vị)

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách đơn vị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        // ====== Logic Nút Lưu ======
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị từ form
            string name = txtName.Text.Trim();
            // Lấy ID đơn vị đã chọn (chuyển từ object sang int)
            int unitId = (int)cmbUnit.SelectedValue;
            decimal currentStock = nudCurrentStock.Value;
            decimal costPerUnit = nudCostPerUnit.Value;
            decimal minStockLevel = nudMinStockLevel.Value;

            if (string.IsNullOrEmpty(name) || unitId <= 0)
            {
                MessageBox.Show("Vui lòng nhập Tên và chọn Đơn vị tính.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gọi hàm BLL để thêm nguyên vật liệu
                bool success = inventoryBLL.AddIngredient(name, unitId, currentStock, costPerUnit, minStockLevel);

                if (success)
                {
                    MessageBox.Show("Thêm nguyên vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đặt kết quả là OK
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Tải chi tiết Nguyên vật liệu lên form khi ở chế độ chỉnh sửa.
        /// </summary>
        /// <param name="id">IngredientID.</param>
        private void LoadIngredientDetails(int id)
        {
            try
            {
                DataRow ingredientRow = inventoryBLL.GetIngredientDetails(id);

                if (ingredientRow != null)
                {
                    // Lấy dữ liệu và điền vào các controls
                    txtName.Text = ingredientRow["Name"].ToString();

                    // LƯU Ý: Lấy UnitID ra khỏi DataRow trước
                    int savedUnitId = (int)ingredientRow["UnitID"];

                    // Đặt các NumericUpDown (Đảm bảo giá trị không vượt quá Max/Min của control)
                    nudCurrentStock.Value = Math.Min(nudCurrentStock.Maximum, (decimal)ingredientRow["CurrentStock"]);
                    nudCostPerUnit.Value = Math.Min(nudCostPerUnit.Maximum, (decimal)ingredientRow["CostPerUnit"]);

                    // Xử lý MinStockLevel (có thể là DBNull)
                    if (ingredientRow["MinStockLevel"] != DBNull.Value)
                    {
                        nudMinStockLevel.Value = Math.Min(nudMinStockLevel.Maximum, (decimal)ingredientRow["MinStockLevel"]);
                    }
                    else
                    {
                        nudMinStockLevel.Value = 0;
                    }

                    // ĐẶT COMBOBOX THEO SELECTEDVALUE
                    // Vì LoadUnitDropdown đã được gọi trong constructor, 
                    // DataSource và ValueMember đã được thiết lập.
                    cmbUnit.SelectedValue = savedUnitId;

                    // KHÔNG cho phép sửa Tên và Đơn vị khi đang chỉnh sửa
                    txtName.ReadOnly = true;
                    cmbUnit.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Nguyên vật liệu này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết Nguyên vật liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|CSV Files|*.csv";
            openFileDialog.Title = "Chọn File Danh Sách Nguyên Vật Liệu";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // 1. Đọc dữ liệu từ file vào DataTable
                    DataTable importedData = ExcelHelper.ReadDataFromFile(filePath);

                    if (importedData != null && importedData.Rows.Count > 0)
                    {
                        // 2. Gọi BLL để xử lý và chèn dữ liệu
                        InventoryBLL inventoryBLL = new InventoryBLL();

                        // Giả định hàm ProcessAndAddBulkIngredients đã được thêm vào BLL
                        string log = inventoryBLL.ProcessAndAddBulkIngredients(importedData);

                        MessageBox.Show("Quá trình nhập dữ liệu hoàn tất.\n\n" + log,
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tùy chọn: Tải lại DataGridView quản lý tồn kho
                        // LoadIngredientsData(); 
                    }
                    else
                    {
                        MessageBox.Show("File không chứa dữ liệu hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi nhập file: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}