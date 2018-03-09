using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class CoinInfo
    {
        [BsonId]
        public string Id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public double btcPrice { get; set; }
        public long lastUpdate { get; set; }
        public HashSet<string> exchangeSet { get; set; }
    }
}
