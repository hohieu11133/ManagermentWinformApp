using System;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using SocialMediaDashboardDesign.DataAccess;
using BCrypt.Net;

namespace SocialMediaDashboardDesign.Control
{
    public partial class RegisterControl : UserControl
    {
        private UserDAL userDAL;

        public RegisterControl()
        {
            InitializeComponent();
            userDAL = new UserDAL();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidUsername(txtUsername.Text))
                errorProvider1.SetError(txtUsername, "Username must be at least 5 characters, no spaces, only letters and digits.");
            else
                errorProvider1.SetError(txtUsername, "");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidPassword(txtPassword.Text))
                errorProvider2.SetError(txtPassword, "Password ≥ 8 chars, include upper, lower, digit, special char.");
            else
                errorProvider2.SetError(txtPassword, "");

            ValidatePasswordMatch();
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            ValidatePasswordMatch();
        }

        private void txtGmail_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtGmail.Text))
                errorProvider3.SetError(txtGmail, "Invalid email format.");
            else
                errorProvider3.SetError(txtGmail, "");
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidPhoneNumber(txtPhoneNumber.Text))
                errorProvider4.SetError(txtPhoneNumber, "Phone must start with 0, 9–11 digits.");
            else
                errorProvider4.SetError(txtPhoneNumber, "");
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

                // Check empty
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate each field
                if (!IsValidUsername(username))
                {
                    MessageBox.Show("Invalid username format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidPassword(password))
                {
                    MessageBox.Show("Password must have ≥8 chars, include upper, lower, digit, special.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Check username exists
                if (userDAL.IsUserExists(username))
                {
                    MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hash password
                string hashedPassword = HashPassword(password);

                // Insert to DB
                if (userDAL.RegisterUser(username, hashedPassword, email, phoneNumber))
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();

                    // Mở LoginForm
                    LoginForm loginForm = new LoginForm();
                    Form parentForm = this.FindForm();
                    loginForm.Show();
                    parentForm.Hide();
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý gì đặc biệt
        }
        private void ValidatePasswordMatch()
        {
            if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim() && !string.IsNullOrEmpty(txtConfirmPass.Text))
                errorProvider1.SetError(txtConfirmPass, "Passwords do not match!");
            else
                errorProvider1.SetError(txtConfirmPass, "");
        }

        private bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            if (username.Length < 5) return false;
            return username.All(c => char.IsLetterOrDigit(c));
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8) return false;
            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) &&
                   phoneNumber.StartsWith("0") &&
                   phoneNumber.Length >= 9 &&
                   phoneNumber.Length <= 11;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            txtGmail.Text = "";
            txtPhoneNumber.Text = "";
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                LoginControl1 loginctr = new LoginControl1();
                parentForm.LoadControl(loginctr);
            }
        }
    }
}
