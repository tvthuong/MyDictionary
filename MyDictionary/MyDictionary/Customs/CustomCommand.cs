using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Xamarin.Forms;

namespace MyDictionary.Customs
{
    public class CustomCommand : Command
    {
        public CustomCommand(Action action) : base(action) { }

        public CustomCommand(Action action, Expression<Func<bool>> expression,
            INotifyCollectionChanged[] collections = null)
            : base(action, expression.Compile())
        {
            InitializeCommand((MemberExpression)expression.Body, collections);
        }

        public CustomCommand(Action<object> action) : base(action) { }

        public CustomCommand(Action<object> action, Expression<Func<object, bool>> expression,
            INotifyCollectionChanged[] collections = null)
            : base(action, expression.Compile())
        {
            InitializeCommand((MemberExpression)expression.Body, collections);
        }

        private void InitializeCommand(MemberExpression memberExpression, INotifyCollectionChanged[] collections)
        {
            var viewModel = (INotifyPropertyChanged)((ConstantExpression)memberExpression?.Expression)?.Value;
            var propertyName = memberExpression?.Member?.Name;
            if (viewModel != null && propertyName != null)
            {
                viewModel.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == propertyName)
                    {
                        ChangeCanExecute();
                    };
                };

                collections?.ToList().ForEach(collection =>
                {
                    collection.CollectionChanged += (sender, e) =>
                    {
                        ChangeCanExecute();
                    };
                });
            }
        }
    }
}
