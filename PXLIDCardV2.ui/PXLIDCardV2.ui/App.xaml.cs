using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PXLIDCardV2.ui.Views;
using PXLIDCardV2.ui.ViewModels;
using PXLIDCardV2.ui.Util;
using PXLIDCardV2.ui.Services;

namespace PXLIDCardV2.ui
{
    public partial class App : Application
    {
        public App()
        {
            AppContainer.RegisterDependencies();
            InitializeComponent();
            var mainView = new MainView
            {
                BindingContext = new MainViewModel()
            };
            MainPage = mainView;
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
