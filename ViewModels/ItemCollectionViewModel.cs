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
            new ItemViewModel(){IsEnabled=true, Value=40, Label="なるほど", Color1 = "#a8890a", Color2 = "#f3c50f"},
            new ItemViewModel(){IsEnabled=true, Value=60, Label="よくわかる", Color1 = "#a1352a", Color2 = "#e94c3c"},
            new ItemViewModel(){IsEnabled=true, Value=30, Label="そうですか", Color1 = "#246a99", Color2 = "#3499dd"},
            new ItemViewModel(){IsEnabled=true, Value=40, Label="ふーん", Color1 = "#208e4f", Color2 = "#2ece72"},
            new ItemViewModel(){IsEnabled=true, Value=10, Label="その他", Color1 = "#84888b", Color2 = "#bec4c3"},
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
