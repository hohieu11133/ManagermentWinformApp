using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaDashboardDesign.DataAccess;
using BCrypt.Net; // Thêm namespace cho BCrypt

namespace SocialMediaDashboardDesign.Control
{
    public partial class RegisterControl : UserControl
    {
        private UserDAL userDAL;

        public RegisterControl()
        {
            InitializeComponent();
            userDAL = new UserDAL(); // Đọc connectionString từ App.config
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý gì đặc biệt
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm kiểm tra realtime
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm kiểm tra độ mạnh mật khẩu
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            ValidatePasswordMatch();
        }

        private void txtGmail_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm kiểm tra định dạng email
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm kiểm tra định dạng số điện thoại
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassword = txtConfirmPass.Text.Trim();
                string email = txtGmail.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (userDAL.IsUserExists(username))
                {
                    MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidPhoneNumber(phoneNumber))
                {
                    MessageBox.Show("Invalid phone number format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedPassword = HashPassword(password);

                if (userDAL.RegisterUser(username, hashedPassword, email, phoneNumber))
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();


                    // Mở LoginForm
                    LoginForm loginForm = new LoginForm();
                    Form parentForm = this.FindForm(); // Lấy form chứa UserControl hiện tại
                    loginForm.Show();
                    parentForm.Hide(); // Ẩn form hiện tại
                }
                else
                {
                    MessageBox.Show("Registration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidatePasswordMatch()
        {
            if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim() && !string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                errorProvider1.SetError(txtConfirmPass, "Passwords do not match!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPass, "");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length <= 15;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password); // Sử dụng BCrypt
        }

        private void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            txtGmail.Text = "";
            txtPhoneNumber.Text = "";
        }
    }
}