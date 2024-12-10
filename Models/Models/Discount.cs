using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Discount  
    {
        private static int s_autoId = 1000000;
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DiscountType { get; set; }
        public int DiscountPercent { get; set; }
        public int DiscountAmount { get; set; }

        public Discount()
        {
            
        }
        
        public Discount(int id)
        {
            DiscountId = id == 0 ? s_autoId++ : id;
        }

        public Discount(int discountId, string name, DateTime startTime, DateTime endTime, string discountType, int discountPercent, int discountAmount): this(discountId)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            DiscountType = discountType;
            DiscountPercent = discountPercent;
            DiscountAmount = discountAmount;
        }

        public override bool Equals(object obj)
        {
            return obj is Discount discount &&
                   DiscountId == discount.DiscountId;
        }

        public override int GetHashCode()
        {
            return 1574009819 + DiscountId.GetHashCode();
        }
        public static void UpDateAutoId(int v)
        {
            s_autoId = v;
        }
    }
}
