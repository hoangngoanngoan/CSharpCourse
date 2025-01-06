using Newtonsoft.Json;
using System;

namespace Models
{
    public class Item : IComparable<Item>, ICloneable
    {
        [JsonIgnore]
        private static int s_autoId = 1000000;

        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("discount")]
        public Discount Discount { get; set; } = null;

        public Item() { }

        public Item(int id)
        {
            ItemId = id > 0 ? id : ++s_autoId;
        }

        public Item(int itemId, string itemName, string itemType, int quantity, string brand, DateTime releaseDate, int price, Discount discount) : this(itemId)
        {
            ItemName = itemName;
            ItemType = itemType;
            Quantity = quantity;
            Brand = brand;
            ReleaseDate = releaseDate;
            Price = price;
            Discount = discount;
        }

        public static void UpDateAutoId(int v)
        {
            s_autoId = v;
        }

        public int CompareTo(Item other)
        {
            return ItemId - other.ItemId;
        }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   ItemId == item.ItemId;
        }

        public override int GetHashCode()
        {
            return -2113648141 + ItemId.GetHashCode();
        }

        public object Clone()
        {
            return new Item(ItemId, ItemName, ItemType, Quantity, Brand, ReleaseDate, Price, null);
        }
    }
}
