﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models.TradeFutureModels
{
    public class TradeFutureUpdateModel
    {
        [Required]
        public int Id { get; set; }
        public string CoinName { get; set; } = string.Empty;
        public decimal PositionSize { get; set; }
        public decimal Risk { get; set; }
        public decimal Reward { get; set; }
        public decimal EarnedMoney { get; set; }
        public string TradingViewImgLink { get; set; } = string.Empty;
    }
}
