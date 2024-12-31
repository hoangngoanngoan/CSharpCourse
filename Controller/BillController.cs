using System;
using Models;

namespace Controller
{
    public class BillController : IBillController
    {
        public void UpdateBill(BillDetail bill, SelectedItem item)
        {
            var cart = bill.Cart.SelectedItems;
            var indexOf = cart.IndexOf(item);
            if (indexOf > 0)
            {
                bill.TotalItem -= cart[indexOf].NumberOfSelectedItem;
                bill.TotalItem += item.NumberOfSelectedItem;
                cart.RemoveAt(indexOf);
                cart.Insert(indexOf, item);
                bill.CalculateBill();
            }else
            {
                cart.Add(item);
                bill.TotalItem += item.NumberOfSelectedItem;
                bill.CalculateBill();
            }            
        }
    }
}
