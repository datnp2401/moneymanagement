using MoneyManagement.ViewModels.TotalSpend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManagement.Views.TotalSpend
{
    [DesignTimeVisible(false)]
    public partial class TotalPage : ContentPage
    {
        TotalViewModel TotalViewModel;
        public TotalPage()
        {
            InitializeComponent();
            BindingContext = TotalViewModel = new TotalViewModel();
        }

    }
}