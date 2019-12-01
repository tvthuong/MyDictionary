using Prism.Navigation;
using PropertyChanged;

namespace MyDictionary.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase : INavigationAware
    {
        public bool IsBusy { get; set; }
        public string Title { get; set; }

        protected INavigationService NavigationService { get; private set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }
        
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
        
        public virtual void OnNavigatingTo(INavigationParameters parameters) { }
    }
}
