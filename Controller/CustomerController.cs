using Models;
using System.Text.RegularExpressions;

namespace Controller
{
    public class CustomerController : ICustomerController
    {
        public bool IsCustomerAddressMath(Customer customer, string address)
        {
            var pattern = $".*{address}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(customer.Address);
        }

        public bool IsCustomerIdMath(Customer customer, string id)
        {
            var pattern = $".*{id}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(customer.PersonId);
        }

        public bool IsCustomerNameMath(Customer customer, string name)
        {
            var pattern = $".*{name}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(customer.FullName.FirstName);
        }

        public bool IsCustomerPhoneMath(Customer customer, string phone)
        {
            var pattern = $".*{phone}.*";
            var regex = new Regex(pattern);
            return regex.IsMatch(customer.PhoneNumber);
        }

        public bool IsCustomerTypeMath(Customer customer, string type)
        {
            var pattern = $".*{type}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(customer.CustomerType);
        }

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

        public int SortCustomerByBirthDateASC(Customer customer1, Customer customer2)
        {
            return customer1.BirthDate.CompareTo(customer2.BirthDate);
        }

        public int SortCustomerByCreatedDateDSC(Customer customer1, Customer customer2)
        {
            return customer2.CreatTime.CompareTo(customer1.CreatTime);
        }

        public int SortCustomerByIdASC(Customer customer1, Customer customer2)
        {
            return customer1.CompareTo(customer2);
        }

        public int SortCustomerByNameASC(Customer customer1, Customer customer2)
        {
            var firtName1 = customer1.FullName.FirstName;
            var firtName2 = customer2.FullName.FirstName;
            if(firtName1 != firtName2)
            {
                return firtName1.CompareTo(firtName2);
            }
            return customer1.FullName.LastName.CompareTo(customer2.FullName.LastName);
        }

        public int SortCustomerByPointDSC(Customer customer1, Customer customer2)
        {
            return customer2.Poin.CompareTo(customer1.Poin);
        }
    }
}
