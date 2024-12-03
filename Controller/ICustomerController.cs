using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface ICustomerController
    {
        bool IsMatchNameValid(string name);
        bool IsMatchEmailValid(string email);
        bool IsMatchPhoneValid(string phone);
    }
}
