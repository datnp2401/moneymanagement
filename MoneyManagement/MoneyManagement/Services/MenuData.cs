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
            settings.Tab = "";
            settings.Code = "Chi tiêu";
            settings.Name = "Chi tiêu";

            settings.Percent = 30;

            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Chi tiêu";
            settings.Code = "Chitieucanthiet";
            settings.Name = "Chi tiêu cần thiết";

            settings.Percent = 60;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Chi tiêu";
            settings.Code = "Chitieukhongcanthiet";
            settings.Name = "Chi tiêu không cần thiết";

            settings.Percent = 20;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Chi tiêu";
            settings.Code = "Quy";
            settings.Name = "Quỹ";

            settings.Percent = 20;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "";
            settings.Code = "Tiết kiệm";
            settings.Name = "Tiết kiệm";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Tiết kiệm";
            settings.Code = "Tiết kiệm bắt buộc";
            settings.Name = "Tiết kiệm bắt buộc";

            settings.Percent = 70;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Tiết kiệm";
            settings.Code = "Tiết kiệm chi tiêu theo kế hoạch";
            settings.Name = "Tiết kiệm chi tiêu theo kế hoạch";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "";
            settings.Code = "Đầu tư";
            settings.Name = "Đầu tư";

            settings.Percent = 40;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Đầu tư";
            settings.Code = "Quỹ";
            settings.Name = "Quỹ";

            settings.Percent = 40;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Đầu tư";
            settings.Code = "Dài hạn";
            settings.Name = "Dài hạn";

            settings.Percent = 30;
            data.Add(settings);

            settings = new Settings();
            settings.Tab = "Đầu tư";
            settings.Code = "Forex";
            settings.Name = "Forex";

            settings.Percent = 30;
            data.Add(settings);

            return data;
        }
    }
}
