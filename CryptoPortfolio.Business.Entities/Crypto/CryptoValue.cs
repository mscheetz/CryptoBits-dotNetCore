﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class CryptoValue
    {
        [BsonId]
        public string Id { get; set; }
        public string symbol { get; set; }
        public string pair { get; set; }
        public string exchange { get; set; }
        public long price { get; set; }
        public long time { get; set; }
    }
}
