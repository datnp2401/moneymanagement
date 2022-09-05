using MoneyManagement.Models;
using MoneyManagement.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagement.Views.Setting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingDetailPage : ContentPage
    {
        SettingDetailViewModel SettingDetailViewModel;

        public SettingsItem SettingsItem { get; set; } = new SettingsItem();
        public ObservableCollection<string> SettingType { get; set; }
        public int ChooseSettingIndex { get; set; }
        public string ChooseSettingType { get; set; }

        public SettingsDB SettingsDB = new SettingsDB();


        //public SettingDetailPage(SettingDetailViewModel settingsViewModel)
        //{
        //    InitializeComponent();

        //    BindingContext = this.SettingDetailViewModel = settingsViewModel;
        //}

        public SettingDetailPage(SettingsItem settingsItem)
        {
            InitializeComponent();

            this.SettingsItem = settingsItem;

            this.SettingType = new ObservableCollection<string>()
            {
                "Chi tiêu",
                "Tiết kiệm",
                "Đầu tư",
            };

            for (int i = 0; i < SettingType.Count; i++)
            {
                if (SettingType[i].Equals(SettingsItem.Tab))
                {
                    ChooseSettingIndex = i;
                }
            }
            ChooseSettingType = SettingsItem.Tab;

            BindingContext = this;

            syncfusionAmount.Culture = new System.Globalization.CultureInfo("vi-VN");
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            SettingsItem.Tab = ChooseSettingType;

            Settings setting = new Settings();
            setting.Id = SettingsItem.Id;
            setting.Tab = ChooseSettingType;
            setting.Code = SettingsItem.Code;
            setting.Name = SettingsItem.Name;

            setting.Percent = SettingsItem.Percent;

            SettingsDB.updateSetting(setting);

            MessagingCenter.Send(this, "EditItem", SettingsItem);
            await Navigation.PopAsync();
        }
    }
}