using MyDictionary.Business;
using Prism.Ioc;
using Prism.Unity;
using System;

namespace MyDictionary
{
    public partial class App : PrismApplication
    {
        public App() : base() { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            DictionaryBD.Instance.Initialize(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
