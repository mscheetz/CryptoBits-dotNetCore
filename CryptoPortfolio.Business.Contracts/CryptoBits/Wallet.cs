using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a single Wallet
    /// </summary>
    public class Wallet
    {
        public Location location { get; set; }
        public List<CoinBuy> coinBuyList { get; set; }
        public Address address { get; set; }
    }
}
