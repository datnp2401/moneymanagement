using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagement.Services
{
    public class SpendsData : IDataStore<Spends>
    {
        readonly List<Spends> items;

        public SpendsData()
        {
            items = new List<Spends>();
            //{
            //    new Spends { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
            //    new Spends { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
            //    new Spends { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
            //    new Spends { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
            //    new Spends { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
            //    new Spends { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            //};
        }

        public async Task<bool> AddItemAsync(Spends item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Spends item)
        {
            var oldItem = items.Where((Spends arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Spends arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Spends> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Spends>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

    }
}
