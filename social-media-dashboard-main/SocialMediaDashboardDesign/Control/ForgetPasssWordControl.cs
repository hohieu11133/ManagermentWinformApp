using SocialMediaDashboardDesign.BLL;
using SocialMediaDashboardDesign.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign.Control
{
    /// <summary>
    /// UserControl xử lý nghiệp vụ quên mật khẩu, bao gồm nhận email, 
    /// xác thực PIN và đặt lại mật khẩu mới.
    /// </summary>
    public partial class ForgetPasssWordControl : UserControl
    {
        #region --- Class Variables ---

        private readonly string _username;
        private readonly UserBLL userBLL;

        #endregion

        #region --- Constructors ---

        public ForgetPasssWordControl()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        /// <summary>
        /// Constructor để nhận username từ màn hình trước.
        /// </summary>
        public ForgetPasssWordControl(string username) : this()
        {
            this._username = username;
        }

        #endregion

        #region --- Event Handlers ---

        private async void btnGetPin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGetPin.Enabled = false;
            btnGetPin.Text = "Sending...";

            try
            {
                bool success = await Task.Run(() => userBLL.GenerateAndSendPasswordResetPinAsync(_username, email));

                if (success)
                {
                    MessageBox.Show("Mã PIN đã được gửi tới email của bạn. Vui lòng kiểm tra hộp thư.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Email bạn nhập không khớp với tài khoản. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGetPin.Enabled = true;
                btnGetPin.Text = "Get PIN";
            }
        }

        private void btnGetPass_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pin = txtPin.Text.Trim();
            string newPassword = txtPassword.Text;
            string confirmPassword = txtCfPass.Text;

            if (string.IsNullOrEmpty(pin) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã PIN và mật khẩu mới.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và mật khẩu xác nhận không trùng khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Mật khẩu yếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = userBLL.ResetPassword(email, pin, newPassword);

                if (success)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công! Bạn có thể đăng nhập ngay bây giờ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NavigateTo(new LoginControl1());
                }
                else
                {
                    MessageBox.Show("Mã PIN không chính xác hoặc đã hết hạn. Vui lòng thử lại.", "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            // Quay lại màn hình nhập mật khẩu vì username đã được xác nhận
            NavigateTo(new LoginControl(_username));
        }

        #endregion

        #region --- Helper Methods ---

        /// <summary>
        /// Hàm trợ giúp để điều hướng giữa các UserControl.
        /// </summary>
        private void NavigateTo(UserControl control)
        {
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                parentForm.LoadControl(control);
            }
        }

        #endregion

        #region --- Empty Event Handlers for Designer ---

        private void ForgetPasssWordControl_Load(object sender, EventArgs e) { }

        #endregion
    }
}