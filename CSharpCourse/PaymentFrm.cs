using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCourse
{
    public partial class PaymentFrm : Form
    {
        private IViewController _controller;
        private BillDetail _bill;
        public PaymentFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public PaymentFrm(IViewController masterView, BillDetail bill): this()
        {
            _bill = bill;
            _controller = masterView;
            ShowData();
        }

        private void ShowData()
        {
            txtCustomerName.Text = _bill.Cart.Customer.FullName.ToString();
            txtStaffName.Text = _bill.StaffName.ToString();
            txtCreatedTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtTotalItem.Text = $"{_bill.TotalItem.ToString()}sp";
            txtTotalDiscount.Text = $"{_bill.TotalDiscountAmount.ToString():N0}đ";
            txtTotalAmount.Text = $"{_bill.TotalAmount.ToString():N0}đ";
        }

        private void BtnFinishClick(object sender, EventArgs e)
        {
            if(comboPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn hình thức thanh toán", "Lỗi thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
            {
                _bill.Status = "Đã thanh toán";
                _bill.PaymentMehtod = comboPaymentMethod.Text;
                _controller.AddNewItem(_bill);
                Dispose();
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("Bạn có chắc chắn muốn hủy", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            { 
                Dispose();
            }
        }
    }
}
