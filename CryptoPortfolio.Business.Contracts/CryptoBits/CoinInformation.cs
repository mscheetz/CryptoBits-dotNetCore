using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a single CoinInformation
    /// </summary>
    public class CoinInformation
    {
        public string Id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public List<Wallet> walletList { get; set; }
        public List<CoinEvent> eventList { get; set; }
        public Ticker ticker { get; set; }
    }
}
