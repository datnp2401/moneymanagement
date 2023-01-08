﻿using MoneyManagement.Models;
using MoneyManagement.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSpendsPage : ContentPage
    {
        public SpendsItem SpendsItem { get; set; } = new SpendsItem();
        public ObservableCollection<Settings> SpendType { get; set; }

        public Settings ChooseSpendType { get; set; }

        public string txtSpend { get; set; }

        public int ChooseSpendIndex { get; set; } = 2;

        public SpendsDB SpendsDB = new SpendsDB();
        public SettingsDB SettingsDB = new SettingsDB();

        public bool IsCheckSpend { get; set; } = false;

        public NewSpendsPage()
        {
            InitializeComponent();


            //BindingContext = _NewSpendsViewModel = new NewSpendsViewModel();

            List<Settings> lstSetting = SettingsDB.GetSettings().OrderBy(x => x.Id).ToList();

            SpendType = new ObservableCollection<Settings>();

            foreach (var item in lstSetting)
            {
                //SpendType.Add(item.Name + " 一【" + item.Tab + "】");
                SpendType.Add(item);
            }

            ChooseSpendType = SpendType.First();
            txtSpend = "Chi";
            SpendsItem.TextColor = "Red";

            BindingContext = this;
            syncfusionAmount.Culture = new System.Globalization.CultureInfo("vi-VN");

        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            SpendsItem.SpendType = ChooseSpendType.Name;


            Spends spends = new Spends();
            spends.SpendType = ChooseSpendType.Name;
            spends.SpendTypeCode = ChooseSpendType.Code;
            spends.Tab = ChooseSpendType.Tab;
            spends.Content = SpendsItem.Content;
            spends.Address = SpendsItem.Address;

            spends.DateNo = SpendsItem.DateNo;
            spends.TextColor = SpendsItem.TextColor;

            if (SpendsItem.TextColor.Equals("Green"))
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
                SpendsItem.Amount = -1 * SpendsItem.Amount;
            }

            spends.Amount = SpendsItem.Amount;

            SpendsDB.AddUser(spends);

            SpendsItem.Id = SpendsDB.GetSpends().Count;

            MessagingCenter.Send(this, "AddItem", SpendsItem);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
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
                SpendsItem.Amount = -1 * SpendsItem.Amount;
            }
        }
    }
}