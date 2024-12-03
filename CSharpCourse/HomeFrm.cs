using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Models;
using Controller;

namespace CSharpCourse
{
    public enum ActionType
    {
        NORMAL, SEARCH
    }
    public interface IViewController
    {
        void AddNewItem<T>(T item);
        void UpdateItem<T>(T oldItem, T newItem);
    }
    public partial class HomeFrm : Form, IViewController
    {

        private ActionType _actionType;
        private CommonController _commonController; // Dùng để gọi các phương thức Generic Thêm xoá sửa sắp xếp tìm kiếm

        // Mặt hàng

        private List<Item> _items;                  // Dùng để lưu danh sách các mặt hàng có trong cửa hàng
        private List<Discount> _discount = null;    // Dùng để lưu các đối tượng mã khuyến mãi
        private ItemController _itemController;     // Dùng nạp các comparer truyền vào phương thức _commonController.Sort<T>(<T>List list, Comparison<T> Comparer)
        private List<Item> _resultSearchItem;       // Dùng để lưu dách sách kết quả tìm kiếm tạm thời
        private List<Customer> _resultSearchCustomer; // Dùng để lưu danh sách kết quả tìm kiềm tạm thời

        // Khách hàng

        private List<Customer> _customers;

        public HomeFrm()
        {
            InitializeComponent();
            // Mặt hàng
            _items = new List<Item>();
            _discount = new List<Discount>();
            _commonController = new CommonController();
            _itemController = new ItemController();
            _resultSearchItem = new List<Item>();
            _actionType = ActionType.NORMAL;

            // Khách hàng
            _customers = new List<Customer>();

            // Nạp dữ liệu 
            _customers = Utils.CreateFakeCustomer();
            _items = Utils.CreateFakeItem();
            ShowItems(_items);
            ShowCustomers(_customers);
        }

        // Hàm hiện thị danh sách khách hàng
        private void ShowCustomers(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                tblCustomer.Rows.Add(new object[]
                {
                    customer.PersonId, customer.FullName.ToString(), customer.BirthDate.ToString("dd/MM/yyyy"),
                    customer.Address, customer.Email, customer.PhoneNumber, 
                    customer.Poin, customer.CustomerType, customer.CreatTime.ToString("dd/MM/yyy HH:mm:ss")
                });
            }
        }

        // Hàm hiển thị danh sách mặt hàng
        private void ShowItems(List<Item> listItem)
        {
            tblItem.Rows.Clear();
            foreach(var item in listItem)
            {
                tblItem.Rows.Add(new object[]
                {
                    item.ItemId, item.ItemName, item.ItemType, item.Quantity,
                    item.Brand, item.ReleaseDate.ToString("dd/MM/yyyy"), $"{item.Price:N0}",
                    item.Discount == null ? "-" : item.Discount.Name
                });
            }
        }

        // Hàm thêm mới đối tượng 
        public void AddNewItem<T>(T item)
        {
            if(typeof(T) == typeof(Item))
            {
                var newItem = item as Item;
                _commonController.AddNewItem(_items, newItem); // Truyền newItem vào trong List _items
                ShowItems(_items);
            }
            else if(typeof(T) == typeof(Customer)) 
            {
                var newCustomer = item as Customer;
                _commonController.AddNewItem(_customers, newCustomer);
                ShowCustomers(_customers);
            }
        }

        // Hàm cập nhật đối tượng
        public void UpdateItem<T>(T oldItem, T newItem)
        {
            // Cập nhật danh sách Item _items
            if(typeof(T) == typeof(Item)) 
            {
                if (_actionType == ActionType.NORMAL)
                {
                    var nItem = newItem as Item;
                    var oItem = oldItem as Item;
                    _commonController.UpdateItem(_items, oItem, nItem);  // Cập nhật oItem thành nItem trọng List<Item> _items
                    int index = _commonController.IndexOfItem(_items, nItem);
                    tblItem.Rows.RemoveAt(index);
                    ShowItems(_items);
                }
                else
                {
                    var nItem = newItem as Item;
                    var oItem = oldItem as Item;
                    _commonController.UpdateItem(_items, oItem, nItem);  // Cập nhật oItem thành nItem trong List<Item> _items
                    _commonController.UpdateItem(_resultSearchItem, oItem, nItem);
                    int index = _commonController.IndexOfItem(_items, nItem);
                    index = _commonController.IndexOfItem(_resultSearchItem, nItem);
                    tblItem.Rows.RemoveAt(index);
                    ShowItems(_resultSearchItem);
                }
               
            }else if (typeof(T) == typeof(Customer))
            {
                if(_actionType == ActionType.NORMAL)
                {
                    var nCustomer = newItem as Customer;
                    var oCustomer = oldItem as Customer;
                    _commonController.UpdateItem(_customers, oCustomer, nCustomer);
                    // LÀM TIẾP
                }
            }
        }

        // Chức năng thêm mới
        // Chức năng cập nhật
        // Chức năng xoá
        // 
        // Bao gồm form, button,..
        // AddEditItemFrm
        // btnAddItem
        // các radioSortItem
        // tblItemCellClick

        // Hàm gọi form AddEditItemFrm : bằng sự kiện btnAddItem_Click
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var frm = new AddEditItemFrm(this, _discount, null);
            frm.ShowDialog();
        }

        // Hàm gọi form AddEditItemFrm : bằng sự kiện tblItemCellClick
        private void tblItemCellCick(object sender, DataGridViewCellEventArgs e)
        {
            if(_actionType == ActionType.NORMAL)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == tblItem.Columns["tblItemEdit"].Index)
                {
                    var frm = new AddEditItemFrm(this, _discount, _items[e.RowIndex]);
                    frm.ShowDialog();
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == tblItem.Columns["tblItemRemove"].Index)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        _commonController.DeleteItem(_items, _items[e.RowIndex]);
                        MessageBox.Show($"Đã xoá thành công dòng thứ {e.RowIndex + 1}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tblItem.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }else
            {
                if(e.RowIndex >= 0 && e.ColumnIndex == tblItem.Columns["tblItemEdit"].Index)
                {
                    var frm = new AddEditItemFrm(this, _discount, _resultSearchItem[e.RowIndex]);
                    frm.ShowDialog();
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == tblItem.Columns["tblItemRemove"].Index)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(ans == DialogResult.Yes)
                    {
                        _commonController.DeleteItem(_items, _resultSearchItem[e.RowIndex]);
                        _commonController.DeleteItem(_resultSearchItem, _resultSearchItem[e.RowIndex]);
                        
                        MessageBox.Show($"Đã xoá thành công dòng thứ {e.RowIndex + 1}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tblItem.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        // Chức năng sắp xếp
        private void SortItemHandler(object sender, EventArgs e)
        {
            if (radioSortItemByPriceASC.Checked)
            {
                _commonController.Sort(_items, _itemController.CompareItemByPriceASC);
                // Cách khác
                //_commonController.SortByPriceASC(_items);
            }else if (radioSortItemByPriceDSC.Checked)
            {
                _commonController.Sort(_items, _itemController.CompareItemByPriceDSC);
            }else if (radioSortItemByQuantity.Checked)
            {
                _commonController.Sort(_items, _itemController.CompareItemByQuantityDSC);
            }else if (radioSortItemByName.Checked)
            {
                _commonController.Sort(_items, _itemController.CompareItemByName);
            }else if (radioSortItemByDate.Checked)
            {
                _commonController.Sort(_items, _itemController.CompareItemByDate);
            }
            ShowItems(_items);
        }

        // Chức năng tìm kiếm
        private void ComboBoxSearchItemSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboSearchItem.SelectedIndex)
            {
                case 0:
                case 2:
                case 3:
                    numericItemFrom.Enabled = false;
                    numericItemTo.Enabled = false;
                    txtSearchItem.Enabled = true;
                    break;
                case 1:
                case 4:
                    numericItemFrom.Enabled = true;
                    numericItemTo.Enabled = true;
                    txtSearchItem.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        private void BtnSearchItemClick(object sender, EventArgs e)
        {
            _actionType = ActionType.SEARCH;
            // Mặc định khi nhấn vào nút tìm kiếm thì sẽ gán cho _actionType bằng ActionType.Search 
            // Khi _actionType == ActionType.SEARCH thì sẽ tìm kiếm trên bản _items
            // Sau đó lưu vào bảng _resultSearchItem và hiển thị lên tblItem bằng bảng đó
            tblItem.Rows.Clear();
            if (comboSearchItem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboSearchItem.SelectedIndex == 0)
            {
                var key = txtSearchItem.Text;
                _resultSearchItem = _commonController.Search(_items ,_itemController.IsItemNameMatch, key);
                if(_resultSearchItem.Count == 0)
                {
                    MessageBox.Show("Không có kết quả", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ShowItems(_resultSearchItem);
                }
            }
            else if(comboSearchItem.SelectedIndex == 1) // Tìm kiếm theo giá
            {
                var from = (int)numericItemFrom.Value;
                var to = (int)numericItemTo.Value;
                _resultSearchItem = _commonController.Search(_items, _itemController.IsItemPriceMatch, from, to);
                if (_resultSearchItem.Count == 0)
                {
                    MessageBox.Show("Không có kết quả", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ShowItems(_resultSearchItem);
                }
            }
            else if (comboSearchItem.SelectedIndex == 2) // Tìm kiếm theo loại mặt hàng
            {
                var key = txtSearchItem.Text;
                _resultSearchItem = _commonController.Search(_items, _itemController.IsItemTypeMatch, key);
                if(_resultSearchItem.Count == 0)
                {
                    MessageBox.Show("Không có kết quả", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else 
                {
                    ShowItems(_resultSearchItem);
                }
            }
            else if(comboSearchItem.SelectedIndex == 3) // Tìm kiếm theo hảng sản xuất
            {
                var key = txtSearchItem.Text;
                _resultSearchItem = _commonController.Search(_items, _itemController.IsItemBrandMatch, key);
                if (_resultSearchItem.Count == 0)
                {
                    MessageBox.Show("Không có kết quả", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ShowItems(_resultSearchItem);
                }
            }
            else if(comboSearchItem.SelectedIndex == 4) // Tìm kiếm theo số lượng
            {
                var from = (int)numericItemFrom.Value;
                var to = (int)numericItemTo.Value;
                _resultSearchItem = _commonController.Search(_items, _itemController.IsItemQuantityMatch, from, to);
                if (_resultSearchItem.Count == 0)
                {
                    MessageBox.Show("Không có kết quả", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ShowItems(_resultSearchItem);
                }
            }
        }

        // Chức năng refresh bảng hiển thị (tblItem)
        private void btnReloadItem_Click(object sender, EventArgs e)
        {
            _actionType = ActionType.NORMAL;
            // Mặc định khi nhấn vào nút refresh thì sẽ gán _actionType = ActionType.NORMAL
            txtSearchItem.Text = null;
            comboSearchItem.SelectedIndex = -1;
            numericItemFrom.Value = 0;
            numericItemTo.Value = 0;
            numericItemFrom.Enabled = true;
            numericItemTo.Enabled = true;
            txtSearchItem.Enabled = true;
            tblItem.Rows.Clear();
            ShowItems(_items);
        }

        private void BtnAddNewCustomerClick(object sender, EventArgs e)
        {
            var frm = new AddEditCustomerFrm();
            frm.ShowDialog();
        }

        private void TblCustomerCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_actionType == ActionType.NORMAL)
            {
                if (e.RowIndex != -1 && e.ColumnIndex == 9)
                {
                    var frm = new AddEditCustomerFrm(this, _customers[e.RowIndex]);
                    frm.ShowDialog();
                }
                else if (e.RowIndex != -1 && e.ColumnIndex == 10)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        _commonController.DeleteItem(_customers, _customers[e.RowIndex]);
                        _customers.RemoveAt(e.RowIndex);
                        tblCustomer.Rows.RemoveAt(e.RowIndex);
                    }

                }
            }else
            {
                if(e.RowIndex != -1 && e.ColumnIndex == 9)
                {
                    var frm = new AddEditCustomerFrm(this, _resultSearchCustomer[e.RowIndex]);
                    frm .ShowDialog();
                }else if(e.RowIndex != -1 && e.ColumnIndex == 10)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(ans == DialogResult.Yes)
                    {
                        _commonController.DeleteItem(_customers, _resultSearchCustomer[e.RowIndex]);
                        _commonController.DeleteItem(_resultSearchCustomer, _resultSearchCustomer[e.RowIndex]);
                        tblCustomer.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            
        }
    }
}
