using System;
using System.Collections.Generic;
using Models;

namespace Controller
{
    public class Utils
    {
        public static List<Item> CreateFakeItem()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item(0, "Iphone 14", "Điện tử", 25, "Apple", DateTime.Now, 25000000, null));
            items.Add(new Item(0, "Iphone 15", "Điện tử", 20, "Apple", DateTime.Now, 26000000, null));
            items.Add(new Item(0, "Samsung galaxy s ultra", "Điện tử", 20, "Samsung", DateTime.Now, 19000000, null));
            items.Add(new Item(0, "Xà lách", "Thực phẩm", 23, "Bách hoá xanh", DateTime.Now, 15000, null));
            items.Add(new Item(0, "Bí đao", "Thực phẩm", 21, "Bách hoá xanh", DateTime.Now, 10000, null));
            items.Add(new Item(0, "Khổ qua", "Thực phẩm", 10, "Bách hoá xanh", DateTime.Now, 20000, null));
            items.Add(new Item(0, "Mì gói", "Thực phẩm", 50, "Hảo Hảo", DateTime.Now, 13000, null));
            items.Add(new Item(0, "Áo sơ mi tay dài", "Thời trang", 90, "An Phước", DateTime.Now, 1000000, null));
            items.Add(new Item(0, "Quần âu", "Thời trang", 29, "An Phước", DateTime.Now, 800000, null));
            items.Add(new Item(0, "Xi măng", "Vật liệu xây dựng", 58, "Tân Thành", DateTime.Now, 200000, null));
            items.Add(new Item(0, "Gạch", "Vật liệu xây dựng", 60, "Tân Thành", DateTime.Now, 5000, null));
            return items;
        }

        public static List<Customer> CreateFakeCustomer()
        {
            List<Customer> items = new List<Customer>();
            items.Add(new Customer("", "Lương Đình Hoàng", DateTime.Now, "248 Phương Sài tp.Nha Trang", "0705154714", "Vip", 10, DateTime.Now, "ldh2381995@gmail.com"));
            items.Add(new Customer("", "Lương Đình Huy", DateTime.Now, "248 Phương Sài tp.Nha Trang", "0705154714", "Vip", 10, DateTime.Now, "ldh2381995@gmail.com"));
            return items;
        }
    }
}
