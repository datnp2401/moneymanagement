using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagement
{
    public class Currency
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
    }
}
