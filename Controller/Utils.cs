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
            items.Add(new Customer("0123456789123", "Lương Đình Hoàng", DateTime.ParseExact("23/08/1995","dd/MM/yyyy", null), "248 Phương Sài tp.Nha Trang", "0705154714", "Mua lẻ", 10, DateTime.Now, "ldh2381995@gmail.com"));
            items.Add(new Customer("0123456789124", "Lương Đình Huy", DateTime.ParseExact("17/03/1994","dd/MM/yyyy", null), "248 Phương Sài tp.Nha Trang", "0705154714", "Mua lẻ", 10, DateTime.Now, "ldh17071994@gmail.com"));
            items.Add(new Customer("0123456789125", "Lương Điền Hồ Ngọc", DateTime.ParseExact("20/11/2006","dd/MM/yyyy", null), "248 Phương Sài tp.Nha Trang", "0705154714", "Mua lẻ", 10, DateTime.Now, "ldh17071994@gmail.com"));
            items.Add(new Customer("0123456789126", "Lương Tiểu Diệp Nghĩa", DateTime.ParseExact("17/05/2010","dd/MM/yyyy", null), "248 Phương Sài tp.Nha Trang", "0705154714", "Mua lẻ", 10, DateTime.Now, "ldh17071994@gmail.com"));
            return items;
        }
    }
}
