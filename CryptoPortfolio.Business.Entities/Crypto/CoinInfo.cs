using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class CoinInfo : Entity
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public List<Wallet> walletList { get; set; }
    }
}
