using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace MyDictionary.Customs
{
    public class CustomObservableCollection<T> : ObservableCollection<T>
    {
        private bool _isNotNotify;
        private readonly object _isUpdating = new object();

        public void Replace(IEnumerable<T> items)
        {
            lock (_isUpdating)
            {
                _isNotNotify = true;
                if (items == null)
                {
                    Clear();
                }
                else if (Count == items.Count())
                {
                    for (var i = 0; i < items.Count(); i++)
                    {
                        this[i] = items.ElementAt(i);
                    }
                }
                else
                {
                    Clear();
                    foreach (var item in items)
                    {
                        Add(item);
                    }
                }
                _isNotNotify = false;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_isNotNotify)
            {
                base.OnCollectionChanged(e);
            }
        }
    }
}
