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
            try
            {
                // ✅ Gọi hàm mới để lấy DataSet
                DataSet billData = orderBLL.GetBillDetails(orderId);

                if (billData == null || billData.Tables.Count < 2)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu hóa đơn.");
                    return;
                }

                // --- Lấy và hiển thị thông tin tóm tắt ---
                DataTable summaryTable = billData.Tables["OrderSummary"];
                if (summaryTable.Rows.Count > 0)
                {
                    DataRow summaryRow = summaryTable.Rows[0];

                    // Giả sử bạn có các Label này trong Form
                    // Ví dụ: lblOrderIdValue, lblTableNumberValue, lblTimeValue
                    lblOrderIdValue.Text = "#" + summaryRow["OrderID"].ToString();
                    lblTableNumberValue.Text = summaryRow["TableNumber"].ToString();
                    

                    // ✅ Lấy tổng tiền trực tiếp từ DB, không cần tính lại
                    decimal totalAmount = Convert.ToDecimal(summaryRow["TotalAmount"]);
                    lblTotal.Text = $"Total: {totalAmount:N0} VND";
                }

                // --- Lấy và hiển thị danh sách món ăn ---
                DataTable orderItems = billData.Tables["OrderItems"];
                billListView.Items.Clear(); // Xóa các item cũ

                foreach (DataRow row in orderItems.Rows)
                {
                    string itemName = row["ItemName"].ToString();
                    int qty = Convert.ToInt32(row["Quantity"]);
                    decimal price = Convert.ToDecimal(row["Price"]);
                    decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                    // Định dạng tiền tệ theo culture của máy
                    string priceFormatted = price.ToString("N0");
                    string subtotalFormatted = subtotal.ToString("N0");

                    billListView.Items.Add(new ListViewItem(new[]
                    {
                itemName,
                qty.ToString(),
                priceFormatted,
                subtotalFormatted
            }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
