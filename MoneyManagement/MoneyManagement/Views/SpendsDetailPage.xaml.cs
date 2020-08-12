using MoneyManagement.Models;
using MoneyManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagement.Views
{

    [DesignTimeVisible(false)]
    public partial class SpendsDetailPage : ContentPage
    {
        SpendsDetailViewModel SpendsDetailViewModel;

        public SpendsItem SpendsItem { get; set; } = new SpendsItem();
        public ObservableCollection<string> SpendType { get; set; }
        public int ChooseSpendIndex { get; set; }
        public string ChooseSpendType { get; set; }

        public SpendsDB SpendsDB = new SpendsDB();

        public string txtSpend { get; set; }

        public SpendsDetailPage(SpendsDetailViewModel spendsViewModel)
        {
            InitializeComponent();
            BindingContext = this.SpendsDetailViewModel = spendsViewModel;
        }

        public SpendsDetailPage(SpendsItem spendsItem)
        {
            InitializeComponent();

            this.SpendsItem = spendsItem;

            this.SpendType = new ObservableCollection<string>()
            {
                "Ăn uống",
                "Du lịch",
                "Trả nợ",
                "Tiết kiệm",
                "Đầu tư",
                "Mua sắm",
                "Lương"
            };

            txtSpend = "Chi";
            SpendsItem.TextColor = "Red";

            for (int i = 0; i < SpendType.Count; i++)
            {
                if (SpendType[i].Equals(SpendsItem.SpendType))
                {
                    ChooseSpendIndex = i;
                }
            }
            ChooseSpendType = SpendsItem.SpendType;

            BindingContext = this;
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            SpendsItem.SpendType = ChooseSpendType;

            Spends spends = new Spends();
            spends.Id = SpendsItem.Id;
            spends.SpendType = ChooseSpendType;
            spends.Content = SpendsItem.Content;
            spends.Address = SpendsItem.Address;
            spends.Amount = SpendsItem.Amount;
            spends.DateNo = SpendsItem.DateNo;
            spends.TextColor = SpendsItem.TextColor;

            SpendsDB.updateUser(spends);

            MessagingCenter.Send(this, "EditItem", SpendsItem);
            await Navigation.PopAsync();
        }

        private void IsSpend_Toggled(object sender, ToggledEventArgs e)
        {
            Switch check = (Switch)sender;
            if (check.IsToggled)
            {
                txtSpend = "Thu";
                lbSpend.Text = "Thu";
                lbSpend.TextColor = Color.Green;
                SpendsItem.TextColor = "Green";
            }
            else
            {
                txtSpend = "Chi";
                lbSpend.Text = "Chi";
                lbSpend.TextColor = Color.Red;
                SpendsItem.TextColor = "Red";
            }
        }
    }
}