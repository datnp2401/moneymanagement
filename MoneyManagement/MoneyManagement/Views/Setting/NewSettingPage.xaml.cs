using MoneyManagement.Models;
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
    public partial class NewSettingPage : ContentPage
    {
        public SettingsItem SettingsItem { get; set; } = new SettingsItem();
        public ObservableCollection<string> SettingType { get; set; }

        public string ChooseSettingType { get; set; }

        public string txtSetting { get; set; }

        public int ChooseSettingIndex { get; set; } = 0;

        public SettingsDB SettingsDB = new SettingsDB();

        public bool IsCheckSetting { get; set; } = false;

        public NewSettingPage()
        {
            InitializeComponent();

            SettingType = new ObservableCollection<string>()
            {
                "Chi tiêu",
                "Tiết kiệm",
                "Đầu tư"
            };
            ChooseSettingType = "Chi tiêu";
            txtSetting = "Chi";

            BindingContext = this;
            syncfusionPercent.Culture = new System.Globalization.CultureInfo("vi-VN");
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            SettingsItem.Tab = ChooseSettingType;


            Settings settings = new Settings();
            settings.Tab = ChooseSettingType;
            settings.Code = SettingsItem.Code;
            settings.Name = SettingsItem.Name;

            settings.Percent = SettingsItem.Percent;


            SettingsDB.AddSetting(settings);

            SettingsItem.Id = SettingsDB.GetSettings().Count;

            MessagingCenter.Send(this, "AddItem", SettingsItem);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}