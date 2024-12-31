using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bill : IComparable<Bill>
    {
        private static int s_autoId = 1000000;
        public int BillId { get; set; } = 0;
        public Cart Cart { get; set; } = new Cart();
        public DateTime CreatTime { get; set; } = DateTime.Now;
        public int TotalItem { get; set; } = 0;
        public long SubTotal { get; set; } = 0;
        public long TotalDiscountAmount { get; set; } = 0;
        public long TotalAmount { get; set; } = 0;
        public string Status { get; set; } = "Đang xử lý";

        public Bill(): this(0)
        {
            CalculateBill(); // Dùng để tính SubTotal, TotalAmount, TotalDiscountAmount
        }

        public Bill(int id)
        {
            BillId = id > 0 ? id : s_autoId++;
            CalculateBill();
        }

        public Bill(int billId, Cart cart, DateTime creatTime, int totalItem, long subTotal, long totalDiscountAmount, long totalAmount, string status) : this(billId)
        {
            Cart = cart;
            CreatTime = creatTime;
            TotalItem = totalItem;
            Status = status;
        }

        public void CalculateBill()
        {
            SubTotal = 0;
            TotalAmount = 0;
            TotalDiscountAmount = 0;
            TotalItem = 0;
            
            foreach (var item in this.Cart.SelectedItems)
            {
                SubTotal += item.NumberOfSelectedItem * item.Price;
                TotalItem += item.NumberOfSelectedItem;
                if(item.Discount != null)
                {
                    TotalDiscountAmount += (int)(item.NumberOfSelectedItem  * item.Price * item.Discount.DiscountPercent / 100 * 1.0f + item.NumberOfSelectedItem * item.Discount.DiscountAmount);
                }else
                {
                    TotalDiscountAmount += TotalDiscountAmount * item.NumberOfSelectedItem;
                }
            }
            TotalAmount = SubTotal - TotalDiscountAmount;
        }

        public int CompareTo(Bill other)
        {
            return BillId - other.BillId;
        }

        public override bool Equals(object obj)
        {
            return obj is Bill bill &&
                   BillId == bill.BillId;
        }

        public override int GetHashCode()
        {
            return 740390073 + BillId.GetHashCode();
        }
        public static void UpDateAutoId(int v)
        {
            s_autoId = v;
        }
    }
}
