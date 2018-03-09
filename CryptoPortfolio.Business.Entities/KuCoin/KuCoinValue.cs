using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.KuCoin
{
    public class KuCoinValue
    {
        public string coinType { get; set; }
        public bool trading { get; set; }
        public string symbol { get; set; }
        public double lastDealPrice { get; set; }
        public double buy { get; set; }
        public double sell { get; set; }
        public double change { get; set; }
        public string coinTypePair { get; set; }
        public int sort { get; set; }
        public double feeRate { get; set; }
        public double volValue { get; set; }
        public double high { get; set; }
        public long datetime { get; set; }
        public double vol { get; set; }
        public double low { get; set; }
        public double changeRate { get; set; }
    }
}
