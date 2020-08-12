using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyManagement.ViewModels.TotalSpend
{
    public class TotalViewModel : BaseViewModel
    {
        public string CurrentDate { get; set; } = DateTime.Now.ToString("MM/yyyy");

        /// <summary>
        /// Nợ: 
        /// VPBank: 3.670 tr/tháng
        /// TPBank: 2.814 tr/tháng
        /// FE Credit: 2.287 tr/tháng
        /// Tổng NH: 8.800 tr/tháng
        /// Tư: 25tr trả  2tr/tháng tới tháng 7
        /// Ruby: 30 trả 1.5 triệu/tháng
        ///Tổng cộng nợ tháng: 12tr3/tháng
        /// </summary>
        public decimal TraNo { get; set; } = 12300000;

        public decimal Luong { get; set; }
        public decimal ConLai { get; set; }
        public decimal DaSuDung { get; set; }
        public decimal AnUong { get; set; }
        public decimal DaAnUong { get; set; }
        public decimal TietKiem { get; set; }
        public decimal DaTietKiem { get; set; }
        public decimal DuLich { get; set; }
        public decimal DaDuLich { get; set; }
        public decimal DauTu { get; set; }
        public decimal DaDauTu { get; set; }
        public decimal MuaSam { get; set; }
        public decimal DaMuaSam { get; set; }


        public SpendsDB SpendsDB;
        public TotalViewModel()
        {
            SpendsDB = new SpendsDB();
            Luong = SpendsDB.GetSpends().OrderByDescending(x => x.Id).ToList().Sum(x => x.Amount);
            ConLai = Luong - TraNo;

            /// ConLai, tính % lúc chưa dùng tiền
            /// Ăn uống 35%
            /// Du lịch 10%
            /// Tiết kiệm 12.5%
            /// Đầu tư 5%
            /// Trả nợ 15%
            /// Mua sắm 7.5%

            AnUong = ConLai * (decimal)0.35;
            DuLich = ConLai * (decimal)0.1;
            TietKiem = ConLai * (decimal)0.125;
            DauTu = ConLai * (decimal)0.05;
            TraNo = ConLai * (decimal)0.15;
            MuaSam = ConLai * (decimal)0.075;

        }
    }
}
