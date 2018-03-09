using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    public class ServerTime
    {
        public string code { get; set; }
        public string msg { get; set; }
        public bool success { get; set; }
        public long timestamp { get; set; }
    }
}
