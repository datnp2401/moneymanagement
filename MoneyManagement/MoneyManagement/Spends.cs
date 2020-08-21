﻿using SQLite;
using System;

namespace MoneyManagement
{
    public class Spends
    {
        [PrimaryKey, AutoIncrement()]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public DateTime DateNo { get; set; } = DateTime.Now;
        public string SpendType { get; set; } // Ăn uống, Du lịch, Tiết kiệm, Trả nợ, Đầu tư, Mua sắm, Lương
        public string TextColor { get; set; }
    }
}
