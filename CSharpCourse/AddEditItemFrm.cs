using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Models;

namespace CSharpCourse
{
    public partial class AddEditItemFrm : Form
    {

        // Các trường dữ liệu cho trước

        private List<Discount> _discounts;   // Mục đích để lưu danh sách các đối tượng khuyến mãi để truyền vào cho mặt hàng
        private Item _item = null;        // Mục đích để lưu đối tượng item mới để chuẩn bị thêm mới hoặc cập nhật
        private IViewController _controller; // mục đích để thực hiện hai phương thức AddNewItem và UpDateItem trên form HomeFrm
        private List<string> _listDiscount;  // Mục đích để lưu tên khuyến mãi vào comboDiscount


        // Các hàm khởi tạo
        public AddEditItemFrm()
        {
            InitializeComponent();
        }

        public AddEditItemFrm(IViewController masterView, List<Discount> discounts = null, Item item = null) : this()
        {
            _controller = masterView;
            _discounts = discounts;

            // Hiển thị tên khuyến mãi vào comboDiscount
            GetDiscount(_discounts); 
            
            // Kiểm tra nếu hàm khởi tạo có truyền tham số item vào có nghĩa là người dùng muốn cập nhật 
            if (item != null)
            {
                _item = (Item)item.Clone();
               if(item.Discount != null)
                {
                    _item.Discount = item.Discount;
                }else
                {
                    _item.Discount = null;
                }
                Text = "CẬP NHẬT THÔNG TIN MẶT HÀNG";
                btnAddItem.Text = "Cập nhật";
                ShowItem(_item);
            }
            else
            {
                _item = new Item();
            }
        }

        private void GetDiscount(List<Discount> ld)
        {
            _listDiscount = new List<string>();
            foreach (var item in ld)
            {
                _listDiscount.Add(item.Name);
            }
            comboDiscount.DataSource = _listDiscount;
            comboDiscount.SelectedIndex = -1;
        }

        // Hàm láy dữ liệu từ form HomeFrm
        private void ShowItem(Item item)
        {
            txtId.Text = item.ItemId.ToString();
            txtItemName.Text = item.ItemName;
            comboItemType.Text = item.ItemType;
            numericQuantity.Value = item.Quantity;
            txtBrand.Text = item.Brand;
            dateTimePickerReleaseDate.Value = item.ReleaseDate;
            numericPrice.Value = item.Price;
            
            if(item.Discount != null)
            {
                for (int i = 0; i < comboDiscount.Items.Count; i++)
                {
                    if (item.Discount.Name.CompareTo(comboDiscount.Items[i]) == 0)
                    {
                        comboDiscount.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                comboDiscount.SelectedIndex = -1;
            }
            
        }

        private void AddUpdateItem(Item item)
        {
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                var msg = "Tên mặt hàng không được để trống";
                var title = "Lỗi dữ liệu không hợp lệ";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(comboItemType.Text))
            {
                var msg = "Loại mặt hàng không được để trống";
                var title = "Lỗi dữ liệu không hợp lệ";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            item.ItemName = txtItemName.Text;
            item.ItemType = comboItemType.Text;
            item.Quantity = (int)numericQuantity.Value;    
            item.Brand = txtBrand.Text;
            item.ReleaseDate = dateTimePickerReleaseDate.Value;
            item.Price = (int)numericPrice.Value;
            if(comboDiscount.SelectedIndex > -1)
            {
                item.Discount = _discounts[comboDiscount.SelectedIndex];
            }else
            {
                item.Discount = new Discount();
            }
        }

        // Hành động click chuột vào button btnAddItem của người dùng
        private void btnAddItem_Click(object sender, EventArgs e)
        {
           AddUpdateItem(_item);
            if (btnAddItem.Text.CompareTo("Cập nhật") == 0)
            {
                var msg = "Bạn có chắc chắn muốn cập nhật không";
                var title = "Thông báo";
                var ans = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(ans == DialogResult.Yes)
                {
                    _controller.UpdateItem(_item);
                    Dispose();
                }   
            }
            else
            {
                _controller.AddNewItem(_item);
            }
        }

        // Buton Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            var msg = "Bạn có chắc chắn muốn hủy không";
            var title = "Thông báo";
            var ans = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Dispose();
            }
        }
    }
}
