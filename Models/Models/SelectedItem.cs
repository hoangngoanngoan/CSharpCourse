using System;
using System.Diagnostics;

namespace Models
{
     
    public class SelectedItem : Item, IComparable<SelectedItem>, ICloneable
    {
        
        public int NumberOfSelectedItem { get; set; } = 0;
        
        public SelectedItem()
        {

        }

        public SelectedItem(Item item, int numberOfSelectedItem) : base(item.ItemId, item.ItemName, item.ItemType, item.Quantity 
            ,item.Brand, item.ReleaseDate, item.Price, item.Discount)
        {
            if(item.Discount == null)
            {
                this.Discount = new Discount();
            }
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

        public int CompareTo(SelectedItem other)
        {
            return ItemId - other.ItemId;
        }

        public override bool Equals(object obj)
        {
            if(obj is Item other)
            {
                return this.ItemId == other.ItemId;
            }
            return obj is SelectedItem item &&
                   ItemId == item.ItemId;
        }

        public override int GetHashCode()
        {
            int hashCode = -2127699887;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + ItemId.GetHashCode();
            return hashCode;
        }

        public object Clone()
        {
            return new SelectedItem(ItemId, ItemName, ItemType, Quantity,
                Brand, ReleaseDate, Price, Discount,
                NumberOfSelectedItem);
        }
    }
}
