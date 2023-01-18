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
        public SpendsDB SpendsDB;
        public SettingsDB SettingsDB;

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
        public decimal TongConLai { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public TotalPage()
        {
            InitializeComponent();
            BindingContext = TotalViewModel = new TotalViewModel();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //SpendsDB = new SpendsDB();
            //SettingsDB = new SettingsDB();
            //decimal Luong = 0;

            //List<Settings> lstSetting = SettingsDB.GetSettings().OrderBy(x => x.Tab).ToList();
            //Luong = SpendsDB.GetSpends().Where(x => x.SpendTypeCode.Equals("Lương")).Where(x => x.DateNo.Month == Date.Month
            //                                    && x.DateNo.Year == Date.Year).ToList().Sum(x => x.Amount);

            //ChiTieuConLai = "【Chi tiêu】";
            //DauTuConLai = "【Đầu tư】";
            //TietKiemConLai = "【Tiết kiệm】";
            //KinhDoanhConLai = "【Kinh doanh】";

            //TongConLai = 0;
            //decimal amountChiTieu = 0;
            //decimal amountTietKiem = 0;
            //decimal amountDauTu = 0;
            //decimal amountKinhDoanh = 0;

            //foreach (var itemSetting in lstSetting)
            //{
            //    // get amount
            //    if (itemSetting.Tab == "" && itemSetting.Code.Equals("Chi tiêu"))
            //    {
            //        amountChiTieu = Luong * itemSetting.Percent / 100;
            //    }
            //    else if (itemSetting.Tab == "" && itemSetting.Code.Equals("Tiết kiệm"))
            //    {
            //        amountTietKiem = Luong * itemSetting.Percent / 100;
            //    }
            //    else if (itemSetting.Tab == "" && itemSetting.Code.Equals("Đầu tư"))
            //    {
            //        amountDauTu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //                            && x.DateNo.Year == Date.Year
            //                            && x.SpendTypeCode.Equals("Đầu tư"))
            //                            .ToList().Sum(x => x.Amount), 2);
            //    }
            //    else if (itemSetting.Tab == "" && itemSetting.Code.Equals("Kinh doanh"))
            //    {
            //        amountKinhDoanh = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //                            && x.DateNo.Year == Date.Year
            //                            && x.SpendTypeCode.Equals("Kinh doanh"))
            //                            .ToList().Sum(x => x.Amount), 2);
            //    }

            //}

            //Luong += Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month && x.Tab == ""
            //                            && x.DateNo.Year == Date.Year
            //                            && x.SpendTypeCode.Equals("Kinh doanh"))
            //                            .ToList().Sum(x => x.Amount), 2);

            //ThuChiTieu = "";
            //ThuTietKiem = "";
            //ThuDauTu = "";
            //ThuKinhDoanh = "";
            //DaChiTieu = "";
            //DaTietKiem = "";
            //DaDauTu = "";
            //DaKinhDoanh = "";

            //AmountChiTieuConLai = "";
            //AmountTietKiemConLai = "";
            //AmountDauTuConLai = "";
            //AmountKinhDoanhConLai = "";

            //foreach (var itemSetting in lstSetting)
            //{
            //    if (itemSetting.Tab.Equals("Chi tiêu"))
            //    {
            //        var chiTieu = (amountChiTieu * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //                                                                                            && x.DateNo.Year == Date.Year && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
            //                            .ToList().Sum(x => x.Amount), 2);

            //        ThuChiTieu += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


            //        var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //                                                    && x.DateNo.Year == Date.Year && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount < 0)
            //                            .ToList().Sum(x => x.Amount), 2);
            //        DaChiTieu += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";

            //        TongConLai += (chiTieu + daTieu);
            //        AmountChiTieuConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";

            //    }
            //    else if (itemSetting.Tab.Equals("Tiết kiệm"))
            //    {
            //        var chiTieu = (amountTietKiem * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //                        && x.DateNo.Year == Date.Year && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
            //                            .ToList().Sum(x => x.Amount), 2);

            //        ThuTietKiem += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


            //        var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //                        && x.DateNo.Year == Date.Year && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount < 0)
            //                            .ToList().Sum(x => x.Amount), 2);
            //        DaTietKiem += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";

            //        TongConLai += (chiTieu + daTieu);

            //        AmountTietKiemConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";

            //    }
            //    else if (itemSetting.Tab.Equals("Đầu tư"))
            //    {
            //        var chiTieu = (amountDauTu * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //                                    && x.DateNo.Year == Date.Year && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
            //                            .ToList().Sum(x => x.Amount), 2);

            //        ThuDauTu += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


            //        var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //        && x.DateNo.Year == Date.Year && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount < 0)
            //                            .ToList().Sum(x => x.Amount), 2);

            //        DaDauTu += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";
            //        TongConLai += (chiTieu + daTieu);
            //        AmountDauTuConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";

            //    }
            //    else if (itemSetting.Tab.Equals("Kinh doanh"))
            //    {
            //        var chiTieu = (amountKinhDoanh * itemSetting.Percent / 100) + Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month
            //        && x.DateNo.Year == Date.Year && x.SpendTypeCode.Equals(itemSetting.Code) && x.Amount > 0)
            //                            .ToList().Sum(x => x.Amount), 2);

            //        ThuKinhDoanh += "\n" + (chiTieu).ToString("#,##0.#") + " VNĐ";


            //        var daTieu = Math.Round(SpendsDB.GetSpends().Where(x => x.DateNo.Month == Date.Month && x.SpendTypeCode.Equals(itemSetting.Code)
            //        && x.DateNo.Year == Date.Year && x.Amount < 0)
            //                            .ToList().Sum(x => x.Amount), 2);
            //        DaKinhDoanh += "\n" + daTieu.ToString("#,##0.#") + " VNĐ";
            //        TongConLai += (chiTieu + daTieu);
            //        AmountKinhDoanhConLai += "\n" + (chiTieu + daTieu).ToString("#,##0.#") + " VNĐ";
            //    }
            //}

        }
    }
}