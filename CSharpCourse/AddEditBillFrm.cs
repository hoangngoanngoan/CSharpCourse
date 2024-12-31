using Models;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Controller;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;

namespace CSharpCourse
{
    public partial class AddEditBillFrm : Form
    {
        // MasterView HomeFrm
        private IViewController _controller;

        // Danh sách Khách hàng
        private List<Customer> _customer;
        private List<Customer> _searchCustomerResult;

        // Danh sách Mặt hàng
        private List<Item> _item;
        private List<Item> _searchItemResult;

        // Danh sách Hóa đơn
        private BillDetail _bill;
        private SelectedItem _selectedItem;

        // Danh sách giỏ hàng
        private List<SelectedItem> _cart;

        //
        private CommonController _commonController;
        
        private BillController _billController;

        private bool _isUpdateBill;
        private BillDetail _oldBillDetail;


        // =============================================================================================================================
        // ================================================== HÀM KHỞI TẠO ============================================================= 
        // ============================================================================================================================= 


        public AddEditBillFrm()
        {
            InitializeComponent();
            CenterToParent();
            _commonController = new CommonController();
            _cart = new List<SelectedItem>();
            
        }

        // Hàm khởi tạo chính 
        // Truyền vào danh sách item, customer và đối tượng bill
        // Mục đích
        // 1 Update được danh sách item trả về trang HomeFrm
        // 2 Update hoặc thêm mới đối tượng bill và trả về danh sách billDetail của trang HomeFrm 

        public AddEditBillFrm(IViewController controller, List<Customer> customers, List<Item> items, BillDetail bill) : this()
        {
            _controller = controller;
            _customer = customers;              
            _item = items;                      
            
            if (bill != null)
            {
                _isUpdateBill = true;
                _bill = bill;
                _cart = bill.Cart.SelectedItems;
                _oldBillDetail = _bill;
                ShowBillDetail(_bill, _cart);
            }
            else            
            {
                _isUpdateBill = false;
                _bill = new BillDetail();
                _bill.Cart.SelectedItems = _cart;
            }
        }


        // =============================================================================================================================
        // ==================================================== KẾT QUẢ TRẢ VỀ =========================================================
        // ================================================ KHI THOÁT CHƯƠNG TRÌNH ===================================================== 
        // =============================================================================================================================
        // =============================================================================================================================
        // ========================================= 1. CẬP NHẬT HOẶC THÊM MỚI HÓA ĐƠN =================================================
        // ==================================== 2. CẬP NHẬT LẠI DANH SÁCH MẶT HÀNG TỒN KHO =============================================
        // =============================================================================================================================

        private void BtnSaveClick(object sender, EventArgs e)
        {

            // 1. CẬP NHẬT LẠI HÓA ĐƠN 

            if (_isUpdateBill)
            {
                _controller.UpdateItem(_bill, null);
            }

            // 1. HOẶC THÊM MỚI HÓA ĐƠN

            else 
            { 
                _controller.AddNewItem(_bill);
            }


            // 2. CẬP NHẬT LẠI DANH SÁCH MẶT HÀNG TỒN KHO

            foreach (var item in _searchItemResult)
            {
                if (_item.IndexOf(item) >= 0)
                {
                    _controller.UpdateItem(item, null);
                }
            }

            Dispose();
        }

        // Button Hủy bỏ
        private void BtnCancelClick(object sender, EventArgs e)
        {
            _bill.Status = "Đã hủy";
            _controller.UpdateItem(null, _bill);
            _controller.UpdateItem(null, _item);
            Dispose();
        }

        // Button Xóa bỏ
        private void BtnRemoveClick(object sender, EventArgs e)
        {

        }

        // Button Thanh toán
        private void BtnPayClick(object sender, EventArgs e)
        {
            if (_bill.Cart.Customer != null && _bill.Cart.SelectedItems.Count > 0)
            {
                var frm = new PaymentFrm(_controller, _bill);
                frm.ShowDialog();
                Dispose();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần thiết", "Lỗi dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        // =============================================================================================================================
        // ======================================= GIAO DIỆN SỬ DỤNG CHƯƠNG TRÌNH THÊM MỚI HÓA ĐƠN =====================================
        // =============================================================================================================================


        // =============================================== HIỂN THỊ THÔNG TIN KHÁCH HÀNG ===============================================
        // =============================================================================================================================

        // Button Tìm
        private void BtnSearchCustomerClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                var title = "Lỗi tìm kiếm";
                var message = "Vui lòng nhập tên khách hàng cần tìm kiếm";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _searchCustomerResult = _commonController.Search(_customer, new CustomerController().IsCustomerNameMath, txtCustomerName.Text);
                if (_searchCustomerResult.Count == 0)
                {
                    var title = "Lỗi tìm kiếm";
                    var message = "Không tìm thấy kết quả";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ShowSearchCustomerResult(_searchCustomerResult);
                }
            }
        }

        // Hiển thị
        private void ShowSearchCustomerResult(List<Customer> searchCustomerResult)
        {
            tblSearchCustomer.Rows.Clear();
            foreach (var customer in _searchCustomerResult)
            {
                tblSearchCustomer.Rows.Add(new object[]
                {
                            customer.PersonId, customer.FullName.ToString(), customer.PhoneNumber
                });
            }
        }


        // ============================================= HIỂN THỊ THÔNG TIN SẢN PHẨM TỒN KHO ===========================================
        // =============================================================================================================================

        // Button Tìm
        private void BtnSearchItemClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem.Text))
            {
                var title = "Lỗi tìm kiếm";
                var message = "Vui lòng nhập tên mặt hàng cần tìm kiếm";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tblSearchItem.Rows.Clear();
                _searchItemResult = _commonController.Search(_item, new ItemController().IsItemNameMatch, txtItem.Text);
                if (_searchItemResult.Count == 0)
                {
                    var title = "Lỗi tìm kiếm";
                    var message = "Không tìm thấy kết quả";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ShowSearchItemResult(_searchItemResult);
                }
            }
        }

        // Hiển thị
        private void ShowSearchItemResult(List<Item> items)
        {
            tblSearchItem.Rows.Clear();
            foreach (var item in items)
            {
                tblSearchItem.Rows.Add(new object[]
                {
                    item.ItemId, item.ItemName, item.Quantity
                });
            }
        }


        
        // =================================== 1 SỬA HOẶC THÊM THÔNG TIN KHÁCH HÀNG TRONG HÓA ĐƠN ======================================
        // ==================================== 2 SỬA HOẶC THÊM THÔNG TIN NHÂN VIÊN TRONG HÓA ĐƠN ======================================

        // 1 CellClick
        private void TblSearchCustomerCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && e.ColumnIndex == 3)
            {
                _bill.Cart.Customer = _searchCustomerResult[e.RowIndex];
                var customerName = _searchCustomerResult[e.RowIndex].FullName.ToString();
                labelCustomer.Text = $"Khách hàng: {customerName}";
            }
        }

        // 2 Leave
        private void UpdateStaffInfo(object sender, EventArgs e)
        {
            _bill.StaffName = txtStaffName.Text;
        }



        // ============================================== 1 THÊM MẶT HÀNG VÀO HÓA ĐƠN ==================================================
        // ======================================== 2 HIỂN THỊ CHI TIẾT MẶT HÀNG TRONG HÓA ĐƠN =========================================
        // ============================================== 3 XÓA MẶT HÀNG TRONG HÓA ĐƠN =================================================

        // 1 CellClick
        private void TblSearchItemCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                int index = _cart.IndexOf(_searchItemResult[e.RowIndex] as SelectedItem) == null ? -1 :
                _cart.IndexOf(_searchItemResult[e.RowIndex] as SelectedItem);

                if(
                    (int)numericNumberOfSelectedItem.Value <= _searchItemResult[e.RowIndex].Quantity
                    && (int)numericNumberOfSelectedItem.Value > 0
                    )
                {
                    if (index >= 0)
                    {
                        var oldNumberOfSelectedItem = _cart[index].NumberOfSelectedItem;

                        _cart[index].NumberOfSelectedItem = (int)numericNumberOfSelectedItem.Value + oldNumberOfSelectedItem;
                        _cart[index].UpdateQuantity((int)numericNumberOfSelectedItem.Value);
                        _commonController.UpdateItem(_searchItemResult, _searchItemResult[e.RowIndex], _cart[index] as Item);
                    }
                    else
                    {
                        _selectedItem = new SelectedItem(_searchItemResult[e.RowIndex], (int)numericNumberOfSelectedItem.Value);
                        _cart.Add(_selectedItem);

                        index = _cart.IndexOf(_selectedItem);
                        _cart[index].UpdateQuantity((int)numericNumberOfSelectedItem.Value);
                        _commonController.UpdateItem(_searchItemResult, _searchItemResult[e.RowIndex], _cart[index] as Item);
                    }
                }else
                {
                    MessageBox.Show("Số lượng không hợp lệ, vui lòng nhập lại số lượng hợp lệ", "Lỗi dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _bill.CalculateBill();
            labelTotalItem.Text = $"Tổng số sp: {_bill.TotalItem.ToString()}sp";
            labelTotalDiscount.Text = $"Tổng KM: {_bill.TotalDiscountAmount.ToString():N0}đ";
            labelTotalAmount.Text = $"Tổng tiền: {_bill.TotalAmount.ToString():N0}đ";
            labelCreatedTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ShowSearchItemResult(_searchItemResult);
            ShowBillDetail(_bill, _cart);
        }

        // 2 Hiển thị
        private void ShowBillDetail(BillDetail bill, List<SelectedItem> cart)
        {
            tblBill.Rows.Clear();
            foreach(var item in cart)
            {
                tblBill.Rows.Add(new object[]
                {
                    bill.BillId, item.ItemId ,item.ItemName, item.NumberOfSelectedItem, bill.SubTotal, bill.TotalDiscountAmount, bill.TotalAmount 
                });
            }
        }

        // 3 CellClick
        private void TblBillCellRemoveClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                var ans = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    var indexOfSearchItemResult = _searchItemResult.IndexOf(_cart[e.RowIndex]);
                    var indexOfItem = _item.IndexOf(_searchItemResult[indexOfSearchItemResult]);

                    _commonController.UpdateItem(_searchItemResult, _searchItemResult[indexOfSearchItemResult], _item[indexOfItem]);
                    tblBill.Rows.RemoveAt(e.RowIndex);
                    _cart.RemoveAt(e.RowIndex);

                    ShowSearchItemResult(_searchItemResult);
                    _bill.CalculateBill();
                    labelTotalItem.Text = $"Tổng số sp: {_bill.TotalItem.ToString()}sp";
                    labelTotalDiscount.Text = $"Tổng KM: {_bill.TotalDiscountAmount.ToString():N0}đ";
                    labelTotalAmount.Text = $"Tổng tiền: {_bill.TotalAmount.ToString():N0}đ";
                    labelCreatedTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                }              
            }
        }
        

        // ======================== HIỂN THỊ THÔNG TIN KHÁCH HÀNG, NHÂN VIÊN, TỔNG SẢN PHẨM, TỔNG KHUYẾN MÃI, TỔNG TIỀN ================

    }
}
