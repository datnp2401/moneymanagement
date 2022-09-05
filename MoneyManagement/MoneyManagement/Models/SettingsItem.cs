using MoneyManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagement.Models
{
    public class SettingsItem : BaseViewModel
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { SetProperty<int>(ref _Id, value, () => OnPropertyChanged(nameof(Id))); }
        }

        private string _Code;
        public string Code
        {
            get => _Code;
            set { SetProperty<string>(ref _Code, value, () => OnPropertyChanged(nameof(Code))); }
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set { SetProperty<string>(ref _Name, value, () => OnPropertyChanged(nameof(Name))); }
        }

        private decimal _Percent;
        public decimal Percent
        {
            get => _Percent;
            set { SetProperty<decimal>(ref _Percent, value, () => OnPropertyChanged(nameof(Percent))); }
        }

        private string _Tab;
        public string Tab
        {
            get => _Tab;
            set { SetProperty<string>(ref _Tab, value, () => OnPropertyChanged(nameof(Tab))); }
        }

    }
}
