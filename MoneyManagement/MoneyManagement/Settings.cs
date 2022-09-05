using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagement
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement()]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Code { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public decimal Percent { get; set; }

        [MaxLength(200)]
        public string Tab { get; set; }

    }
}
