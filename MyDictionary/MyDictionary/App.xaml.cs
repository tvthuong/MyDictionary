using Prism.Ioc;
using Prism.Unity;

namespace MyDictionary
{
    public partial class App : PrismApplication
    {
        public App() : base() { }

        protected override void OnInitialized()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
