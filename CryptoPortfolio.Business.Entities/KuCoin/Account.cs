using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.KuCoin
{
    public class Account
    {
        public bool success { get; set; }
        public string code { get; set; }
        public List<Balance> data { get; set; }
    }
}
