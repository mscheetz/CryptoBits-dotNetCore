using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class AddressTransaction
    {
        public DateTime blockTime { get; set; }
        public string hash { get; set; }
        public double value { get; set; }
    }
}
