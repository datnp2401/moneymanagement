using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoneyManagement.Services
{
    public class MenuData
    {
        public static ObservableCollection<Settings> CreateData()
        {
            ObservableCollection<Settings> data = new ObservableCollection<Settings>();

            Settings settings = new Settings();

            settings.Tab = "Lương";
            settings.Code = "Lương";
            settings.Name = "Lương 一【" + settings.Tab + "】";

            settings.Percent = 100;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "";
            settings.Code = "Chi tiêu";
            settings.Name = "Chi tiêu 一【Vốn】";

            settings.Percent = 60;

            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Chi tiêu";
            settings.Code = "Cần thiết";
            settings.Name = "Cần thiết 一【" + settings.Tab + "】";

            settings.Percent = 70;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Chi tiêu";
            settings.Code = "Không cần thiết";
            settings.Name = "Không cần thiết 一【" + settings.Tab + "】";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "";
            settings.Code = "Tiết kiệm";
            settings.Name = "Tiết kiệm 一【Vốn】";

            settings.Percent = 40;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Tiết kiệm";
            settings.Code = "Bắt buộc";
            settings.Name = "Bắt buộc 一【" + settings.Tab + "】";

            settings.Percent = 70;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Tiết kiệm";
            settings.Code = "Theo kế hoạch";
            settings.Name = "Theo kế hoạch 一【" + settings.Tab + "】";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "";
            settings.Code = "Đầu tư";
            settings.Name = "Đầu tư 一【Vốn】";

            settings.Percent = 100;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Đầu tư";
            settings.Code = "Quỹ";
            settings.Name = "Quỹ 一【" + settings.Tab + "】";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Đầu tư";
            settings.Code = "BĐS";
            settings.Name = "BĐS 一【" + settings.Tab + "】";

            settings.Percent = 20;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Đầu tư";
            settings.Code = "Chứng khoán";
            settings.Name = "Chứng khoán 一【" + settings.Tab + "】";

            settings.Percent = 20;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Đầu tư";
            settings.Code = "Crypto";
            settings.Name = "Crypto 一【" + settings.Tab + "】";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "";
            settings.Code = "Kinh doanh";
            settings.Name = "Kinh doanh 一【Vốn】";

            settings.Percent = 100;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Kinh doanh";
            settings.Code = "Quỹ";
            settings.Name = "Quỹ 一【" + settings.Tab + "】";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Kinh doanh";
            settings.Code = "Forex";
            settings.Name = "Forex 一【" + settings.Tab + "】";

            settings.Percent = 40;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Kinh doanh";
            settings.Code = "Khác";
            settings.Name = "Khác 一【" + settings.Tab + "】";

            settings.Percent = 20;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Kinh doanh";
            settings.Code = "Từ thiện";
            settings.Name = "Từ thiện 一【" + settings.Tab + "】";

            settings.Percent = 10;
            data.Add(settings);

            return data;
        }
    }
}
