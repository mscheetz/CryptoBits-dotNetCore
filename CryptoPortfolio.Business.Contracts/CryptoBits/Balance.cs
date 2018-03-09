using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    public class Balance
    {
        public string Id { get; set; }
        public string location { get; set; }
        public string symbol { get; set; }
        public double qty { get; set; }
    }
}
