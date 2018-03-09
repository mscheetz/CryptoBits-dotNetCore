using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Ethplorer
{
    public class Token
    {
        public TokenInfo tokenInfo { get; set; }
        public double balance { get; set; }
        public int totalIn { get; set; }
        public int totalOut { get; set; }
    }
}
