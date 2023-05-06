﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class TradeFutureEntity:BaseEntity
    {
        public string CoinName { get; set; } = string.Empty;
        public decimal PositionSize { get; set; }
        public decimal Risk { get; set; }
        public decimal Reward { get; set; }
        public decimal EarnedMoney { get; set; }
        public string TradingViewImgLink { get; set; } = string.Empty;
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }

    }
}
