using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a single CoinEvent
    /// </summary>
    public class CoinEvent
    {
        public string name { get; set; }
        public string source { get; set; }
        public DateTime? eventDate { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
