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
        public decimal quanity { get; set; }
        public int locations { get; set; }
        public Ticker ticker { get; set; }
        public decimal low { get; set; }
        public decimal high { get; set; }
        public decimal avg { get; set; }
    }
}
