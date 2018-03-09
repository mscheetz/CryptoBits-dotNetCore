using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    [DataContract]
    [Serializable]
    public class CoinbasePrice
    {
        [DataMember(Name = "base")]
        public string symbol { get; set; }

        public string currency { get; set; }

        public string amount { get; set; }
    }
}
