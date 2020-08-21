using MoneyManagement.ViewModels.TotalAllMoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagement.Views.TotalAllMoney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TotalAllMoneyPage : ContentPage
    {
        TotalAllMoneyViewModel TotalAllMoneyViewModel;
        public TotalAllMoneyPage()
        {
            InitializeComponent();
            BindingContext = TotalAllMoneyViewModel = new TotalAllMoneyViewModel();
        }
    }
}