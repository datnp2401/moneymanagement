using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagement
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
