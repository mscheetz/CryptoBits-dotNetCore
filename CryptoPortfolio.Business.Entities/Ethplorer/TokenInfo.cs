using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Ethplorer
{
    public class TokenInfo
    {
        public string address { get; set; }
        public string name { get; set; }
        public object decimals { get; set; }
        public string symbol { get; set; }
        public string totalSupply { get; set; }
        public string owner { get; set; }
        public int lastUpdated { get; set; }
        public int issuancesCount { get; set; }
        public int holdersCount { get; set; }
        public object price { get; set; }
        public string description { get; set; }
    }
}
