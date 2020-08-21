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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA2NTU3QDMxMzgyZTMyMmUzMFhNNmJuM0xoWSs1eHRrbzRub3I1QXppcTc0bWJhdUI2alhkVjNWU0wyd3c9");

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
