using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoneyManagement.ViewModels
{
    class NewSpendsViewModel : BaseViewModel
    {
        //public string Address { get; set; }
        //public string Content { get; set; }
        //public double Amount { get; set; }
        //public DateTime DateNo { get; set; } = DateTime.Now;

        //public SpendsDB SpendsDB = new SpendsDB();
        //public Spends Spends { get; set; } = new Spends();

        //public ObservableCollection<string> SpendType { get; set; }

        //public string ChooseSpendType { get; set; }
        //public ICommand AddItemsCommand { get; }

        //public NewSpendsViewModel()
        //{
        //    SpendType = new ObservableCollection<string>()
        //    {
        //        "Ăn uống",
        //        "Du lịch",
        //        "Trả nợ",
        //        "Tiết kiệm",
        //        "Đầu tư",
        //        "Mua sắm",
        //        "Lương"
        //    };
        //    AddItemsCommand = new Command(ExecuteAddItemsCommand);
        //}

        //private void ExecuteAddItemsCommand()
        //{
        //    IsBusy = true;
        //    try
        //    {

        //        Spends.Content = this.Content;
        //        Spends.Address = this.Address;
        //        Spends.SpendType = this.ChooseSpendType;
        //        Spends.Amount = this.Amount;
        //        Spends.DateNo = this.DateNo;

        //        SpendsDB.AddUser(Spends);
        //    }
        //    catch (Exception ex)
        //    {

        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }

        //}
    }
}
