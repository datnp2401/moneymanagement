using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagement
{
    public class TradeCommand
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Currency { get; set; }

        [MaxLength(200)]
        public string Condition { get; set; }

        public DateTime DateNo { get; set; }

        public int WinLoss { get; set; } // 1: win, 0: loss, -1: wait

        public double Amount { get; set; }
        public string Image { get; set; }
    }
}
