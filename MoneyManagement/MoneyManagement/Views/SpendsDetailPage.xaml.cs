﻿using MoneyManagement.Models;
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
        public ObservableCollection<Settings> SpendType { get; set; }
        public int ChooseSpendIndex { get; set; }
        public Settings ChooseSpendType { get; set; }

        public SpendsDB SpendsDB = new SpendsDB();
        public SettingsDB SettingsDB = new SettingsDB();

        public string txtSpend { get; set; }

        //public SpendsDetailPage(SpendsDetailViewModel spendsViewModel)
        //{
        //    InitializeComponent();
        //    BindingContext = this.SpendsDetailViewModel = spendsViewModel;
        //}

        public SpendsDetailPage(SpendsItem spendsItem)
        {
            InitializeComponent();

            //checkUpdateItem = true;

            this.SpendsItem = spendsItem;

            if (this.SpendsItem.Amount < 0)
            {
                //this.SpendsItem.Amount = this.SpendsItem.Amount;
                IsSpend.IsToggled = false;
            }
            else
            {
                IsSpend.IsToggled = true;
            }


            List<Settings> lstSetting = SettingsDB.GetSettings().OrderBy(x => x.Tab).ToList();

            SpendType = new ObservableCollection<Settings>();

            foreach (var item in lstSetting)
            {
                SpendType.Add(item);
            }

            if (spendsItem != null && string.IsNullOrEmpty(spendsItem.TextColor))
            {
                txtSpend = "Chi";
            }
            else if (spendsItem != null && !string.IsNullOrEmpty(spendsItem.TextColor))
            {
                if (spendsItem.TextColor.Equals("Green"))
                {
                    txtSpend = "Thu";
                }
                else
                {
                    txtSpend = "Chi";
                }

            }

            //SpendsItem.TextColor = "Red";

            for (int i = 0; i < SpendType.Count; i++)
            {
                if (SpendType[i].Name.Equals(SpendsItem.SpendType))
                {
                    ChooseSpendIndex = i;
                    ChooseSpendType = SpendType[i];
                }
            }


            BindingContext = this;

            syncfusionAmount.Culture = new System.Globalization.CultureInfo("vi-VN");
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            SpendsItem.SpendType = ChooseSpendType.Name;
            SpendsItem.SpendTypeCode = ChooseSpendType.Code;
            SpendsItem.Tab = ChooseSpendType.Tab;

            Spends spends = new Spends();
            spends.Id = SpendsItem.Id;
            spends.SpendTypeCode = ChooseSpendType.Code;
            spends.SpendType = ChooseSpendType.Name;
            spends.Tab = ChooseSpendType.Tab;
            spends.Content = SpendsItem.Content;
            spends.Address = SpendsItem.Address;

            spends.DateNo = SpendsItem.DateNo;
            spends.TextColor = SpendsItem.TextColor;

            if (IsSpend.IsToggled)
            {
                txtSpend = "Thu";
                lbSpend.Text = "Thu";
                lbSpend.TextColor = Color.Green;
                SpendsItem.TextColor = "Green";
                SpendsItem.Amount = Math.Abs(SpendsItem.Amount);
            }
            else
            {
                txtSpend = "Chi";
                lbSpend.Text = "Chi";
                lbSpend.TextColor = Color.Red;
                SpendsItem.TextColor = "Red";
                SpendsItem.Amount = Math.Abs(SpendsItem.Amount);
                SpendsItem.Amount = -SpendsItem.Amount;
            }

            spends.Amount = SpendsItem.Amount;

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
                SpendsItem.Amount = Math.Abs(SpendsItem.Amount);
            }
            else
            {
                txtSpend = "Chi";
                lbSpend.Text = "Chi";
                lbSpend.TextColor = Color.Red;
                SpendsItem.TextColor = "Red";
                SpendsItem.Amount = Math.Abs(SpendsItem.Amount);
                SpendsItem.Amount = -SpendsItem.Amount;
            }
        }
    }
}