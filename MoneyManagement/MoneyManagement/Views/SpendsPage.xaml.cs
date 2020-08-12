using MoneyManagement.Models;
using MoneyManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagement.Views
{
    [DesignTimeVisible(false)]
    public partial class SpendsPage : ContentPage
    {
        SpendsViewModel SpendsViewModel;
        public SpendsPage()
        {
            InitializeComponent();
            BindingContext = SpendsViewModel = new SpendsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (SpendsItem)layout.BindingContext;
            await Navigation.PushAsync(new SpendsDetailPage(item));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSpendsPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (SpendsViewModel.SpendsItemList.Count == 0)
                SpendsViewModel.IsBusy = true;
        }

    }
}