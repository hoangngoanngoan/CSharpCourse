using Controller;
using Models;
using System;
using System.CodeDom;
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
    public partial class AddEditCustomerFrm : Form
    {
        private IViewController _controller;
        private Customer _oldCustomer = null;
        private Customer _newCustomer = null;
        public AddEditCustomerFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditCustomerFrm(IViewController masterView, Customer customer):this()
        {
            _controller = masterView;

            if(customer != null)
            {
                _oldCustomer = customer;
                Text = "CẬP NHẬT THÔNG TIN NGƯỜI DÙNG";
                btnAddCustomer.Text = "Cập nhật";
                GetCustomerDataFromHomeFrm();
            }else
            {

            }
        }

        private void GetCustomerDataFromHomeFrm()
        {
            txtCustomerId.Text = _oldCustomer.PersonId;
            txtFullName.Text = _oldCustomer.FullName.ToString();
            dateTimeBirthDate.Value = _oldCustomer.BirthDate;
            txtAddress.Text = _oldCustomer.Address;
            txtPhoneNumber.Text = _oldCustomer.PhoneNumber;
            txtEmail.Text = _oldCustomer.Email;
            numericPoin.Value = _oldCustomer.Poin;
            for(int i = 0; i < comboCustomerType.Items.Count; i++)
            {
                if (_oldCustomer.CustomerType.CompareTo(comboCustomerType.Items[i]) == 0)
                {
                    comboCustomerType.SelectedIndex = i;
                    break;
                }
            }
        }

        private void BtnAddUpdateCustomerClick(object sender, EventArgs e)
        {
            var _customerController = new CustomerController();
            try
            {
                if (!_customerController.IsMatchNameValid(txtFullName.Text))
                {
                    throw new InvalidNameExceoption("Họ và tên không hợp lệ", txtFullName.Text);
                }
                if (!_customerController.IsMatchEmailValid(txtEmail.Text))
                {
                    throw new InvalidEmailException("Email không hợp lệ", txtEmail.Text);
                }
                if (!_customerController.IsMatchPhoneValid(txtPhoneNumber.Text))
                {
                    throw new InvalidPhoneNumberException("Số điện thoại không hợp lệ", txtPhoneNumber.Text);
                }
                var id = txtCustomerId.Text;
                var name = txtFullName.Text;
                var birthDate = dateTimeBirthDate.Value;
                var address = txtAddress.Text;
                var phoneNumber = txtPhoneNumber.Text;
                var email = txtEmail.Text;
                var poin = (int)numericPoin.Value;
                var customerType = comboCustomerType.Text;
                Customer newCustomer = new Customer(id, name, birthDate, address, 
                    phoneNumber, customerType, poin, DateTime.Now, email);
                if (btnAddCustomer.Text.CompareTo("Cập nhật") == 0)
                {
                    var ans = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(ans == DialogResult.Yes)
                    {
                        _controller.UpdateItem(_oldCustomer, newCustomer);
                        Dispose();
                    }                    
                }
                else
                {
                    // MessageBox.Show("Kiểm tra lỗi", "Đang test thử", MessageBoxButtons.OK);
                    _controller.AddNewItem(newCustomer);
                }
            }
            catch (InvalidNameExceoption ex) { MessageBox.Show($"{ex.Message} {ex.InvalidName}", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidEmailException ex) { MessageBox.Show($"{ex.Message} {ex.InvalidName}", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (InvalidPhoneNumberException ex) { MessageBox.Show($"{ex.Message} {ex.InvalidName}", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
