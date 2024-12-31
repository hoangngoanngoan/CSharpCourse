using System;

namespace Models
{
     
    public class SelectedItem : Item
    {
        
        public int NumberOfSelectedItem { get; set; } = 0;
        
        public SelectedItem()
        {

        }

        public SelectedItem(Item item, int numberOfSelectedItem) : base(item.ItemId, item.ItemName, item.ItemType, item.Quantity 
            ,item.Brand, item.ReleaseDate, item.Price, item.Discount)
        {
            NumberOfSelectedItem = numberOfSelectedItem;
        }

        public SelectedItem(int numberOfSelectedItem)
        {
            NumberOfSelectedItem = numberOfSelectedItem;
        }

        public SelectedItem(int itemId, string itemName, string itemType, int quantity,
            string brand, DateTime releaseDate, int price, Discount discount,
            int numberOfSelectedItem)
            : base(itemId, itemName, itemType, quantity, brand, releaseDate, price, discount)
        {
            NumberOfSelectedItem = numberOfSelectedItem;
        }

        public void UpdateQuantity(int i)
        {
            Quantity -= i;
        }
    }
}
