using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public SettingsDB SettingsDB;

        public string CurrentDate { get; set; } = "Tổng Thu - Chi tháng " + DateTime.Now.ToString("MM/yyyy");

        public string Date { get; set; } = DateTime.Now.ToString("MM/yyyy");
        public string Title { get; set; } = "Tổng Tháng";

        public decimal Luong { get; set; }
        public decimal ConLai { get; set; }
        public decimal TongConLai { get; set; }
        public decimal DaSuDung { get; set; }
        public string ColorDaSuDung { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string ChiTieu { get; set; }
        public string TietKiem { get; set; }
        public string DauTu { get; set; }

        /// <summary>
        /// Chưa dùng
        /// </summary>
        public string ThuChiTieu { get; set; }
        public string ThuTietKiem { get; set; }
        public string ThuDauTu { get; set; }

        /// <summary>
        /// Đã dùng
        /// </summary>
        public string DaChiTieu { get; set; }
        public string DaTietKiem { get; set; }
        public string DaDauTu { get; set; }

        /// <summary>
        /// Còn lại
        /// </summary>
        public decimal ChiTieuConLai { get; set; }
        public decimal TietKiemConLai { get; set; }
        public decimal DauTuConLai { get; set; }
        public string ColorTongConLai { get; set; }
        public string ColorChiTieuConLai { get; set; }
        public string ColorTietKiemConLai { get; set; }
        public string ColorDauTuConLai { get; set; }

        public SpendsDB SpendsDB;
        public TotalViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SettingsDB = new SettingsDB();


            SpendsDB = new SpendsDB();

            OnChangeAll();

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                await OnChangeAll();
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

        async Task OnChangeAll()
        {
            var DateTimeNew = DateTime.Parse(Date);
            List<Settings> lstSetting = SettingsDB.GetSettings().OrderBy(x => x.Tab).ToList();
            Luong = SpendsDB.GetSpends().Where(x => x.SpendTypeCode.Equals("Lương")).Where(x => x.DateNo.Month == DateTimeNew.Month).ToList().Sum(x => x.Amount);

            ChiTieu = "【Chi tiêu】";
            DauTu = "【Đầu tư】";
            TietKiem = "【Tiết kiệm】";

            decimal amountChiTieu = 0;
            decimal amountTietKiem = 0;
            decimal amountDauTu = 0;

            foreach (var itemSetting in lstSetting)
            {
                if (itemSetting.Tab.Equals("Chi tiêu"))
                {
                    ChiTieu += "\n - " + itemSetting.Code;
                }
                else if (itemSetting.Tab.Equals("Tiết kiệm"))
                {
                    TietKiem += "\n - " + itemSetting.Code;
                }
                else if (itemSetting.Tab.Equals("Đầu tư"))
                {
                    DauTu += "\n - " + itemSetting.Code;
                }

                if (itemSetting.Tab == "" && itemSetting.Code == "Chi tiêu")
                {
                    amountChiTieu = Luong * itemSetting.Percent / 100;
                }
                else if (itemSetting.Tab == "" && itemSetting.Code == "Tiết kiệm")
                {
                    amountTietKiem = Luong * itemSetting.Percent / 100;
                }
                else if (itemSetting.Tab == "" && itemSetting.Code == "Đầu tư")
                {
                    amountDauTu = Luong * itemSetting.Percent / 100;
                }
            }

            ThuChiTieu = "";
            ThuTietKiem = "";
            ThuDauTu = "";
            DaChiTieu = "";

            foreach (var itemSetting in lstSetting)
            {
                if (itemSetting.Tab.Equals("Chi tiêu"))
                {
                    ThuChiTieu += "\n" + (amountChiTieu * itemSetting.Percent / 100).ToString("#,##0.#") + " VNĐ";
                    DaChiTieu += "\n" + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month).Where(x => x.Tab != null ? x.SpendTypeCode.Equals(itemSetting.Code) : false).ToList().Sum(x => x.Amount), 2).ToString("#,##0.#") + " VNĐ";
                }
                else if (itemSetting.Tab.Equals("Tiết kiệm"))
                {
                    ThuTietKiem += "\n" + (amountTietKiem * itemSetting.Percent / 100).ToString("#,##0.#") + " VNĐ";
                }
                else if (itemSetting.Tab.Equals("Đầu tư"))
                {
                    ThuDauTu += "\n" + (amountDauTu * itemSetting.Percent / 100).ToString("#,##0.#") + " VNĐ";
                }
            }

            var data = SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month);

            //ThuChiTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month).Where(x => x.Tab != null ? x.SpendTypeCode.Equals("Cần thiết") : false).ToList().Sum(x => x.Amount), 2).ToString();
            //ThuChiTieu += "\n" + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month).Where(x => x.Tab != null ? x.SpendTypeCode.Equals("Cần thiết") : false).ToList().Sum(x => x.Amount), 2);

            //DaChiTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Chi tiêu") : false).ToList().Sum(x => x.Amount), 2);
            //DaTietKiem = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Tiết kiệm") : false).ToList().Sum(x => x.Amount), 2);
            //DaDauTu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTime.Now.Month).Where(x => x.SpendType != null ? x.SpendType.Equals("Đầu tư") : false).ToList().Sum(x => x.Amount), 2);

            //DaSuDung = DaChiTieu + DaTietKiem + DaDauTu;

            TongConLai = Luong + DaSuDung;
            //AnUongConLai = AnUong + DaAnUong;

            if (TongConLai > 0)
            {
                ColorTongConLai = "Green";
            }
            else
            {
                ColorTongConLai = "Red";
            }

            if (ChiTieuConLai > 0)
            {
                ColorChiTieuConLai = "Green";
            }
            else
            {
                ColorChiTieuConLai = "Red";
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

            if (DaSuDung > 0)
            {
                ColorDaSuDung = "Green";
            }
            else
            {
                ColorDaSuDung = "Red";
            }

            base.OnPropertyChanged(nameof(Luong));
            base.OnPropertyChanged(nameof(ConLai));
            base.OnPropertyChanged(nameof(TongConLai));

            base.OnPropertyChanged(nameof(ChiTieu));
            base.OnPropertyChanged(nameof(TietKiem));
            base.OnPropertyChanged(nameof(DauTu));

            base.OnPropertyChanged(nameof(ThuChiTieu));
            base.OnPropertyChanged(nameof(ThuTietKiem));
            base.OnPropertyChanged(nameof(ThuDauTu));

            base.OnPropertyChanged(nameof(ChiTieuConLai));
            base.OnPropertyChanged(nameof(TietKiemConLai));
            base.OnPropertyChanged(nameof(DauTuConLai));

            base.OnPropertyChanged(nameof(DaChiTieu));
            base.OnPropertyChanged(nameof(DaTietKiem));
            base.OnPropertyChanged(nameof(DaDauTu));
            base.OnPropertyChanged(nameof(DaSuDung));
            base.OnPropertyChanged(nameof(ColorDaSuDung));

        }
    }
}
