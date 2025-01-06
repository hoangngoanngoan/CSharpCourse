using Models;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Linq;

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

        
        // Lớp chứa các chức năng chung
        private CommonController _commonController;
        
        
        // Xác định trạng thái cập nhật hoặc thêm mới
        private bool _isUpdateBill;


        // Cập nhật số lượng sản phẩm
        private BillDetail _bill;
        private List<SelectedItem> _cart;


        public AddEditBillFrm()
        {
            InitializeComponent();
            CenterToParent();
        }


        public AddEditBillFrm(IViewController controller, List<Customer> customers, List<Item> items, BillDetail bill) : this()
        {            
            _searchCustomerResult = new List<Customer>();
            _searchItemResult = new List<Item>();
            _controller = controller;
            _customer = customers;    
            
            // Vấn đề nằm ở đây
            // Phải tạo ra một bản sao danh sách items

            _item = new List<Item>();
            foreach(var item in items)
            {
                _item.Add((Item)item.Clone());
            }

            _commonController = new CommonController();

            if (bill != null)
            {
                _isUpdateBill = true;

                // Vấn đề 
                // phải tạo một bản sao cho bill.Cart.SelectedItem
                
                _bill = (BillDetail)bill.Clone();
                _bill.Cart = new Cart();
                _bill.Cart.SelectedItems.AddRange(bill.Cart.SelectedItems);
                _bill.Cart.Customer = bill.Cart.Customer;
                _cart = _bill.Cart.SelectedItems;
                _bill.CalculateBill();

                ShowBillDetail(_bill, _cart);
                ShowCustomerInfo(_bill.Cart.Customer.FullName.ToString());
                ShowBillInfo(_bill);
            }
            else            
            {
                _isUpdateBill = false;
                _bill = new BillDetail();
                _cart = _bill.Cart.SelectedItems;
            }
        }


        private void ShowBillDetail(BillDetail bill, List<SelectedItem> cart)
        {
            tblBill.Rows.Clear();
            foreach (var item in cart)
            {
                tblBill.Rows.Add(new object[]
                {
                    bill.BillId, item.ItemId, item.ItemName, item.NumberOfSelectedItem, bill.SubTotal,
                    bill.TotalDiscountAmount, bill.TotalAmount
                });
            }
        }


        // =============================================================================================================================
        // ======================================= GIAO DIỆN SỬ DỤNG CHƯƠNG TRÌNH THÊM MỚI HÓA ĐƠN =====================================

        // =============================================== TÌM KIẾM THÔNG TIN KHÁCH HÀNG ===============================================
        // =============================================================================================================================


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
                _searchCustomerResult.Clear();
                _searchCustomerResult = _commonController.Search(_customer, new CustomerController().IsCustomerNameMath, txtCustomerName.Text); 
                if (_searchCustomerResult.Count == 0)
                {
                    tblSearchCustomer.Rows.Clear(); 
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


        private void TblSearchCustomerCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 3)
            {
                var name = _searchCustomerResult[e.RowIndex].FullName.ToString();
                _bill.Cart.Customer = _searchCustomerResult[e.RowIndex];
                ShowCustomerInfo(name);
            }
        }


        private void UpdateStaffInfo(object sender, EventArgs e)
        {
            _bill.StaffName = txtStaffName.Text;
        }


        // =============================================================================================================================
        // ============================================= TÌM KIẾM THÔNG TIN SẢN PHẨM TỒN KHO ===========================================

        // ============================================== 1 THÊM MẶT HÀNG VÀO HÓA ĐƠN ==================================================
        // ============================================== 3 XÓA MẶT HÀNG TRONG HÓA ĐƠN =================================================


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
                _searchItemResult = _commonController.Search(_item, new ItemController().IsItemNameMatch, txtItem.Text);
                if (_searchItemResult.Count == 0)
                {
                    tblSearchItem.Rows.Clear();
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


        
        private void TblSearchItemCellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Nhất vào Tbl search Item cell button "Chọn"
            if(e.RowIndex >= 0 && e.ColumnIndex == 3) 
            {
                var num = (int)numericNumberOfSelectedItem.Value;

                // 2. Kiểm tra số lượng đặt có lớn hơn không và nhỏ hơn số lượng tồn kho mới cho chọn
                if (num > 0 && num <= _searchItemResult[e.RowIndex].Quantity)
                {

                    // 3. Kiểm tra mặt hàng được chọn đã có trong giỏ hàng hay chưa
                    int index = -1;
                    
                    for(int i = 0; i < _cart.Count; i++)
                    {
                        if (_cart[i].ItemId == _searchItemResult[e.RowIndex].ItemId)
                        {
                            index = i; 
                            break;
                        }
                    }

                    if(index >= 0)
                    {
                        // 4. Nếu mặt hàng đã có rồi thì cộng lượng đã đặt với số lượng đặt thêm 
                        _cart[index].NumberOfSelectedItem += num;

                        // 5. Cập nhật lại số lượng tồn kho
                        _searchItemResult[e.RowIndex].Quantity -= num;

                        // 6. Cập nhật lại số lượng tồn kho trong _item
                        _commonController.UpdateItem(_item, _searchItemResult[e.RowIndex]);
                    }
                    else
                    {
                        // 7. Nếu chưa có thì thêm mặt hàng đó vào giỏ hàng
                        _cart.Add(new SelectedItem(_searchItemResult[e.RowIndex] as Item, num));

                        // 8. Cập nhật lại số lượng tồn kho
                        _searchItemResult[e.RowIndex].Quantity -= num;

                        // 9. Cập nhật lại số lượng tồn kho trong _item
                        _commonController.UpdateItem(_item, _searchItemResult[e.RowIndex]);
                    }
                    // 8. Tính toán lại tổng sản phẩm, tổng tạm, tổng khuyến mãi, tổng tiền
                    _bill.CalculateBill();
                }
                else 
                {
                    var message = "Số lượng không hợp lệ, vui lòng nhập lại số lượng hợp lệ";
                    var title = "Lỗi dữ liệu không hợp lệ";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            // 9. Hiển thị lại kết quả tìm kiếm sau khi cật nhật lại số lượng tồn kho
            ShowSearchItemResult(_searchItemResult);
            
            // 10. Hiển thị lại thông tin mặt hàng sau khi cập nhật lại mặt hàng
            ShowBillDetail(_bill, _cart);

            // 11. Hiện thị lại thông tin hóa đơn sau khi cập nhật mặt hàng
            ShowBillInfo(_bill);
        }



        private void TblBillCellRemoveClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                var message = "Bạn có chắc chắn muốn xóa";
                var title = "Thông báo";
                var ans = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    // Cập nhật danh sách mặt hàng tồn kho _item
                    foreach (var it in _item)
                    {
                        if (_cart[e.RowIndex].ItemId == it.ItemId)
                        {
                            it.Quantity += _cart[e.RowIndex].NumberOfSelectedItem;
                            break;
                        }
                    }

                    
                    // Xóa item trong giỏ hàng
                    _cart.RemoveAt(e.RowIndex);

                    // Cập nhật lại hóa đơn _bill
                    _bill.CalculateBill();
                }           
            }

            ShowSearchItemResult(_searchItemResult);

            // Hiển thị lại các thông tin giỏ hàng và hóa đơn
            ShowBillDetail(_bill, _cart);
            ShowBillInfo(_bill);

        }


        // ======================================== 1 HIỂN THỊ CHI TIẾT MẶT HÀNG TRONG HÓA ĐƠN =========================================
        // ======================= 2 HIỂN THỊ THÔNG TIN KHÁCH HÀNG, NHÂN VIÊN, TỔNG SẢN PHẨM, TỔNG KHUYẾN MÃI, TỔNG TIỀN ===============


        private void ShowBillInfo(BillDetail bill)
        {
            labelPaymentMethod.Text = $"Hình thức thanh toán: {bill.PaymentMehtod}";
            labelTotalItem.Text = $"Tổng số sp: {bill.TotalItem.ToString()}sp";
            labelTotalDiscount.Text = $"Tổng KM: {bill.TotalDiscountAmount.ToString():N0}đ";
            labelTotalAmount.Text = $"Tổng tiền: {bill.TotalAmount.ToString():N0}đ";
            labelCreatedTime.Text = bill.CreatTime.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void ShowCustomerInfo(string name)
        {
            labelCustomer.Text = $"Khách hàng: {name}";
        }


        // =============================================================================================================================
        // ==================================================== KẾT QUẢ TRẢ VỀ =========================================================
        // ================================================ KHI THOÁT CHƯƠNG TRÌNH ===================================================== 
        // =============================================================================================================================
        // =============================================================================================================================
        // ========================================= 1. CẬP NHẬT HOẶC THÊM MỚI HÓA ĐƠN =================================================
        // ==================================== 2. CẬP NHẬT LẠI DANH SÁCH MẶT HÀNG TỒN KHO =============================================
        // =============================================================================================================================


        // Button Lưu // ***************************************************************************************************************
        // *****************************************************************************************************************************

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (_cart.Count > 0 && _bill.Cart.Customer != null)
            {
                if (_isUpdateBill == true)
                {
                    _controller.UpdateItem(_bill);
                    _controller.UpdateListItem(_item);
                }
                else
                {
                    _controller.AddNewItem(_bill);
                    _controller.UpdateListItem(_item);
                }
                Dispose();
            }
            else
            {
                var message = "Đơn hàng chưa tồn tại";
                var title = "Thông báo";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddEditBillFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        // Button Hoàn trả // **********************************************************************************************************
        // *****************************************************************************************************************************

        private void BtnCancelClick(object sender, EventArgs e)
        {
            _bill.Status = "Hoàn trả";
            _controller.UpdateItem(_bill);
            Dispose();
        }


        // Button Xóa bỏ // ************************************************************************************************************
        // *****************************************************************************************************************************

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            if (_bill.Status == "Đã thanh toán")
            {
                var message = "Không thể xóa đơn hàng, vì đơn hàng này đã được \"Thanh toán\"";
                var title = "Thông báo xóa đơn hàng";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (_bill.Cart.Customer == null && _cart.Count < 0)
            {
                var message = "Đơn hàng chưa tồn tại, vui lòng chọn chức năng khác";
                var title = "Thông báo xóa đơn hàng";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                var message = "Bạn có chắc chắn muốn xóa hóa đơn này không, đơn hàng này sẽ không còn tồn tại nếu bạn xóa";
                var title = "Thông báo xoá đơn hàng";
                var ans = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    foreach (var item in _cart)
                    {
                        var num = item.NumberOfSelectedItem;
                        var index = _item.IndexOf(item as Item);
                        _item[index].Quantity += num;
                    }
                    _controller.UpdateListItem(_item);
                    _controller.DeleteItem(_bill);
                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                }
            }
        }


        // Button Thanh toán // ********************************************************************************************************
        // *****************************************************************************************************************************

        private void BtnPayClick(object sender, EventArgs e)
        {
            if (_bill.Cart.Customer != null && _cart.Count > 0)
            {
                var frm = new PaymentFrm(_controller, _bill, _isUpdateBill);
                frm.ShowDialog();
                Dispose();
            }
            else
            {
                var message = "Vui lòng điền đầy đủ thông tin cần thiết";
                var title = "Lỗi dữ liệu không hợp lệ";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
