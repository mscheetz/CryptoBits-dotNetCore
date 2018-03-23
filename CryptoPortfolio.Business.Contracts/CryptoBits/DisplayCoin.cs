using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a DisplayCoin object
    /// </summary>
    public class DisplayCoin
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public double quanity { get; set; }
        public int locations { get; set; }
        public Ticker ticker { get; set; }
        public double low { get; set; }
        public double high { get; set; }
        public double avg { get; set; }
        public double change1h { get; set; }
        public double change24h { get; set; }
        public double change7d { get; set; }
    }
}
