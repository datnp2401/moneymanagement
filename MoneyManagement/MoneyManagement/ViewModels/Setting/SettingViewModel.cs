using MoneyManagement.Models;
using MoneyManagement.Views.Setting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoneyManagement.ViewModels.Setting
{
    public class SettingViewModel : BaseViewModel
    {
        public ObservableCollection<SettingsItem> SettingsItemList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SettingsDB SettingsDB;

        public SettingsItem SettingsItem { get; set; } = new SettingsItem();

        public string Code { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }
        public string Tab { get; set; }


        public SettingViewModel()
        {
            Title = "Setting";
            SettingsItemList = new ObservableCollection<SettingsItem>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SettingsDB = new SettingsDB();

            List<Settings> lst = SettingsDB.GetSettings().OrderByDescending(x => x.Tab).ToList();

            for (int i = 0; i < lst.Count(); i++)
            {
                SettingsItem settingsItem = new SettingsItem();

                settingsItem.Id = lst[i].Id;
                settingsItem.Code = lst[i].Code;
                settingsItem.Name = lst[i].Name;
                settingsItem.Tab = lst[i].Tab;
                settingsItem.Percent = lst[i].Percent;

                SettingsItemList.Add(settingsItem);
            }

            MessagingCenter.Subscribe<NewSettingPage, SettingsItem>(this, "EditItem", async (obj, item) =>
            {
                IsBusy = true;

                var newItem = item as SettingsItem;
                for (int i = 0; i < SettingsItemList.Count; i++)
                {
                    if (SettingsItemList[i].Id == newItem.Id)
                    {
                        SettingsItemList[i] = newItem;
                    }
                }

                await SettingsDataStore.UpdateItemAsync(newItem);

                IsBusy = false;
            });

            MessagingCenter.Subscribe<NewSettingPage, SettingsItem>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as SettingsItem;
                SettingsItemList.Insert(0, newItem);
                await SettingsDataStore.AddItemAsync(newItem);
                IsBusy = true;
                IsBusy = false;
            });

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                SettingsItemList.Clear();
                var items = await SettingsDataStore.GetItemsAsync(true);

                List<SettingsItem> itemList = items.Where(x => x.Id > 0).OrderByDescending(x => x.Tab).ToList();

                foreach (var item in itemList)
                {
                    SettingsItemList.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
