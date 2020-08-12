using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoneyManagement.ViewModels
{
    public class SpendsDetailViewModel : BaseViewModel
    {
        public SpendsItem SpendsItem { get; set; }

        public ObservableCollection<string> SpendType { get; set; }

        public int ChooseSpendIndex { get; set; }

        private string _ChooseSpendType;
        public string ChooseSpendType
        {
            get => _ChooseSpendType;
            set { SetProperty<string>(ref _ChooseSpendType, value, () => OnPropertyChanged(nameof(ChooseSpendType))); }
        }

        public SpendsDetailViewModel(SpendsItem item)
        {
            Title = "Chi tiết thu chi";

            SpendType = new ObservableCollection<string>()
            {
                "Ăn uống",
                "Du lịch",
                "Trả nợ",
                "Tiết kiệm",
                "Đầu tư",
                "Mua sắm",
                "Lương"
            };
            for (int i = 0; i < SpendType.Count; i++)
            {
                if (SpendType[i].Equals(item.SpendType))
                {
                    ChooseSpendIndex = i;
                }
            }
            ChooseSpendType = item.SpendType;

            SpendsItem = item;


        }

    }
}
