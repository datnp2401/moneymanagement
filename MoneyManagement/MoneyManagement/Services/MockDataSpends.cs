using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagement.Services
{
    public class MockDataSpends : IDataStore<SpendsItem>
    {
        readonly List<SpendsItem> items;
        public SpendsDB SpendsDB;
        public MockDataSpends()
        {
            SpendsDB = new SpendsDB();

            items = new List<SpendsItem>();

            List<Spends> lst = SpendsDB.GetSpends().OrderByDescending(x => x.Id).ToList();
            for (int i = 0; i < lst.Count(); i++)
            {
                SpendsItem spendsItem = new SpendsItem();

                spendsItem.Id = lst[i].Id;
                spendsItem.Content = lst[i].Content;
                spendsItem.Address = lst[i].Address;
                spendsItem.DateNo = lst[i].DateNo;
                spendsItem.Amount = lst[i].Amount;
                spendsItem.SpendType = lst[i].SpendType;
                spendsItem.TextColor = lst[i].TextColor;
                spendsItem.Tab = lst[i].Tab;

                items.Add(spendsItem);
            }

            items = items.OrderByDescending(x => x.Id).ToList();
        }

        public async Task<bool> AddItemAsync(SpendsItem item)
        {
            if (items.FindIndex(x => x.Id == item.Id) == -1)
            {
                items.Add(item);
            }


            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(SpendsItem item)
        {
            var oldItem = items.Where((SpendsItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((SpendsItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<SpendsItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<SpendsItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
