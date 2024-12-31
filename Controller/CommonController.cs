using System;
using System.Collections.Generic;
using Models;

/*
 * 
 * Lớp chứa các phương thức Generic<T> (tuỳ theo kiểu đối tượng T truyền vào qua lời gọi): Thêm, xoá, sửa, sắp xếp, tìm kiếm
 * 
 */

namespace Controller
{
    public class CommonController : ICommonController
    {
        public void AddNewItem<T>(List<T> list, T item)
        {
            list.Add(item);
        }

        public int DeleteItem<T>(List<T> list, T item)
        {
            int index = IndexOfItem(list, item);
            list.RemoveAt(index);
            return index;
        }

        public int IndexOfItem<T>(List<T> list, T item)
        {
            return list.IndexOf(item);
        }

        public List<T> Search<T, V>(List<T> list, FindItemDelegate1<T, V> del, V value)
        {
            List<T> result = new List<T>();
            if(value != null)
            {
                foreach (var item in list)
                {
                    if (del(item, value))
                    {
                        result.Add(item);
                    }
                }
            }            
            return result;
        }

        public List<T> Search<T>(List<T> list, FindItemDelegate2<T> del, int from, int to)
        {
            List<T> result = new List<T>();
            if(to != 0)
            {
                foreach (var item in list)
                {
                    if (del(item, from, to))
                    {
                        result.Add(item);
                    }
                }
            }                       
            return result;
        }

        public void Sort<T>(List<T> list, Comparison<T> comparer)
        {
            list.Sort(comparer);
        }

        // Cách khác test thử
        public void SortByPriceASC(List<Item> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                var pivot = list[i];
                for (int j = i; j < list.Count; j++)
                {
                    if (pivot.Price.CompareTo(list[j].Price) > 0)
                    {
                        pivot = list[j];
                        list[j] = list[i];
                        list[i] = pivot;
                    }
                }
            }
        }

        public int UpdateItem<T>(List<T> list, T oldItem, T newItem)
        {
            int index = IndexOfItem(list, oldItem);
            list.RemoveAt(index);
            list.Insert(index, newItem);
            return index;
        }

        public int UpdateItem<T>(List<T> list, T item)
        {
            int index = list.IndexOf(item);
            list.RemoveAt(index);
            list.Insert(index, item);
            return index;
        }
    }
}
