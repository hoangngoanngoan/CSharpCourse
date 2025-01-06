using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controller
{
    public interface IUpdateAutoID
    {
        void UpdateItemAutoID(List<Item> items);
        void UpdateDiscountAutoID(List<Discount> discounts);
        void UpdateBillAutoID(List<BillDetail> bills);
    }
}
