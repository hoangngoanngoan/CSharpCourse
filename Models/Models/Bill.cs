using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bill : IComparable<Bill>
    {
        private static int s_autoId = 1000000;
        public int BillId { get; set; }
        public Cart Cart { get; set; } = new Cart();
        public DateTime CreatTime { get; set; }
        public int TotalItem { get; set; }
        public long SubTotal { get; set; }
        public long TotalDiscountAmount { get; set; }
        public long TotalAmont { get; set; }
        public string Status { get; set; }

        public Bill()
        {
            
        }

        public Bill(int id)
        {
            BillId = id > 0 ? id : s_autoId++;
        }

        public Bill(int billId, Cart cart, DateTime creatTime, int totalItem, long subTotal, long totalDiscountAmount, long totalAmont, string status) : this(billId)
        {
            Cart = cart;
            CreatTime = creatTime;
            TotalItem = totalItem;
            SubTotal = subTotal;
            TotalDiscountAmount = totalDiscountAmount;
            TotalAmont = totalAmont;
            Status = status;
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
