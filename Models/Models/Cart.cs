using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Cart : IComparable<Cart>
    {
        [JsonIgnore]
        private static int s_autoId = 1000000;

        [JsonProperty("cartId")]
        public int CartId { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("selectedItems")]
        public List<SelectedItem> SelectedItems { get; set; } = new List<SelectedItem>();


        public Cart(){ }

        public Cart(int id)
        {
            CartId = id > 0 ? id : ++s_autoId;
        }

        public Cart(int id, Customer customer, List<SelectedItem> selectedItems):this(id)
        {
            Customer = customer;
            SelectedItems = selectedItems;
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
