using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyManagement.Services;
using MoneyManagement.Views;

namespace MoneyManagement
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockDataSpends>();
            MainPage = new MainPage();
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
