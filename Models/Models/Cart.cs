using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart : IComparable<Cart>
    {
        private static int s_autoId = 1000000;
        public int CartId { get; set; }
        public Customer Customer { get; set; }
        public List<SelectedItem> SelectedItems { get; set; } = new List<SelectedItem>();

        public int TotalItems { get; set; }

        public Cart()
        {
            
        }

        public Cart(int id)
        {
            CartId = id > 0 ? id : s_autoId++;
        }

        public Cart(int id, Customer customer, List<SelectedItem> selectedItems, int totalItems):this(id)
        {
            Customer = customer;
            SelectedItems = selectedItems;
            TotalItems = totalItems;
        }

        public override bool Equals(object obj)
        {
            return obj is Cart cart &&
                   CartId == cart.CartId;
        }

        public override int GetHashCode()
        {
            return -1568810734 + CartId.GetHashCode();
        }

        public int CompareTo(Cart other)
        {
            return CartId - other.CartId;
        }
        public static void UpDateAutoId(int v)
        {
            s_autoId = v;
        }
    }
}
