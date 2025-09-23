using SocialMediaDashboardDesign.BLL; // Thêm using cho BLL
using SocialMediaDashboardDesign.DataAccess;
using System;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign.Control
{
    public partial class LoginControl1 : UserControl
    {
        // ✅ Khai báo một biến cho lớp BLL ở cấp độ lớp
        private UserBLL userBLL;

        #region Constructor

        public LoginControl1()
        {
            InitializeComponent();
            // Khởi tạo BLL một lần duy nhất khi control được tạo
            userBLL = new UserBLL();
        }

        #endregion

        #region Event Handlers

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string username = kryptonTextBox1.Text.Trim();

            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ TỐI ƯU: Gọi BLL để kiểm tra nghiệp vụ, không gọi DAL trực tiếp
            if (!userBLL.IsUserExists(username))
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Nếu tài khoản tồn tại -> chuyển sang màn hình nhập mật khẩu
            // Tìm Form cha (giả sử là LoginForm) để điều hướng
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                // Tạo control nhập mật khẩu và truyền username qua
                LoginControl loginCtrl = new LoginControl(username);
                parentForm.LoadControl(loginCtrl);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Chuyển sang màn hình đăng ký
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                RegisterControl regCtrl = new RegisterControl();
                parentForm.LoadControl(regCtrl);
            }
        }

        #endregion

        #region Empty Handlers for Designer

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        #endregion
    }
}