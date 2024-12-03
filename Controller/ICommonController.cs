using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public delegate bool FindItemDelegate1<T, V>(T item, V value);
    public delegate bool FindItemDelegate2<T>(T item, int from, int to);
    public interface ICommonController
    {
        void AddNewItem<T>(List<T> list, T item);
        int UpdateItem<T>(List<T> list, T oldItem, T newItem);
        int DeleteItem<T>(List<T> list, T item);
        int IndexOfItem<T>(List<T> list, T item);
        void Sort<T>(List<T> list, Comparison<T> comparer);
        List<T> Search<T, V>(List<T> list, FindItemDelegate1<T, V> del, V value);
        List<T> Search<T>(List<T> list, FindItemDelegate2<T> del, int from, int to);
    }
}
