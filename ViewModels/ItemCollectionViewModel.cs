using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WonderGraphGeneratorWpf.ViewModels
{
    public class ItemCollectionViewModel : ViewModelBase, ICollection<ItemViewModel>, INotifyCollectionChanged, IList
    {
        private readonly ObservableCollection<ItemViewModel> data = new ObservableCollection<ItemViewModel>()
        {
            new ItemViewModel(){IsEnabled=true, Value=40, Label="なるほど", Color = Color.FromRgb(0xa8, 0x89, 0x0a)},
            new ItemViewModel(){IsEnabled=true, Value=60, Label="よくわかる", Color = Color.FromRgb(0xa1, 0x35, 0x2a)},
            new ItemViewModel(){IsEnabled=true, Value=30, Label="そうですか", Color = Color.FromRgb(0x24, 0x6a, 0x99)},
            new ItemViewModel(){IsEnabled=true, Value=40, Label="ふーん", Color = Color.FromRgb(0x20, 0x8e, 0x4f)},
            new ItemViewModel(){IsEnabled=true, Value=10, Label="その他", Color = Color.FromRgb(0x84, 0x88, 0x8b)},
        };

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add { data.CollectionChanged += value; }
            remove { data.CollectionChanged -= value; }
        }

        public void Add(ItemViewModel item)
        {
            data.Add(item);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(ItemViewModel item)
        {
            return data.Contains(item);
        }

        public void CopyTo(ItemViewModel[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return data.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ItemViewModel item)
        {
            return data.Remove(item);
        }

        public IEnumerator<ItemViewModel> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        int IList.Add(object value)
        {
            data.Add((ItemViewModel)value);
            return Count - 1;
        }

        void IList.Clear()
        {
            data.Clear();
        }

        bool IList.Contains(object value)
        {
            return data.Contains((ItemViewModel)value);
        }

        int IList.IndexOf(object value)
        {
            return data.IndexOf((ItemViewModel)value);
        }

        void IList.Insert(int index, object value)
        {
            data.Insert(index, (ItemViewModel)value);
        }

        bool IList.IsFixedSize
        {
            get { return true; }
        }

        bool IList.IsReadOnly
        {
            get { return false; }
        }

        void IList.Remove(object value)
        {
            data.Remove((ItemViewModel)value);
        }

        void IList.RemoveAt(int index)
        {
            data.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = (ItemViewModel)value;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        int ICollection.Count
        {
            get { return data.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get { return null; }
        }
    }
}
