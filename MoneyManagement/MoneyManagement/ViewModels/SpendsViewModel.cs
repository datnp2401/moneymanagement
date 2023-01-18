using MoneyManagement.Models;
using MoneyManagement.Services;
using MoneyManagement.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoneyManagement.ViewModels
{
    public class SpendsViewModel : BaseViewModel
    {
        public ObservableCollection<SpendsItem> SpendsItemList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SpendsDB SpendsDB;
        public SettingsDB SettingsDB;
        public SpendsItem SpendsItem { get; set; } = new SpendsItem();

        public DateTime Date { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public string Content { get; set; }
        public double Amount { get; set; }
        public DateTime DateNo { get; set; } = DateTime.Now;
        public string SpendType { get; set; }

        public SpendsViewModel()
        {
            Title = "Thu - Chi";

            SpendsItemList = new ObservableCollection<SpendsItem>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SpendsDB = new SpendsDB();
            //var DateTimeNew = DateTime.Parse(Date);

            List<Spends> lst = SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
                                                               && x.DateNo.Year == Date.Year).OrderByDescending(x => x.Id).ToList();

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

                SpendsItemList.Add(spendsItem);
            }

            MessagingCenter.Subscribe<NewSpendsPage, SpendsItem>(this, "EditItem", async (obj, item) =>
            {
                IsBusy = true;

                var newItem = item as SpendsItem;
                for (int i = 0; i < SpendsItemList.Count; i++)
                {
                    if (SpendsItemList[i].Id == newItem.Id)
                    {
                        SpendsItemList[i] = newItem;
                    }
                }

                await SpendsDataStore.UpdateItemAsync(newItem);

                IsBusy = false;
            });

            MessagingCenter.Subscribe<NewSpendsPage, SpendsItem>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as SpendsItem;
                SpendsItemList.Insert(0, newItem);
                await SpendsDataStore.AddItemAsync(newItem);
                IsBusy = true;
                IsBusy = false;
            });


            base.OnPropertyChanged(nameof(Date));
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                SpendsItemList.Clear();
                //var DateTimeNew = DateTime.Parse(Date);

                var items = await SpendsDataStore.GetItemsAsync(true);

                List<SpendsItem> itemList = items.Where(x => x.Id > 0 && x.DateNo.Month == Date.Month
                                                        && x.DateNo.Year == Date.Year).OrderByDescending(x => x.Id).ToList();

                foreach (var item in itemList)
                {
                    SpendsItemList.Add(item);
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
