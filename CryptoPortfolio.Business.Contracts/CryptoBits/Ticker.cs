using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a single coin Ticker
    /// </summary>
    public class Ticker
    {
        public int rank { get; set; }
        public double priceUSD { get; set; }
        public double priceBTC { get; set; }
        public int volume24hUSD { get; set; }
        public double marketCapUSD { get; set; }
        public long availableSupply { get; set; }
        public long totalSupply { get; set; }
        public long maxSupply { get; set; }
        public double percentChange1h { get; set; }
        public double percentChange24h { get; set; }
        public double percentChange7d { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
