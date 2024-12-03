using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SelectedItem : Item
    {
        public int NumberOfSelectedItem { get; set; }
        public int PriceAfterDiscount { get; set; }
        public SelectedItem()
        {
            
        }

        public SelectedItem(int numberOfSelectedItem)
        {
            NumberOfSelectedItem = numberOfSelectedItem;
            
            CalculatePriceAfterDiscount();
        }

        private void CalculatePriceAfterDiscount()
        {
            if(Discount == null)
            {
                PriceAfterDiscount = Price;
            }else
            {
                var currentTime = DateTime.Now;
                if(currentTime >= Discount.StartTime && currentTime >= Discount.EndTime)
                {
                    if(Discount.DiscountPercent > 0)
                    {
                        PriceAfterDiscount = (int)(Price * (1 - 1.0f * Discount.DiscountPercent / 100));
                    }
                    if(Discount.DiscountAmount > 0)
                    {
                        PriceAfterDiscount = Price - Discount.DiscountAmount;
                    }
                }
            }
        }

        public SelectedItem(int itemId, string itemName, string itemType, int quantity, 
            string brand, DateTime releaseDate, int price, Discount discount, 
            int numberOfSelectedItem)
            :base(itemId, itemName, itemType, quantity, brand, releaseDate, price, discount) 
        {
            NumberOfSelectedItem = numberOfSelectedItem;
            PriceAfterDiscount = Price;
        }
    }
}
