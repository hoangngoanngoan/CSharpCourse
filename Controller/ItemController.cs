using Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Controller
{
    public class ItemController : IItemController
    {
        public int CompareItemByDate(Item item1, Item item2)
        {
            return item1.ReleaseDate.CompareTo(item2.ReleaseDate);
        }

        public int CompareItemByName(Item item1, Item item2)
        {
            return item1.ItemName.CompareTo(item2.ItemName);
        }

        public int CompareItemByPriceASC(Item item1, Item item2)
        {
            return item1.Price.CompareTo(item2.Price);
        }

        public int CompareItemByPriceDSC(Item item1, Item item2)
        {
            return item2.Price.CompareTo(item1.Price);
        }

        public int CompareItemByQuantityDSC(Item item1, Item item2)
        {
            return item2.Quantity.CompareTo(item1.Quantity);
        }

        public bool IsItemBrandMatch(Item item, string brand)
        {
            var pattern = $".*{brand}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(item.Brand);
        }

        public bool IsItemNameMatch(Item item, string name)
        {
            var pattern = $".*{name}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(item.ItemName);
        }

        public bool IsItemPriceMatch(Item item, int from, int to)
        {
            return item.Price >= from && item.Price <= to;  
        }

        public bool IsItemTypeMatch(Item item, string type)
        {
            var pattern = $".*{type}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(item.ItemType);
        }

        public bool IsItemQuantityMatch(Item item, int from, int to)
        {
            return item.Quantity >= from && item.Quantity <= to;
        }
    }
}
