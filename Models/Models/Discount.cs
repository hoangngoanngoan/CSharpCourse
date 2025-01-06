using Newtonsoft.Json;
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
        [JsonIgnore]
        private static int s_autoId = 1000000;

        [JsonProperty("discountId")]   
        public int DiscountId { get; set; }

        [JsonProperty("discountName")]
        public string Name { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty("discountType")]
        public string DiscountType { get; set; }

        [JsonProperty("discountPercent")]
        public int DiscountPercent { get; set; }

        [JsonProperty("discountAmount")]
        public int DiscountAmount { get; set; }

        public Discount() { }
        
        public Discount(int id)
        {
            DiscountId = id == 0 ? ++s_autoId : id;
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
