using ComponentFactory.Krypton.Toolkit;
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

namespace SocialMediaDashboardDesign.Control
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }
        private string _username;

        
        // Constructor có tham số username
        public LoginControl(string username) : this()
        {
            _username = username;
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            // Giả sử bạn có label tên là label1
            label1.Text = "Welcome " + _username;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnSignin_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserDAL userDAL = new UserDAL();
            string storedHash = userDAL.GetPasswordHash(_username);

            if (storedHash == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mật khẩu với BCrypt
            bool isValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

            if (isValid)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở Form1
                Form1 mainForm = new Form1();
                Form parentForm = this.FindForm();
                mainForm.Show();
                parentForm.Hide();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
