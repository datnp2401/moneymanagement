﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoneyManagement.ViewModels.TotalSpend
{
    public class TotalViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        public string CurrentDate { get; set; } = "Tổng Thu - Chi tháng " + DateTime.Now.ToString("MM/yyyy");

        public string Date { get; set; } = DateTime.Now.ToString("MM/yyyy");

        public string Title { get; set; } = "Tổng Tháng";

        /// <summary>
        /// Nợ: 
        /// VPBank: 3.670 tr/tháng
        /// TPBank: 2.814 tr/tháng
        /// FE Credit: 2.287 tr/tháng
        /// Shinhan: 1.200 tr/tháng
        /// Tổng NH: 10 tr/tháng
        /// Tư: 25tr trả  2tr/tháng tới tháng 7
        /// Ruby: 30 trả 1.5 triệu/tháng
        /// 
        /// Tổng cộng nợ tháng: 13tr5/tháng
        /// </summary>
        public decimal No { get; set; }

        public decimal Luong { get; set; }
        public decimal ConLai { get; set; }
        public decimal TongConLai { get; set; }
        public decimal DaSuDung { get; set; }
        public string ColorDaSuDung { get; set; }

        /// <summary>
        /// Chưa dùng
        /// </summary>
        public decimal AnUong { get; set; }
        public decimal TietKiem { get; set; }
        public decimal MuaSam { get; set; }
        public decimal DauTu { get; set; }
        public decimal DuLich { get; set; }
        public decimal TraNo { get; set; }

        /// <summary>
        /// Đã dùng
        /// </summary>
        public decimal DaAnUong { get; set; }
        public decimal DaTietKiem { get; set; }
        public decimal DaDuLich { get; set; }
        public decimal DaDauTu { get; set; }
        public decimal DaMuaSam { get; set; }
        public decimal TraNoDaDung { get; set; }

        /// <summary>
        /// Còn lại
        /// </summary>
        public decimal AnUongConLai { get; set; }
        public decimal TietKiemConLai { get; set; }
        public decimal MuaSamConLai { get; set; }
        public decimal DauTuConLai { get; set; }
        public decimal DuLichConLai { get; set; }
        public decimal TraNoConLai { get; set; }
        public string ColorTongConLai { get; set; }
        public string ColorAnUongConLai { get; set; }
        public string ColorTietKiemConLai { get; set; }
        public string ColorMuaSamConLai { get; set; }
        public string ColorDauTuConLai { get; set; }
        public string ColorDuLichConLai { get; set; }
        public string ColorTraNoConLai { get; set; }

        public SpendsDB SpendsDB;
        public TotalViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SpendsDB = new SpendsDB();

            OnChangeAll();

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                OnChangeAll();
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

        async void OnChangeAll()
        {
            var DateTimeNew = DateTime.Parse(Date);

            Luong = SpendsDB.GetSpends().Where(x => x.SpendType.Equals("Lương")).Where(x => x.DateNo.Month == DateTimeNew.Month).OrderByDescending(x => x.Id).ToList().Sum(x => x.Amount);
            //ConLai = Luong - No;

            /// Ăn uống 20%
            /// Tiết kiệm 10%
            /// Du lịch 10%
            /// Đầu tư 40%
            /// Mua sắm 20%

            TraNo = Math.Round(Luong * (decimal)0.7, 2);

            var data = SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month);

            AnUong = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.Tab != null ? x.Tab.Equals("Chi tiêu") : false).ToList().Sum(x => x.Amount), 2);
            TietKiem = Math.Round(Luong * (decimal)0.1, 2);
            DuLich = Math.Round(Luong * (decimal)0.03, 2);
            DauTu = Math.Round(Luong * (decimal)0.0, 2);
            MuaSam = Math.Round(Luong * (decimal)0.03, 2);

            DaAnUong = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Chi tiêu") : false).ToList().Sum(x => x.Amount), 2);
            DaDuLich = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Du lịch") : false).ToList().Sum(x => x.Amount), 2);
            DaTietKiem = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Tiết kiệm") : false).ToList().Sum(x => x.Amount), 2);
            DaDauTu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Đầu tư") : false).ToList().Sum(x => x.Amount), 2);
            DaMuaSam = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Mua sắm") : false).ToList().Sum(x => x.Amount), 2);
            TraNoDaDung = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Trả nợ") : false).ToList().Sum(x => x.Amount), 2);

            DaSuDung = DaAnUong + DaDuLich + DaTietKiem + DaDauTu + DaMuaSam;

            TongConLai = Luong + DaSuDung;
            AnUongConLai = AnUong + DaAnUong;
            DuLichConLai = DuLich + DaDuLich;
            TietKiemConLai = TietKiem + DaTietKiem;
            DauTuConLai = DauTu + DaDauTu;
            MuaSamConLai = MuaSam + DaMuaSam;
            TraNoConLai = TraNo + TraNoDaDung;

            if (TongConLai > 0)
            {
                ColorTongConLai = "Green";
            }
            else
            {
                ColorTongConLai = "Red";
            }

            if (AnUongConLai > 0)
            {
                ColorAnUongConLai = "Green";
            }
            else
            {
                ColorAnUongConLai = "Red";
            }

            if (DuLichConLai > 0)
            {
                ColorDuLichConLai = "Green";
            }
            else
            {
                ColorDuLichConLai = "Red";
            }

            if (TietKiemConLai > 0)
            {
                ColorTietKiemConLai = "Green";
            }
            else
            {
                ColorTietKiemConLai = "Red";
            }

            if (DauTuConLai > 0)
            {
                ColorDauTuConLai = "Green";
            }
            else
            {
                ColorDauTuConLai = "Red";
            }

            if (MuaSamConLai > 0)
            {
                ColorMuaSamConLai = "Green";
            }
            else
            {
                ColorMuaSamConLai = "Red";
            }

            if (DaSuDung > 0)
            {
                ColorDaSuDung = "Green";
            }
            else
            {
                ColorDaSuDung = "Red";
            }

            if (TraNoConLai > 0)
            {
                ColorTraNoConLai = "Green";
            }
            else
            {
                ColorTraNoConLai = "Red";
            }

            base.OnPropertyChanged(nameof(Luong));
            base.OnPropertyChanged(nameof(ConLai));
            base.OnPropertyChanged(nameof(TongConLai));

            base.OnPropertyChanged(nameof(AnUong));
            base.OnPropertyChanged(nameof(DuLich));
            base.OnPropertyChanged(nameof(TietKiem));
            base.OnPropertyChanged(nameof(DauTu));
            base.OnPropertyChanged(nameof(MuaSam));
            base.OnPropertyChanged(nameof(TraNo));

            base.OnPropertyChanged(nameof(AnUongConLai));
            base.OnPropertyChanged(nameof(DuLichConLai));
            base.OnPropertyChanged(nameof(TietKiemConLai));
            base.OnPropertyChanged(nameof(DauTuConLai));
            base.OnPropertyChanged(nameof(MuaSamConLai));
            base.OnPropertyChanged(nameof(TraNoConLai));

            base.OnPropertyChanged(nameof(DaAnUong));
            base.OnPropertyChanged(nameof(DaDuLich));
            base.OnPropertyChanged(nameof(DaTietKiem));
            base.OnPropertyChanged(nameof(DaDauTu));
            base.OnPropertyChanged(nameof(DaMuaSam));
            base.OnPropertyChanged(nameof(DaSuDung));
            base.OnPropertyChanged(nameof(ColorDaSuDung));
            base.OnPropertyChanged(nameof(ColorTraNoConLai));

        }
    }
}
