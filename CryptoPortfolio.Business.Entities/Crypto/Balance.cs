using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class Balance
    {
        [BsonId]
        public string Id { get; set; }
        public string location { get; set; }
        public string symbol { get; set; }
        public double qty { get; set; }
    }
}
