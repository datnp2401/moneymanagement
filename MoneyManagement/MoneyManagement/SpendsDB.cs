using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MoneyManagement
{

    public class SpendsDB
    {
        private SQLiteConnection _databaseConnection;
        public SpendsDB()
        {
            _databaseConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _databaseConnection.CreateTable<Spends>();
        }
        public List<Spends> GetSpends()
        {
            return (from u in _databaseConnection.Table<Spends>() select u).ToList();
        }
        public Spends GetSpecificSpends(int id)
        {
            return _databaseConnection.Table<Spends>().FirstOrDefault(t => t.Id == id);
        }
        public void DeleteUser(int id)
        {
            _databaseConnection.Delete<Spends>(id);
        }
        public string AddUser(Spends spends)
        {
            var data = _databaseConnection.Table<Spends>();
            _databaseConnection.Insert(spends);
            return "Sucessfully Added";
        }

        public bool updateUser(Spends spends)
        {
            var data = _databaseConnection.Table<Spends>();
            var d1 = (from values in data
                      where values.Id == spends.Id
                      select values).Single();
            if (true)
            {
                d1.Content = spends.Content;
                d1.Address = spends.Address;
                d1.Amount = spends.Amount;
                d1.DateNo = spends.DateNo;
                d1.SpendType = spends.SpendType;
                d1.TextColor = spends.TextColor;

                _databaseConnection.Update(d1);
                return true;
            }

        }

        public void Dispose()
        {
            _databaseConnection.Dispose();
        }
    }
}
