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
    public partial class LoginControl1 : UserControl
    {
        public LoginControl1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
  

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string username = kryptonTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return;
            }

            // Tạo UserDAL để kiểm tra trong DB
            UserDAL userDAL = new UserDAL();
            if (!userDAL.IsUserExists(username))
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu có username → chuyển sang nhập mật khẩu
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                LoginControl loginCtrl = new LoginControl(username);
                parentForm.LoadControl(loginCtrl);
            }
        }


        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Chuyển sang RegisterControl
            LoginForm parentForm = this.FindForm() as LoginForm;
            if (parentForm != null)
            {
                RegisterControl regCtrl = new RegisterControl();
                parentForm.LoadControl(regCtrl);
            }
        }
    }
}
