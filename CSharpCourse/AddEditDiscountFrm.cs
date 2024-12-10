using Models;
using System;
using System.Windows.Forms;

namespace CSharpCourse
{
    public partial class AddEditDiscountFrm : Form
    {
        private IViewController _controller;
        private Discount _oDiscount;
        public AddEditDiscountFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditDiscountFrm(IViewController masterView,Discount dis):this()
        {
            _controller = masterView;
            if(dis != null)
            {
                _oDiscount = dis;
                this.Text = "CẬP NHẬT THÔNG TIN MÃ KHUYẾN MÃI";
                btnAddUpdateDiscount.Text = "Cập nhật";
                GetDiscountDataFromHomeFrm(_oDiscount);
            }

        }

        private void GetDiscountDataFromHomeFrm(Discount ds)
        {
            txtDiscountId.Text = ds.DiscountId.ToString();
            txtDiscountName.Text = ds.Name;
            dateTimeDiscountStart.Value = ds.StartTime;
            dateTimeDiscountEnd.Value = ds.EndTime;
            for(int i = 0; i <  comboDiscountType.Items.Count; i++)
            {
                if (ds.DiscountType.CompareTo(comboDiscountType.Items[i]) == 0)
                {
                    comboDiscountType.SelectedIndex = i;
                }
            }
            numericDiscountPercent.Value = ds.DiscountPercent;
            numericDiscountAmount.Value = ds.DiscountAmount;
        }

        private void BtnCancelDiscountClick(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("Bạn có chắc chắn muốn hủy?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ans == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void BtnAddEditDiscountClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiscountName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (comboDiscountType.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại khuyến mãi", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (btnAddUpdateDiscount.Text.CompareTo("Cập nhật") == 0)
            {
                // Cập nhật
            }else
            {
                var id = int.Parse(txtDiscountId.Text);
                var name = txtDiscountName.Text;
                var startTime = dateTimeDiscountStart.Value;
                var endTime = dateTimeDiscountEnd.Value;
                var type = comboDiscountType.Text;
                int percent = (int)(numericDiscountPercent.Value);
                int amount = (int)(numericDiscountAmount.Value);
                var newDiscount = new Discount(id, name, startTime, endTime, type, percent, amount); 
                _controller.AddNewItem(newDiscount);
            }
            
        }
    }
}
