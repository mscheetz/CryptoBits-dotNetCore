using CryptoPortfolio.Business.Entities.Crypto;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities
{
    public class ApiInformation : Entity
    {
        //[BsonId]
        //public string Id { get; set; }
        public string apiSource { get; set; }
        public string apiKey { get; set; }
        public string apiSecret { get; set; }
        public string extraValue { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}
