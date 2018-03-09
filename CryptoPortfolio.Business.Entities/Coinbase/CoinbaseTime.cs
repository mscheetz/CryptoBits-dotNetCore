using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    public class CoinbaseTime
    {
        public DateTime iso { get; set; }
        public long epoch { get; set; }
    }
}
