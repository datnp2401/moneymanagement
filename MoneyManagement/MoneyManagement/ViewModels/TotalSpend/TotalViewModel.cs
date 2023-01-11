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
        public string ConLai { get; set; }
        public decimal TongConLai { get; set; }
        public decimal DaSuDung { get; set; }
        public string ColorDaSuDung { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string ChiTieu { get; set; }
        public string TietKiem { get; set; }
        public string DauTu { get; set; }
        public string KinhDoanh { get; set; }

        /// <summary>
        /// Chưa dùng
        /// </summary>
        public string ThuChiTieu { get; set; }
        public string ThuTietKiem { get; set; }
        public string ThuDauTu { get; set; }
        public string ThuKinhDoanh { get; set; }

        /// <summary>
        /// Đã dùng
        /// </summary>
        public string DaChiTieu { get; set; }
        public string DaTietKiem { get; set; }
        public string DaDauTu { get; set; }
        public string DaKinhDoanh { get; set; }

        /// <summary>
        /// Còn lại
        /// </summary>
        public string ChiTieuConLai { get; set; }
        public string TietKiemConLai { get; set; }
        public string DauTuConLai { get; set; }
        public string KinhDoanhConLai { get; set; }

        public string AmountChiTieuConLai { get; set; }
        public string AmountTietKiemConLai { get; set; }
        public string AmountDauTuConLai { get; set; }
        public string AmountKinhDoanhConLai { get; set; }

        public string ColorTongConLai { get; set; }
        public string ColorChiTieuConLai { get; set; }
        public string ColorTietKiemConLai { get; set; }
        public string ColorDauTuConLai { get; set; }
        public string ColorKinhDoanhConLai { get; set; }

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

        async Task OnChangeAll()
        {
            var DateTimeNew = DateTime.Parse(Date);

            CurrentDate = "Tổng Thu - Chi tháng " + DateTimeNew.ToString("MM/yyyy");
            Luong = 0;
            List<Settings> lstSetting = SettingsDB.GetSettings().OrderBy(x => x.Tab).ToList();
            Luong = SpendsDB.GetSpends().Where(x => x.SpendTypeCode.Equals("Lương")).Where(x => x.DateNo.Month == DateTimeNew.Month).ToList().Sum(x => x.Amount);


            ChiTieu = "【Chi tiêu】";
            DauTu = "【Đầu tư】";
            TietKiem = "【Tiết kiệm】";
            KinhDoanh = "【Kinh doanh】";

            ChiTieuConLai = "【Chi tiêu】";
            DauTuConLai = "【Đầu tư】";
            TietKiemConLai = "【Tiết kiệm】";
            KinhDoanhConLai = "【Kinh doanh】";

            TongConLai = 0;
            decimal amountChiTieu = 0;
            decimal amountTietKiem = 0;
            decimal amountDauTu = 0;
            decimal amountKinhDoanh = 0;

            foreach (var itemSetting in lstSetting)
            {
                // get title
                if (itemSetting.Tab.Equals("Chi tiêu"))
                {
                    ChiTieu += "\n - " + itemSetting.Code;
                    ChiTieuConLai += "\n - " + itemSetting.Code;
                }
                else if (itemSetting.Tab.Equals("Tiết kiệm"))
                {
                    TietKiem += "\n - " + itemSetting.Code;
                    TietKiemConLai += "\n - " + itemSetting.Code;
                }
                else if (itemSetting.Tab.Equals("Đầu tư"))
                {
                    DauTu += "\n - " + itemSetting.Code;
                    DauTuConLai += "\n - " + itemSetting.Code;
                }
                else if (itemSetting.Tab == "Kinh doanh")
                {
                    KinhDoanh += "\n - " + itemSetting.Code;
                    KinhDoanhConLai += "\n - " + itemSetting.Code;
                }
                // get amount
                if (itemSetting.Tab == "" && itemSetting.Code.Equals("Chi tiêu"))
                {
                    amountChiTieu = Luong * itemSetting.Percent / 100;
                }
                else if (itemSetting.Tab == "" && itemSetting.Code.Equals("Tiết kiệm"))
                {
                    amountTietKiem = Luong * itemSetting.Percent / 100;
                }
                else if (itemSetting.Tab == "" && itemSetting.Code.Equals("Đầu tư"))
                {
                    amountDauTu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals("Đầu tư"))
                                        .ToList().Sum(x => x.Amount), 2);
                }
                else if (itemSetting.Tab == "" && itemSetting.Code.Equals("Kinh doanh"))
                {
                    amountKinhDoanh = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals("Kinh doanh"))
                                        .ToList().Sum(x => x.Amount), 2);
                }

            }

            Luong += Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.Tab == "" && x.SpendTypeCode.Equals("Kinh doanh"))
                                        .ToList().Sum(x => x.Amount), 2);

            ThuChiTieu = "";
            ThuTietKiem = "";
            ThuDauTu = "";
            ThuKinhDoanh = "";
            DaChiTieu = "";
            DaTietKiem = "";
            DaDauTu = "";
            DaKinhDoanh = "";

            AmountChiTieuConLai = "";
            AmountTietKiemConLai = "";
            AmountDauTuConLai = "";
            AmountKinhDoanhConLai = "";

            foreach (var itemSetting in lstSetting)
            {
                if (itemSetting.Tab.Equals("Chi tiêu"))
                {
                    var chiTieu = (amountChiTieu * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
                                        .ToList().Sum(x => x.Amount), 2);

                    ThuChiTieu += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


                    var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount < 0)
                                        .ToList().Sum(x => x.Amount), 2);
                    DaChiTieu += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";

                    TongConLai += (chiTieu + daTieu);
                    AmountChiTieuConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";

                }
                else if (itemSetting.Tab.Equals("Tiết kiệm"))
                {
                    var chiTieu = (amountTietKiem * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
                                        .ToList().Sum(x => x.Amount), 2);

                    ThuTietKiem += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


                    var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount < 0)
                                        .ToList().Sum(x => x.Amount), 2);
                    DaTietKiem += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";

                    TongConLai += (chiTieu + daTieu);

                    AmountTietKiemConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";

                }
                else if (itemSetting.Tab.Equals("Đầu tư"))
                {
                    var chiTieu = (amountDauTu * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
                                        .ToList().Sum(x => x.Amount), 2);

                    ThuDauTu += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


                    var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount < 0)
                                        .ToList().Sum(x => x.Amount), 2);
                    DaDauTu += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";
                    TongConLai += (chiTieu + daTieu);
                    AmountDauTuConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";

                }
                else if (itemSetting.Tab.Equals("Kinh doanh"))
                {
                    var chiTieu = (amountKinhDoanh * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
                                        .ToList().Sum(x => x.Amount), 2);

                    ThuKinhDoanh += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


                    var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == DateTimeNew.Month && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount < 0)
                                        .ToList().Sum(x => x.Amount), 2);
                    DaKinhDoanh += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";
                    TongConLai += (chiTieu + daTieu);
                    AmountKinhDoanhConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";
                }
            }




            base.OnPropertyChanged(nameof(Luong));
            base.OnPropertyChanged(nameof(ConLai));
            base.OnPropertyChanged(nameof(TongConLai));

            base.OnPropertyChanged(nameof(ChiTieu));
            base.OnPropertyChanged(nameof(TietKiem));
            base.OnPropertyChanged(nameof(DauTu));
            base.OnPropertyChanged(nameof(KinhDoanh));

            base.OnPropertyChanged(nameof(ThuChiTieu));
            base.OnPropertyChanged(nameof(ThuTietKiem));
            base.OnPropertyChanged(nameof(ThuDauTu));
            base.OnPropertyChanged(nameof(ThuKinhDoanh));

            base.OnPropertyChanged(nameof(ChiTieuConLai));
            base.OnPropertyChanged(nameof(TietKiemConLai));
            base.OnPropertyChanged(nameof(DauTuConLai));
            base.OnPropertyChanged(nameof(KinhDoanhConLai));

            base.OnPropertyChanged(nameof(AmountChiTieuConLai));
            base.OnPropertyChanged(nameof(AmountTietKiemConLai));
            base.OnPropertyChanged(nameof(AmountDauTuConLai));
            base.OnPropertyChanged(nameof(AmountKinhDoanhConLai));

            base.OnPropertyChanged(nameof(DaChiTieu));
            base.OnPropertyChanged(nameof(DaTietKiem));
            base.OnPropertyChanged(nameof(DaDauTu));
            base.OnPropertyChanged(nameof(DaSuDung));
            base.OnPropertyChanged(nameof(DaKinhDoanh));
            base.OnPropertyChanged(nameof(ColorDaSuDung));

        }
    }
}
