using ComponentFactory.Krypton.Toolkit;
using SocialMediaDashboardDesign.BLL; // Thêm using cho BLL
using System;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign.Control
{
    /// <summary>
    /// UserControl chịu trách nhiệm cho bước nhập mật khẩu và xác thực đăng nhập.
    /// </summary>
    public partial class LoginControl : UserControl
    {
        private UserBLL userBLL;
        private string _username;

        #region Constructors

        public LoginControl()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        /// <summary>
        /// Constructor nhận username từ control trước đó.
        /// </summary>
        public LoginControl(string username) : this()
        {
            _username = username;
        }

        #endregion

        #region Event Handlers

        private void LoginControl_Load(object sender, EventArgs e)
        {
            // Hiển thị username đã được xác thực ở bước trước
            if (!string.IsNullOrEmpty(_username))
            {
                label3.Text = _username;
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text; // .Trim() không cần thiết với control này

            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
               
                bool isValid = userBLL.ValidateLogin(_username, password);

                if (isValid)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tìm form cha (LoginForm) để ẩn đi và mở MainForm
                    Form parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        parentForm.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Navigation Methods

        private void Backbtn_Click(object sender, EventArgs e)
        {
            // Quay lại màn hình nhập username
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                LoginControl1 loginctr1 = new LoginControl1();
                parentForm.LoadControl(loginctr1);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Chuyển sang màn hình quên mật khẩu, mang theo username
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                ForgetPasssWordControl forgetctrl = new ForgetPasssWordControl(_username);
                parentForm.LoadControl(forgetctrl);
            }
        }

        #endregion

        #region Empty Handlers for Designer
        private void label2_Click(object sender, EventArgs e) { }
        private void kryptonTextBox1_TextChanged(object sender, EventArgs e) { }
        #endregion
    }
}