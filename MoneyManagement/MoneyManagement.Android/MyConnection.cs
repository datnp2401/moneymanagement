using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MoneyManagement.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(MyConnection))]
namespace MoneyManagement.Droid
{
    class MyConnection : IDatabaseConnection
    {

        public SQLiteConnection DbConnection()

        {

            var dbName = "ProductsDB.db3";

            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

            return new SQLiteConnection(path);

        }

    }
}