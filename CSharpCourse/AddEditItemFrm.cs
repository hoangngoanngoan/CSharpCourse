using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Models;
using Controller;

namespace CSharpCourse
{
    public partial class AddEditItemFrm : Form
    {
        // Các trường dữ liệu cho trước

        private List<Discount> _discounts;   // Mục đích để lưu danh sách các đối tượng khuyến mãi để truyền vào cho mặt hàng
        private Item _oldItem = null;        // Mục đích để lưu đối tượng item cũ chuẩn bị cập nhật mới
        private Item _newItem = null;        // Mục đích để lưu đối tượng item mới để chuẩn bị thêm mới hoặc cập nhật
        private IViewController _controller; // mục đích để thực hiện hai phương thức AddNewItem và UpDateItem trên form HomeFrm

        // Các hàm khởi tạo
        public AddEditItemFrm()
        {
            InitializeComponent();
        }

        public AddEditItemFrm(IViewController masterView, List<Discount> discounts = null, Item item = null) : this()
        {
            _controller = masterView;
            _discounts = discounts;

            // Kiểm tra nếu hàm khởi tạo có truyền tham số item vào có nghĩa là người dùng muốn cập nhật 

            if (item != null)
            {
                Text = "CẬP NHẬT THÔNG TIN MẶT HÀNG";
                btnAddItem.Text = "Cập nhật";
                _oldItem = item;
                GetItemDataFromHomeFrm();
            }
        }

        // Hàm láy dữ liệu từ form HomeFrm
        private void GetItemDataFromHomeFrm()
        {
            txtId.Text = _oldItem.ItemId.ToString();
            txtItemName.Text = _oldItem.ItemName;
            comboItemType.Text = _oldItem.ItemType;
            numericQuantity.Value = _oldItem.Quantity;
            txtBrand.Text = _oldItem.Brand;
            dateTimePickerReleaseDate.Value = _oldItem.ReleaseDate;
            numericPrice.Value = _oldItem.Price;
            for (int i = 0; i < comboDiscount.Items.Count; i++)
            {
                if (_oldItem.Discount?.Name.CompareTo(comboDiscount.Items[i]) == 0)
                {
                    comboDiscount.SelectedIndex = i;
                    break;
                }
            }
        }

        // Hàm láy dữ liệu do người dùng nhập từ bàn phím
        private void GetItemDataFromUser()
        {
            var id = int.Parse(txtId.Text);
            var name = txtItemName.Text;
            var itemType = comboItemType.Text;
            var quantity = (int)numericQuantity.Value;
            var brand = txtBrand.Text;
            var releaseDate = dateTimePickerReleaseDate.Value;
            var price = (int)numericPrice.Value;
            Discount discount = null;
            if (comboDiscount.SelectedIndex > 0)
            {
                discount = _discounts[comboDiscount.SelectedIndex];
            }
            if (string.IsNullOrEmpty(name))
            {
                var msg = "Tên mặt hàng không được để trống.";
                MessageBox.Show(msg, "Lỗi dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(itemType))
            {
                var msg = "Loại mặt hàng không được để trống.";
                MessageBox.Show(msg, "Lỗi dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Item item = new Item(id, name, itemType, quantity, brand, releaseDate, price, discount);
            _newItem = item;
        }

        // Hành động click chuột vào button btnAddItem của người dùng
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Kiểm tra lỗi", "Đang kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Kiểm tra hành động là thêm mới mặt hàng hay cập nhật

            GetItemDataFromUser();
            if (btnAddItem.Text.CompareTo("Cập nhật") == 0)
            {
                if (_oldItem != null && _newItem != null)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(ans == DialogResult.Yes)
                    {
                        _controller.UpdateItem(_oldItem, _newItem);
                        Dispose();
                    }                    
                }
            }
            else
            {
                if (_newItem != null)
                {
                    _controller.AddNewItem(_newItem);
                }
            }
        }

        // Hành động click chuột vào button btnClose của người dùng
        private void btnClose_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Dispose();
            }
        }
    }
}
