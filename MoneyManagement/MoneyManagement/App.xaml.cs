using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyManagement.Services;
using MoneyManagement.Views;
using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MoneyManagement.Models;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace MoneyManagement
{
    public partial class App : Application
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "MoneyManagementApp";
        public ObservableCollection<SpendsItem> SpendsItemList { get; set; } = new ObservableCollection<SpendsItem>();

        public SpendsDB SpendsDB;
        public SpendsItem SpendsItem { get; set; } = new SpendsItem();

        public SettingsItem SettingsItem { get; set; } = new SettingsItem();

        public SettingsDB SettingsDB = new SettingsDB();

        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA2NTU3QDMxMzgyZTMyMmUzMFhNNmJuM0xoWSs1eHRrbzRub3I1QXppcTc0bWJhdUI2alhkVjNWU0wyd3c9");

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockDataSpends>();
            DependencyService.Register<MockDataSettings>();
            NavigationPage.SetHasNavigationBar(this, false);
            MainPage = new MainPage();

        }

        protected override void OnStart()
        {

            //SettingsDB.AddSetting(settings);

            SettingsItem.Id = SettingsDB.GetSettings().Count;

            ObservableCollection<Settings> SettingsData = MenuData.CreateData();

            if (SettingsItem.Id == 0)
            {
                foreach (var item in SettingsData)
                {
                    SettingsDB.AddSetting(item);
                }
            }

            //SpendsDB = new SpendsDB();
            //List<Spends> lst = SpendsDB.GetSpends().OrderByDescending(x => x.Id).ToList();

            //for (int i = 0; i < lst.Count(); i++)
            //{
            //    SpendsItem spendsItem = new SpendsItem();

            //    spendsItem.Id = lst[i].Id;
            //    spendsItem.Content = lst[i].Content;
            //    spendsItem.Address = lst[i].Address;
            //    spendsItem.DateNo = lst[i].DateNo;
            //    spendsItem.Amount = lst[i].Amount;
            //    spendsItem.SpendType = lst[i].SpendType;
            //    spendsItem.TextColor = lst[i].TextColor;

            //    SpendsItemList.Add(spendsItem);
            //}

            //UserCredential credential;

            //using (var stream =
            //    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            //{
            //    string credPath = "token.json";
            //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //        GoogleClientSecrets.Load(stream).Secrets,
            //        Scopes,
            //        "user",
            //        CancellationToken.None

            //        ).Result; // new FileDataStore(credPath, true)
            //    Console.WriteLine("Credential file saved to: " + credPath);
            //}

            //var service = new SheetsService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = ApplicationName
            //});

            //// Define request parameters.
            //String spreadsheetId = "1xM5LH48ODT6Gnbz5alzPlCjK1wCuDHx83rlwGn-9rEE";
            //String range = "SheetName!A2:B";
            //SpreadsheetsResource.ValuesResource.GetRequest request =
            //        service.Spreadsheets.Values.Get(spreadsheetId, range);

            //// Prints the names and majors of students in a sample spreadsheet:

            //// https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit

            //ValueRange response = request.Execute();
            //IList<IList<Object>> values = response.Values;
            //if (values != null && values.Count > 0)
            //{
            //    SpendsItem item = new SpendsItem();
            //    foreach (var row in values)
            //    {
            //        Console.WriteLine("{0}, {1}", row[0], row[1]);

            //        item = new SpendsItem
            //        {
            //            Id = Int32.Parse(row[0].ToString()),
            //            Amount = Decimal.Parse(row[1].ToString()),
            //            Content = row[2].ToString(),
            //            Address = row[3].ToString(),
            //            SpendType = row[4].ToString(),
            //            TextColor = row[5].ToString()
            //        };

            //        //lst_data.Items.AddRange(new SpendsItem[] { item });
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("No data found.");
            //}


            //values.Add(new string[] { "1", "17000000", "Lương tháng 09", "", "Lương", "", "Green" });
            //values.Add(new string[] { "2", "110000", "Cá hồi", "", "Ăn uống", "", "Red" });
            //values.Add(new string[] { "3", "120000", "Ức gà", "", "Ăn uống", "", "Red" });


            //// How the input data should be interpreted.
            //SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum valueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;  // TODO: Update placeholder value.


            //ValueRange responsebody = new ValueRange();
            //responsebody.Values = values;

            ////AppendValuesResponse result = service.Spreadsheets.Values.Append(responsebody, spreadsheetId, "A3:B3").Execute();

            //SpreadsheetsResource.ValuesResource.UpdateRequest result = service.Spreadsheets.Values.Update(responsebody, spreadsheetId, range);
            //result.ValueInputOption = valueInputOption;

            //// To execute asynchronously in an async method, replace `request.Execute()` as shown:
            //Google.Apis.Sheets.v4.Data.UpdateValuesResponse responseData = result.Execute();
            //// Data.UpdateValuesResponse response = await request.ExecuteAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
