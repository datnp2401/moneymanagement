using MoneyManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagement.Models
{
    public class SpendsItem : BaseViewModel
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set { SetProperty<int>(ref _Id, value, () => OnPropertyChanged(nameof(Id))); }
        }

        private decimal _Amount;
        public decimal Amount
        {
            get => _Amount;
            set { SetProperty<decimal>(ref _Amount, value, () => OnPropertyChanged(nameof(Amount))); }
        }

        private string _Content;
        public string Content
        {
            get => _Content;
            set { SetProperty<string>(ref _Content, value, () => OnPropertyChanged(nameof(Content))); }
        }

        private string _Address;
        public string Address
        {
            get => _Address;
            set { SetProperty<string>(ref _Address, value, () => OnPropertyChanged(nameof(Address))); }
        }

        private string _SpendType;
        public string SpendType
        {
            get => _SpendType;
            set { SetProperty<string>(ref _SpendType, value, () => OnPropertyChanged(nameof(SpendType))); }
        }

        private string _SpendTypeCode;
        public string SpendTypeCode
        {
            get => _SpendTypeCode;
            set { SetProperty<string>(ref _SpendTypeCode, value, () => OnPropertyChanged(nameof(SpendTypeCode))); }
        }

        private string _Tab;
        public string Tab
        {
            get => _Tab;
            set { SetProperty<string>(ref _Tab, value, () => OnPropertyChanged(nameof(Tab))); }
        }

        private DateTime _DateNo = DateTime.Now;
        public DateTime DateNo
        {
            get => _DateNo;
            set { SetProperty<DateTime>(ref _DateNo, value, () => OnPropertyChanged(nameof(DateNo))); }
        }

        private string _TextColor;
        public string TextColor
        {
            get => _TextColor;
            set { SetProperty<string>(ref _TextColor, value, () => OnPropertyChanged(nameof(TextColor))); }
        }
    }
}
