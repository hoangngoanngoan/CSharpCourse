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

        void UpdateItem<T>(T newItem);

        void UpdateItem<T>(T oldItem, T newItem);

        void DeleteItem<T>(T item);

        void UpdateListItem<T>(List<T> lItem);

    }

    public partial class HomeFrm : Form, IViewController
    {

        private ActionType _actionType;
        private CommonController _commonController; 

        // Mặt hàng
        private List<Item> _items;                  
        private ItemController _itemController;     
        private List<Item> _resultSearchItem;       
        
        // Khách hàng
        private List<Customer> _customers;
        private CustomerController _customerController;
        private List<Customer> _resultSearchCustomer;

        // Discount
        private List<Discount> _discounts = null;
        private List<Discount> _resultSearchDiscount;
        private DiscountController _discountController;

        // BillDetail
        private List<BillDetail> _bills;
        private List<BillDetail> _resultSearchBillDetail;

        private IOController _iOController;
        private UpdateAutoID _updateAutoID;



        // =============================================================================================================================
        // ======================================================= HÀM KHỞI TẠO ======================================================== 
        // ============================================================================================================================= 


        public HomeFrm()
        {
            InitializeComponent();

            // CommonController
            _commonController = new CommonController();

            // Mặt hàng
            _items = new List<Item>();
            _itemController = new ItemController();
            _resultSearchItem = new List<Item>();
            _actionType = ActionType.NORMAL;

            // Khách hàng
            _customers = new List<Customer>();
            _customerController = new CustomerController();
            _resultSearchCustomer = new List<Customer>();

            // Discount 
            _discounts = new List<Discount>();
            _resultSearchDiscount = new List<Discount>();
            _discountController = new DiscountController();

            // BillDetail
            _bills = new List<BillDetail>();
            _resultSearchBillDetail = new List<BillDetail>();

            // IOController
            _iOController = new IOController();

            // Nạp dữ liệu 
            _iOController.LoadDataList(_items, _customers, _discounts, _bills);

             UpdateAutoID
            _updateAutoID = new UpdateAutoID();
            _updateAutoID.UpdateItemAutoID(_items);
            _updateAutoID.UpdateDiscountAutoID(_discounts);
            _updateAutoID.UpdateBillAutoID(_bills);
            
            //_items = Utils.CreateFakeItem();
            //_customers = Utils.CreateFakeCustomer();
            //_discounts = Utils.CreateFakeDiscount();

            // Hiển thị
            ShowItems(_items);
            ShowCustomers(_customers);
            ShowDiscounts(_discounts);
            ShowBills(_bills);
        }


        // ==================================================== HIỂN THỊ DANH SÁCH =====================================================
        // ===================================================== 1. MẶT HÀNG ===========================================================
        // ===================================================== 2. KHÁCH HÀNG =========================================================
        // ===================================================== 3. KHUYẾN MÃI =========================================================
        // ===================================================== 4. HÓA ĐƠN ============================================================
        // ================================= NƠI THỰC HIỆN LỜI GỌI LÀ TỪ CÁC "HÀM KHỞI TẠO VÀ TỪ CÁC BUTTON" ===========================


        // 1. HIỂN THỊ DANH SÁCH KHÁCH HÀNG
        private void ShowCustomers(List<Customer> customers)
        {
            tblCustomer.Rows.Clear();
            foreach (var customer in customers)
            {
                tblCustomer.Rows.Add(new object[]
                {
                    customer.PersonId, customer.FullName.ToString(), customer.BirthDate.ToString("dd/MM/yyyy"),
                    customer.Address, customer.PhoneNumber, customer.Email,
                    customer.Poin, customer.CustomerType, customer.CreatTime.ToString("dd/MM/yyy HH:mm:ss")
                });
            }
        }

        
        // 2. HIỂN THỊ DANH SÁCH MẶT HÀNG TỒN KHO
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

        
        // 3. HIỂN THỊ DANH SÁCH KHUYẾN MÃI
        private void ShowDiscounts(List<Discount> discounts)
        {
            tblDiscount.Rows.Clear();
            foreach (var item in discounts) 
            {
                tblDiscount.Rows.Add(new object[]
                {
                    item.DiscountId, item.Name, item.StartTime.ToString("dd/MM/yyyy"),
                    item.EndTime.ToString("dd/MM/yyyy"), item.DiscountType, $"{item.DiscountPercent:N0}",
                    $"{item.DiscountAmount:N0}"
                });
            }
        }

        
        // 4. HIỂN THỊ DANH SÁCH HÓA ĐƠN
        private void ShowBills(List<BillDetail> bills)
        {
            tblBill.Rows.Clear();
            foreach (var bill in bills) 
            {
                tblBill.Rows.Add(new object[]
                {
                    bill.BillId, bill.Cart.Customer.FullName.ToString(), bill.StaffName,
                    bill.CreatTime.ToString("dd/MM/yyyy HH:mm:ss"), $"{bill.TotalItem}sp", $"{bill.SubTotal:N0}đ",
                    $"{bill.TotalDiscountAmount:N0}đ",$"{ bill.TotalAmount:N0}đ", bill.Status
                });
            }
        }


        // ==================================================== THÊM MỚI ĐỐI TƯỢNG =====================================================
        // ===================================================== 1. MẶT HÀNG ===========================================================
        // ===================================================== 2. KHÁCH HÀNG =========================================================
        // ===================================================== 3. KHUYẾN MÃI =========================================================
        // ===================================================== 4. HÓA ĐƠN ============================================================
        // ========================= NƠI THỰC HIỆN LỜI GỌI LÀ TỪ CÁC "CHƯƠNG TRÌNH CẬP NHẬT HOẶC THÊM MỚI" =============================


        public void AddNewItem<T>(T item)
        {
            // 1. MẶT HÀNG
            
            if(typeof(T) == typeof(Item))
            {
                var newItem = item as Item;
                _commonController.AddNewItem(_items, newItem);
                ShowItems(_items);
            }

            // 2. KHÁCH HÀNG

            else if(typeof(T) == typeof(Customer)) 
            {
                var newCustomer = item as Customer;
                _commonController.AddNewItem(_customers, newCustomer);
                ShowCustomers(_customers);
            }
            
            // 3. KHUYẾN MÃI

            else if(typeof(T) == typeof(Discount))
            {
                var newDisCount = item as Discount;
                _commonController.AddNewItem(_discounts, newDisCount);
                ShowDiscounts(_discounts);
            }
            
            // 4. HÓA ĐƠN 

            else if(typeof(T) == typeof(BillDetail))
            {
                var newBillDetail = item as BillDetail;
                _commonController.AddNewItem(_bills, newBillDetail);
                ShowBills(_bills);
            }


        }



        // ==================================================== CẬP NHẬT ĐỐI TƯỢNG =====================================================
        // ===================================================== 1. MẶT HÀNG ===========================================================
        // ===================================================== 2. KHÁCH HÀNG =========================================================
        // ===================================================== 3. KHUYẾN MÃI =========================================================
        // ===================================================== 4. HÓA ĐƠN ============================================================
        // ========================= NƠI THỰC HIỆN LỜI GỌI LÀ TỪ CÁC "CHƯƠNG TRÌNH CẬP NHẬT HOẶC THÊM MỚI" =============================

        public void UpdateListItem<T>(List<T> lItem)
        {
            if (typeof(T) == typeof(Item)) 
            {
                var nLItem = lItem as List<Item>;
                _items.Clear();
                _items.AddRange(nLItem);
                ShowItems(_items);
            }
                
        }

        public void UpdateItem<T>(T oldItem, T newItem)
        {

            // 1. MẶT HÀNG

            if(typeof(T) == typeof(Item)) 
            {
                if (_actionType == ActionType.NORMAL)
                {
                    var nItem = newItem as Item;
                    var oItem = oldItem as Item;
                    _commonController.UpdateItem(_items, oItem);
                    int index = _commonController.IndexOfItem(_items, oItem);
                    ShowItems(_items);
                }
                else
                {
                    var nItem = newItem as Item;
                    var oItem = oldItem as Item;
                    _commonController.UpdateItem(_items, oItem);  
                    _commonController.UpdateItem(_resultSearchItem, oItem);
                    int index = _commonController.IndexOfItem(_items, oItem);
                    index = _commonController.IndexOfItem(_resultSearchItem, oItem);
                    ShowItems(_resultSearchItem);
                }
               
            }

            // 2. KHÁCH HÀNG

            else if (typeof(T) == typeof(Customer))
            {
                if(_actionType == ActionType.NORMAL)
                {
                    var nCustomer = newItem as Customer;
                    var oCustomer = oldItem as Customer;
                    int index = _commonController.UpdateItem(_customers, oCustomer, nCustomer);
                    ShowCustomers(_customers);
                }else
                {
                    var nCustomers = newItem as Customer;
                    var oCustomers = oldItem as Customer;
                    int index = _commonController.UpdateItem(_customers, oCustomers, nCustomers);
                    index = _commonController.UpdateItem(_resultSearchCustomer, oCustomers, nCustomers);
                    ShowCustomers(_resultSearchCustomer);
                }
            }
            
            // 3. KHUYẾN MÃI

            else if (typeof(T) == typeof(Discount))
            {
                if(_actionType == ActionType.NORMAL)
                {
                    var nDiscount = newItem as Discount;
                    var oDiscount = oldItem as Discount;
                    int index = _commonController.UpdateItem(_discounts, oDiscount, nDiscount);
                    ShowDiscounts(_discounts);
                } else
                {
                    var nDiscount = newItem as Discount;
                    var oDiscount = oldItem as Discount;
                    int index = _commonController.UpdateItem(_discounts, oDiscount, nDiscount);
                    index = _commonController.UpdateItem(_resultSearchDiscount, oDiscount, nDiscount);
                    ShowDiscounts(_resultSearchDiscount);
                }   
            }
            
            // 4. HÓA ĐƠN

            else if(typeof(T) == typeof(BillDetail))
            {
                if(_actionType == ActionType.NORMAL)
                {
                    var oItem = oldItem as BillDetail;
                    int indexBill = _commonController.UpdateItem(_bills, oItem);
                    ShowBills(_bills);
                }else
                {
                    // DO SOMETHING
                }
            }


        }

        //
        // Cập nhật lại chức năng cập nhật lại thông tin hiển thị trên DataGridView 
        //
        public void UpdateItem<T>(T newItem)
        {

            // 1. MẶT HÀNG

            if (typeof(T) == typeof(Item))
            {
                if (_actionType == ActionType.NORMAL)
                {
                    var nItem = newItem as Item;
                    _commonController.UpdateItem(_items, nItem);
                    ShowItems(_items);
                }
                else
                {
                    var nItem = newItem as Item;
                    _commonController.UpdateItem(_items, nItem);
                    _commonController.UpdateItem(_resultSearchItem, nItem);
                    ShowItems(_resultSearchItem);
                }
            }

            // 4. HÓA ĐƠN

            else if (typeof(T) == typeof(BillDetail))
            {
                if (_actionType == ActionType.NORMAL)
                {
                    var nItem = newItem as BillDetail;
                    _commonController.UpdateItem(_bills, nItem);
                    ShowBills(_bills);
                }
                else
                {
                    // DO SOMETHING
                }
            }
        }

        public void DeleteItem<T>(T item)
        {
            if(typeof(T) == typeof(BillDetail))
            {
                if(_actionType == ActionType.NORMAL)
                {
                    var billDelected = item as BillDetail;
                    _commonController.DeleteItem(_bills, billDelected);
                    ShowBills(_bills);
                }
            }else
            {
                if (_actionType == ActionType.SEARCH)
                {
                    var billDelected = item as BillDetail;
                    _commonController.DeleteItem(_bills, billDelected);
                    _commonController.DeleteItem(_resultSearchBillDetail, billDelected);
                    ShowBills(_resultSearchBillDetail);
                }
            }
        }


        // ========================================== CHƯƠNG TRÌNH CẬP NHẬP HOẶC THÊM MẶT HÀNG =========================================
        // =============================================================================================================================


        // 1. THÊM MỚI

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var frm = new AddEditItemFrm(this, _discounts, null);
            frm.ShowDialog();
        }

        
        // 2. CẬP NHẬT HOẶC XÓA BỎ

        private void tblItemCellCick(object sender, DataGridViewCellEventArgs e)
        {
            if(_actionType == ActionType.NORMAL)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == tblItem.Columns["tblItemEdit"].Index)
                {
                    var frm = new AddEditItemFrm(this, _discounts, _items[e.RowIndex]);
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
                    var frm = new AddEditItemFrm(this, _discounts, _resultSearchItem[e.RowIndex]);
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

        
        // 3. SẮP XẾP

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

        
        // 4. TIÊU CHÍ TÌM KIẾM

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


        // 5. TÌM KIẾM
        
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


        // 6. RELOAD HIỂN THỊ DANH SÁCH TÌM KIẾM MẶT HÀNG VỀ BÌNH THƯỜNG

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



        // ========================================== CHƯƠNG TRÌNH CẬP NHẬP HOẶC THÊM KHÁCH HÀNG =======================================
        // =============================================================================================================================


        // 1. THÊM MỚI

        private void BtnAddNewCustomerClick(object sender, EventArgs e)
        {
            var frm = new AddEditCustomerFrm(this, null);
            frm.ShowDialog();
        }


        // 2. CẬP NHẬT HOẶC XÓA BỎ

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

        
        // 3. SẮP XẾP

        private void RadioSortCustomerCheckedChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.NORMAL)
            {
                if (radioCustomerSortById.Checked == true)
                {
                    _commonController.Sort(_customers, _customerController.SortCustomerByIdASC);
                }
                else if (radioCustomerSortByName.Checked == true)
                {
                    _commonController.Sort(_customers, _customerController.SortCustomerByNameASC);
                }
                else if (radioCustomerSortByBirthDate.Checked == true)
                {
                    _commonController.Sort(_customers, _customerController.SortCustomerByBirthDateASC);
                }
                else if (radioCustomerSortByPoint.Checked == true)
                {
                    _commonController.Sort(_customers, _customerController.SortCustomerByPointDSC);
                }
                else if (radioCustomerSortByCreatedDate.Checked == true)
                {
                    _commonController.Sort(_customers, _customerController.SortCustomerByCreatedDateDSC);
                }
                ShowCustomers(_customers);
            }
            else
            {
                if (radioCustomerSortById.Checked == true)
                {
                    _commonController.Sort(_resultSearchCustomer, _customerController.SortCustomerByIdASC);
                }
                else if (radioCustomerSortByName.Checked == true)
                {
                    _commonController.Sort(_resultSearchCustomer, _customerController.SortCustomerByNameASC);
                }
                else if (radioCustomerSortByBirthDate.Checked == true)
                {
                    _commonController.Sort(_resultSearchCustomer, _customerController.SortCustomerByBirthDateASC);
                }
                else if (radioCustomerSortByPoint.Checked == true)
                {
                    _commonController.Sort(_resultSearchCustomer, _customerController.SortCustomerByPointDSC);
                }
                else if (radioCustomerSortByCreatedDate.Checked == true)
                {
                    _commonController.Sort(_resultSearchCustomer, _customerController.SortCustomerByCreatedDateDSC);
                }
                ShowCustomers(_resultSearchCustomer);
            }    
        }

        
        // 4. TÌM KIẾM 

        private void BtnSearchCustomerClick(object sender, EventArgs e)
        {
            _actionType = ActionType.SEARCH;
            var index = comboSearchCustomer.SelectedIndex;
            if(index != -1)
            {
                if (!string.IsNullOrEmpty(txtSearchCustomer.Text))
                {
                    _resultSearchCustomer.Clear();
                    switch (index)
                    {
                        case 0:
                            _resultSearchCustomer.AddRange(_commonController.Search(_customers, 
                                _customerController.IsCustomerNameMath, txtSearchCustomer.Text));
                            break;
                        case 1:
                            _resultSearchCustomer = _commonController.Search(_customers,
                                _customerController.IsCustomerIdMath, txtSearchCustomer.Text);
                            break;
                        case 2:
                            _resultSearchCustomer = _commonController.Search(_customers,
                                _customerController.IsCustomerTypeMath, txtSearchCustomer.Text);
                            break;
                        case 3:
                            _resultSearchCustomer = _commonController.Search(_customers,
                                _customerController.IsCustomerAddressMath, txtSearchCustomer.Text);
                            break;
                        case 4:
                            _resultSearchCustomer = _commonController.Search(_customers,
                                _customerController.IsCustomerPhoneMath, txtSearchCustomer.Text);
                            break;
                        default:
                            break;
                    }
                    ShowCustomers(_resultSearchCustomer);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập nội dung tìm kiếm", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // 5. RELOAD HIỂN THỊ DANH SÁCH TÌM KIẾM KHÁCH HÀNG VỀ BÌNH THƯỜNG
        
        private void BtnReloadCustomerClick(object sender, EventArgs e)
        {
            _actionType = ActionType.NORMAL;
            radioCustomerSortByName.Checked = false;
            radioCustomerSortByPoint.Checked = false;
            radioCustomerSortById.Checked = false;
            radioCustomerSortByCreatedDate.Checked = false;
            radioCustomerSortByBirthDate.Checked = false;

            ShowCustomers(_customers);
        }





        // ========================================= CHƯƠNG TRÌNH CẬP NHẬP HOẶC THÊM KHUYẾN MÃI ========================================
        // =============================================================================================================================


        // 1. THÊM MỚI

        private void BtnAddDiscountClick(object sender, EventArgs e)
        {
            var frm = new AddEditDiscountFrm(this, null);
            frm.ShowDialog();
        }


        // 2. CẬP NHẬT HOẶC XÓA BỎ

        private void TblDiscountCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_actionType == ActionType.NORMAL)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 7)
                {
                    var frm = new AddEditDiscountFrm(this, _discounts[e.RowIndex]);
                    frm.ShowDialog();
                } 
                else if(e.RowIndex >= 0 && e.ColumnIndex == 8)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        _commonController.DeleteItem(_discounts, _discounts[e.RowIndex]);
                        ShowDiscounts(_discounts);
                    }
                } 
            }else
            {
                if(e.RowIndex >= 0 && e.ColumnIndex == 7)
                {
                    var frm = new AddEditDiscountFrm(this, _resultSearchDiscount[e.RowIndex]);
                    frm.ShowDialog();
                }
                else if(e.RowIndex >= 0 && e.ColumnIndex == 8)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(ans == DialogResult.Yes)
                    {
                        _commonController.DeleteItem(_discounts, _resultSearchDiscount[e.RowIndex]);
                        _commonController.DeleteItem(_resultSearchDiscount, _resultSearchDiscount[e.RowIndex]);
                        tblDiscount.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        
        // 3. TÌM KIẾM 

        private void BtnSearchDiscountClick(object sender, EventArgs e)
        {
            _actionType = ActionType.SEARCH;
            if (comboSearchDiscount.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(string.IsNullOrEmpty(txtSearchDiscount.Text))
            {
                MessageBox.Show("Vui lòng điền nội dung tìm kiếm", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                _actionType = ActionType.SEARCH;
                _resultSearchDiscount.Clear();
                var key = txtSearchDiscount.Text;   
                var option = comboSearchDiscount.SelectedIndex;
                switch (option)
                {
                    case 0:
                        _resultSearchDiscount.AddRange(_commonController.Search(_discounts, _discountController.IsMatchStartDate, key));
                        break;
                    case 1:
                        _resultSearchDiscount.AddRange(_commonController.Search(_discounts, _discountController.IsMatchEndDate, key));
                        break;
                    case 2:
                        _resultSearchDiscount.AddRange(_commonController.Search(_discounts,_discountController.IsMatchNameDiscount, key));
                        break;
                    default:
                        break;
                }
                ShowDiscounts(_resultSearchDiscount);
                if(_resultSearchDiscount.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        // 4. RELOAD HIỆN THỊ DANH SÁCH TÌM KIẾM KHUYẾN MÃI VỀ BÌNH THƯỜNG

        private void BtnReloadDiscountClick(object sender, EventArgs e)
        {
            _actionType = ActionType.NORMAL;
            _resultSearchDiscount.Clear();
            comboSearchDiscount.SelectedIndex = -1;
            txtSearchDiscount.Text = string.Empty;
            ShowDiscounts(_discounts);
        }



        // ========================================= CHƯƠNG TRÌNH CẬP NHẬP HOẶC THÊM HÓA ĐƠN ===========================================
        // =============================================================================================================================


        // 1. THÊM MỚI

        private void BtnAddBillClick(object sender, EventArgs e)
        {
            var frm = new AddEditBillFrm(this, _customers, _items, null);
            frm.ShowDialog();
        }

        
        // 2. CẬP NHẬT HOẶC XÓA BỎ

        private void TblBillCellBillDetailClick(object sender, DataGridViewCellEventArgs e)
        {
            if(_actionType == ActionType.NORMAL)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 9)
                {
                    var frm = new AddEditBillFrm(this, _customers, _items, _bills[e.RowIndex]);
                    frm.ShowDialog();
                }
            }else
            {

            }
                       
        }

        private void BtnReloadBillClick(object sender, EventArgs e)
        {
            tblBill.Rows.Clear();
            foreach(var it in _bills)
            {
                tblBill.Rows.Add(new object[]
                {
                    it.BillId, it.Cart.Customer.FullName, it.StaffName, it.CreatTime, it.TotalItem, it.SubTotal, 
                    it.TotalDiscountAmount, it.TotalAmount, it.Status
                });
            }
        }

        private void MenuSaveFileClick(object sender, EventArgs e)
        {
            _iOController.SaveDataList(_items, _customers, _discounts, _bills);
            var message = "Lưu file thành công";
            var title = "Thông báo";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuPowerClick(object sender, EventArgs e)
        {
            var message = "Bạn có muốn lưu lại không ?";
            var title = "Thông báo";
            var ans = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ans == DialogResult.Yes)
            {
                _iOController.SaveDataList(_items, _customers, _discounts, _bills);
                var message2 = "Lưu file thành công";
                var title2 = "Thông báo";
                MessageBox.Show(message2, title2, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                Dispose();
            }  
        }

        private void HomeFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var message = "Bạn có muốn lưu lại không ?";
            var title = "Thông báo";
            var ans = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                _iOController.SaveDataList(_items, _customers, _discounts, _bills);
                var message2 = "Lưu file thành công";
                var title2 = "Thông báo";
                MessageBox.Show(message2, title2, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                Dispose();
            }
        }
    }
}
