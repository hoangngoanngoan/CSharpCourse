using System;
using System.Text.RegularExpressions;
using Models;

namespace Controller
{
    public class DiscountController : IDiscountController
    {
        public bool IsMatchEndDate(Discount discount, string date)
        {
            var pattern = $".*{date}.*";
            var regex = new Regex(pattern);
            return regex.IsMatch(discount.EndTime.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public bool IsMatchNameDiscount(Discount discount, string name)
        {
            var pattern = $".*{name}.*";
            var regex = new Regex(pattern);
            return regex.IsMatch(discount.Name);
        }

        public bool IsMatchStartDate(Discount discount, string date)
        {
            var pattern = $".*{date}.*";
            var regex = new Regex(pattern);
            return regex.IsMatch(discount.StartTime.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
