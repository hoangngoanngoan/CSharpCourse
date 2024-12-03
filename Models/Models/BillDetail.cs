using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BillDetail : Bill
    {
        public string PaymentMehtod { get; set; } // Phương thức thanh toán
        public string StaffName { get; set; } // Tên nhân viên lặp hóa đơn

        public BillDetail()
        {

        }

        public BillDetail(int billId, Cart cart, DateTime creatTime, int totalItem,
            long subTotal, long totalDiscountAmount, long totalAmont, string status,
            string paymentMehtod, string staffName)
            : base(billId, cart, creatTime, totalItem, subTotal, totalDiscountAmount, totalAmont, status)
        {
            PaymentMehtod = paymentMehtod;
            StaffName = staffName;
        }

        public override bool Equals(object obj)
        {
            return obj is BillDetail detail &&
                   base.Equals(obj) &&
                   BillId == detail.BillId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1170810969;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + BillId.GetHashCode();
            return hashCode;
        }
    }
}
