using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controller
{
    public class CustomerController : ICustomerController
    {
        public bool IsMatchEmailValid(string email)
        {
            var pattern = @"^[a-z0-9_]+[a-z0-9_-]*@[a-z0-9]+.[a-z]{2,5}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public bool IsMatchNameValid(string name)
        {
            var pattern = @"^[\p{L} ]{2,40}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(name);
        }

        public bool IsMatchPhoneValid(string phone)
        {
            var pattern = @"^(02|03|04|05|06|07|08|09)\d{8}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phone);
        }
    }
}
