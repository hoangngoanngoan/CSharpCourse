using System;
using Models;

namespace Controller
{
    public interface IDiscountController
    {
        bool IsMatchStartDate(Discount discount, string date);
        bool IsMatchEndDate(Discount discount, string date);
        bool IsMatchNameDiscount(Discount discount, string name);
    }
}
