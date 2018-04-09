using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class Wallet
    {
        public string location { get; set; }
        public List<CoinBuy> coinBuyList { get; set; }
        public Address address { get; set; }
    }
}
