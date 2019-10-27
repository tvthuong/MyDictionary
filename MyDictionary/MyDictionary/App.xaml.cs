using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace MyDictionary
{
    public partial class App : PrismApplication
    {
        public App() : base() { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(nameof(NavigationPage));
        }
    }
}
