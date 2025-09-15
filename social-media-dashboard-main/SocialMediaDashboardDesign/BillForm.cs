using SocialMediaDashboardDesign.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaDashboardDesign
{
    public partial class BillForm : Form
    {
        private int orderId;
        private OrderBLL orderBLL;
        public BillForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;
            orderBLL = new OrderBLL();
            this.Load += BillForm_Load;

        }
        private void BillForm_Load(object sender, EventArgs e)
        {
            LoadBill();
        }

        private void LoadBill()
        {
            DataTable orderItems = orderBLL.GetOrderItems(orderId);
           
            decimal totalAmount = 0;
            foreach (DataRow row in orderItems.Rows)
            {
                string itemName = row["Name"].ToString();
                int qty = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                totalAmount += subtotal;

                billListView.Items.Add(new ListViewItem(new[]
                {
            itemName,
            qty.ToString(),
            price.ToString("C"),
            subtotal.ToString("C")
        }));
            }

            lblTotal.Text = $"Total: {totalAmount:C}";
        }

        private void BillGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            // Cập nhật order sang Completed
            orderBLL.UpdateOrderStatus(orderId, "Completed");
            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void billListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
