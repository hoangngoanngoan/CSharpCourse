using Models;

namespace Controller
{
    public interface ICustomerController
    {
        bool IsMatchNameValid(string name);
        bool IsMatchEmailValid(string email);
        bool IsMatchPhoneValid(string phone);
        bool IsCustomerNameMath(Customer customer, string name);
        bool IsCustomerAddressMath(Customer customer, string address);
        bool IsCustomerIdMath(Customer customer, string id);
        bool IsCustomerTypeMath(Customer customer, string type);
        bool IsCustomerPhoneMath(Customer customer, string phone);
        int SortCustomerByIdASC(Customer customer1, Customer customer2);
        int SortCustomerByNameASC(Customer customer1, Customer customer2);
        int SortCustomerByBirthDateASC(Customer customer1, Customer customer2);
        int SortCustomerByPointDSC(Customer customer1, Customer customer2);
        int SortCustomerByCreatedDateDSC(Customer customer1, Customer customer2);
    }
}
