using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a CoinInfo object
    /// </summary>
    public class CoinInfo
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public double btcPrice { get; set; }
        public long lastUpdate { get; set; }
        public HashSet<string> exchangeSet { get; set; }
    }
}
