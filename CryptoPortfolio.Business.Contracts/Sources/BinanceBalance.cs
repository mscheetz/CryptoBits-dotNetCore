using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.Sources
{
    public class BinanceBalance
    {
        public string symbol { get; set; }
        public double free { get; set; }
        public double locked { get; set; }
    }
}
