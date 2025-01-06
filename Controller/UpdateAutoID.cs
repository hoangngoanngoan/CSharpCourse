using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UpdateAutoID : IUpdateAutoID
    {
        public void UpdateBillAutoID(List<BillDetail> bills)
        {
            int billId = 0;
            foreach (BillDetail it in bills) 
            {
                if(billId < it.BillId)
                {
                    billId = it.BillId;
                }
            }
            Bill.UpDateAutoId(billId);
        }

        public void UpdateDiscountAutoID(List<Discount> discounts)
        {
            int discountId = 0;
            foreach (var it in discounts)
            {
                if (discountId < it.DiscountId)
                {
                    discountId = it.DiscountId;
                }
            }
            Discount.UpDateAutoId(discountId);
        }

        public void UpdateItemAutoID(List<Item> items)
        {
            int itemId = 0; 
            foreach(var it in items)
            {
                if(itemId < it.ItemId)
                {
                    itemId = it.ItemId;
                }
            }
            Item.UpDateAutoId(itemId);
        }
    }
}
