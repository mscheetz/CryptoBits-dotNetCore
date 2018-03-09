using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.KuCoin
{
    public class Balance
    {
        public string coinType { get; set; }
        public int balance { get; set; }
        public int freezeBalance { get; set; }
    }
}
