using MoneyManagement.Models;
using MoneyManagement.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagement.Views.Setting
{
    [DesignTimeVisible(false)]
    public partial class SettingPage : ContentPage
    {
        SettingViewModel SettingViewModel;
        public SettingPage()
        {
            InitializeComponent();
            BindingContext = SettingViewModel = new SettingViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (SettingsItem)layout.BindingContext;
            await Navigation.PushAsync(new SettingDetailPage(item));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSettingPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (SettingViewModel.SettingsItemList.Count == 0)
                SettingViewModel.IsBusy = true;
        }
    }
}