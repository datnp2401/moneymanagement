using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MoneyManagement
{
    public class SettingsDB
    {
        private SQLiteConnection _databaseConnection;
        public SettingsDB()
        {
            _databaseConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _databaseConnection.CreateTable<Settings>();
        }

        public List<Settings> GetSettings()
        {
            return (from u in _databaseConnection.Table<Settings>() select u).ToList();
        }
        public Settings GetSetting(int id)
        {
            return _databaseConnection.Table<Settings>().FirstOrDefault(t => t.Id == id);
        }
        public void DeleteSetting(int id)
        {
            _databaseConnection.Delete<Settings>(id);
        }
        public string AddSetting(Settings settings)
        {
            var data = _databaseConnection.Table<Settings>();
            _databaseConnection.Insert(settings);
            return "Sucessfully Added";
        }

        public bool updateSetting(Settings settings)
        {
            var data = _databaseConnection.Table<Settings>();
            var d1 = (from values in data
                      where values.Id == settings.Id
                      select values).Single();
            if (true)
            {
                d1.Code = settings.Code;
                d1.Name = settings.Name;
                d1.Percent = settings.Percent;
                d1.Tab = settings.Tab;

                _databaseConnection.Update(d1);
                return true;
            }

        }
    }
}
