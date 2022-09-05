using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagement.Services
{
    public class MockDataSettings : IDataStore<SettingsItem>
    {
        readonly List<SettingsItem> items;
        public SettingsDB SettingsDB;
        public MockDataSettings()
        {
            SettingsDB = new SettingsDB();

            items = new List<SettingsItem>();

            List<Settings> lst = SettingsDB.GetSettings().OrderByDescending(x => x.Id).ToList();
            for (int i = 0; i < lst.Count(); i++)
            {
                SettingsItem settingsItem = new SettingsItem();

                settingsItem.Id = lst[i].Id;
                settingsItem.Code = lst[i].Code;
                settingsItem.Name = lst[i].Name;
                settingsItem.Tab = lst[i].Tab;
                settingsItem.Percent = lst[i].Percent;


                items.Add(settingsItem);
            }

            items = items.OrderByDescending(x => x.Id).ToList();
        }

        public async Task<bool> AddItemAsync(SettingsItem item)
        {
            if (items.FindIndex(x => x.Id == item.Id) == -1)
            {
                items.Add(item);
            }


            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(SettingsItem item)
        {
            var oldItem = items.Where((SettingsItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((SettingsItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<SettingsItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<SettingsItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
