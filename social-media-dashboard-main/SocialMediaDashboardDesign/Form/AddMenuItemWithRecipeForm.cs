using SocialMediaDashboardDesign.BLL;
using SocialMediaDashboardDesign.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign
{
    public partial class AddMenuItemWithRecipeForm : Form
    {
        private readonly MenuBLL menuBLL; // Giả định
        private readonly InventoryBLL inventoryBLL; // BLL cho NVL
        private int currentMenuItemId = 0;

        // Constructor mới để nhận ID món ăn
        public AddMenuItemWithRecipeForm(int menuItemId)
        {
            InitializeComponent();
       
             menuBLL = new MenuBLL();
            inventoryBLL = new InventoryBLL();

            // Tải dữ liệu tĩnh (Danh mục, Đơn vị)
            LoadStaticData();
            ConfigureRecipeGrid();

            this.currentMenuItemId = menuItemId;

            if (currentMenuItemId > 0)
            {
                // Chế độ CHỈNH SỬA
                this.Text = "Cập Nhật Món Ăn và Công Thức";
                btnSave.Text = "Lưu Cập Nhật";

                // Tải dữ liệu hiện tại của món ăn và công thức
                LoadItemDetails(currentMenuItemId);
            }
            else
            {
                // Chế độ THÊM MỚI (nếu bạn dùng chung form)
                this.Text = "Thêm Món Ăn Mới";
                btnSave.Text = "Thêm Món Ăn";
            }
        }

        // Constructor mặc định (cần thiết nếu bạn dùng form cho Add)
        public AddMenuItemWithRecipeForm() : this(0) { }
        private void LoadItemDetails(int menuItemId)
        {
            try
            {
                // 1. Tải thông tin Món ăn cơ bản
                DataRow itemRow = menuBLL.GetMenuItemById(menuItemId); // Giả định hàm này tồn tại
                if (itemRow == null)
                {
                    MessageBox.Show("Không tìm thấy món ăn này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtName.Text = itemRow["Name"].ToString();
                cmbCategory.SelectedValue = (int)itemRow["CategoryID"];
                // Sử dụng nudPrice để đặt giá trị
                nudPrice.Value = Math.Min(nudPrice.Maximum, (decimal)itemRow["Price"]);
                chkIsAvailable.Checked = (bool)itemRow["IsAvailable"];
                // Tải ảnh (Tùy chọn: cần logic phức tạp hơn cho ảnh)
                // picImage.ImageLocation = itemRow["ImageURL"].ToString(); 

                // 2. Tải công thức hiện tại vào dgvRecipe
                DataTable recipeDt = menuBLL.GetRecipeByMenuItemId(menuItemId); 

                // Gán DataTable công thức vào DGV
                dgvRecipe.DataSource = recipeDt;
                dgvRecipe.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStaticData()
        {
            // Tải danh mục cho cmbCategory
            cmbCategory.DataSource = menuBLL.GetCategories();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryID";

            // Tải dữ liệu cho DGV sẽ được thực hiện trong ConfigureRecipeGrid
        }

        private void ConfigureRecipeGrid()
        {
            // Lấy dữ liệu NVL và Đơn vị
            DataTable ingredients = inventoryBLL.GetIngredientsWithUnits(); // Cần đảm bảo hàm này trả về đủ cột: IngredientID, Name
            DataTable units = inventoryBLL.GetUnits(); // Trả về UnitID, Name

            // 1. Cấu hình cột Nguyên vật liệu (colIngredientID)
            colIngredientID.DataSource = ingredients;
            colIngredientID.DisplayMember = "Name"; // Hiển thị tên NVL
            colIngredientID.ValueMember = "IngredientID"; // Giá trị là ID của NVL
            colIngredientID.DataPropertyName = "IngredientID"; // Liên kết với dữ liệu công thức

            // 2. Cấu hình cột Đơn vị (colUnitID)
            colUnitID.DataSource = units;
            colUnitID.DisplayMember = "Name"; // Hiển thị tên đơn vị (Gram, Kilogram, v.v.)
            colUnitID.ValueMember = "UnitID"; // Giá trị là ID của đơn vị
            colUnitID.DataPropertyName = "UnitID"; // Liên kết với dữ liệu công thức

            // 3. Cấu hình cột Số lượng (colQuantityUsed)
            colQuantityUsed.DataPropertyName = "QuantityUsed"; // Liên kết với dữ liệu công thức

            // 4. Cấu hình DGV
            dgvRecipe.AutoGenerateColumns = false;
        }
       
        private DataTable GetRecipeDataFromGrid()
        {
            DataTable recipeDt = new DataTable();
            // Tạo các cột khớp với bảng MenuItemIngredients (IngredientID, QuantityUsed, UnitID)
            recipeDt.Columns.Add("IngredientID", typeof(int));
            recipeDt.Columns.Add("QuantityUsed", typeof(decimal));
            recipeDt.Columns.Add("UnitID", typeof(int));

            // Lấy tên cột chính xác từ DGV để tránh lỗi nếu DGV có cột thừa
            string colIngID = colIngredientID.Name;
            string colQty = colQuantityUsed.Name;
            string colUnitIDName = colUnitID.Name;

            foreach (DataGridViewRow row in dgvRecipe.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    // Lấy giá trị từ cột ComboBox (ValueMember)
                    int ingredientId = (int)row.Cells[colIngID].Value;
                    decimal quantityUsed = Convert.ToDecimal(row.Cells[colQty].Value);
                    int unitId = (int)row.Cells[colUnitIDName].Value;

                    if (quantityUsed <= 0)
                    {
                        throw new ArgumentException($"Số lượng nguyên vật liệu [{row.Index + 1}] phải lớn hơn 0.");
                    }

                    recipeDt.Rows.Add(ingredientId, quantityUsed, unitId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi dữ liệu công thức ở dòng {row.Index + 1}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null; // Trả về null để hủy quá trình lưu
                }
            }
            return recipeDt;
        }
        private void dgvRecipe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột nút bấm "Xóa"
            if (e.RowIndex >= 0 && dgvRecipe.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (dgvRecipe.Rows[e.RowIndex].IsNewRow) return;

                // Xác nhận và xóa dòng
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên vật liệu này khỏi công thức?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvRecipe.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu cơ bản từ các controls
            string name = txtName.Text.Trim();

            // Đảm bảo có giá trị được chọn trong ComboBox (Category)
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Danh mục.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            // Lấy giá bán từ NumericUpDown
            decimal price = nudPrice.Value;

            // Lấy trạng thái có sẵn (Available)
            bool isAvailable = chkIsAvailable.Checked;

            // Giả định PicImage.ImageLocation chứa đường dẫn ảnh
            string imageUrl = picImage.ImageLocation;

            // 2. Xác thực Dữ liệu Cơ bản
            if (string.IsNullOrEmpty(name) || price <= 0)
            {
                MessageBox.Show("Vui lòng nhập Tên món ăn và Giá bán phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Kiểm tra trùng tên (Chỉ kiểm tra nếu tên trùng với MÓN KHÁC)
                // GIẢ ĐỊNH: Hàm MenuItemExists có thể nhận thêm ID để loại trừ món đang chỉnh sửa.
                if (menuBLL.MenuItemExists(name, currentMenuItemId))
                {
                    MessageBox.Show($"Món ăn có tên '{name}' đã tồn tại trong menu.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Lấy và Xác thực dữ liệu Công thức từ DataGridView
                DataTable recipeData = GetRecipeDataFromGrid();

                if (recipeData == null)
                {
                    // GetRecipeDataFromGrid trả về null nếu có lỗi xác thực (ví dụ: số lượng <= 0)
                    return;
                }

                if (recipeData.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một nguyên vật liệu vào công thức.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5. PHÂN LOẠI VÀ THỰC HIỆN GIAO DỊCH
                bool success = false;
                string successMessage = "";

                if (currentMenuItemId > 0)
                {
                    // CHẾ ĐỘ CẬP NHẬT
                    // Cần đảm bảo MenuBLL có hàm UpdateMenuItemWithRecipe
                    success = menuBLL.UpdateMenuItemWithRecipe(currentMenuItemId, name, categoryId, price, isAvailable, imageUrl, recipeData);
                    successMessage = "Cập nhật món ăn và công thức thành công!";
                }
                else
                {
                    // CHẾ ĐỘ THÊM MỚI
                    success = menuBLL.AddMenuItemWithRecipe(name, categoryId, price, isAvailable, imageUrl, recipeData);
                    successMessage = "Thêm món ăn và công thức thành công!";
                }

                if (success)
                {
                    MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đặt DialogResult là OK để form gọi (cha) biết rằng thao tác thành công
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống khi lưu món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                        picImage.Image = Image.FromFile(destFile);
                        picImage.ImageLocation = destFile;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xử lý ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
