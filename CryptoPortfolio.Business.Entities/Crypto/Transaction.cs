﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class Transaction
    {
        [BsonId]
        public string Id { get; set; }
        public string exchange { get; set; }
        public string symbol { get; set; }
        public int orderId { get; set; }
        public string clientOrderId { get; set; }
        public string price { get; set; }
        public string origQty { get; set; }
        public string executedQty { get; set; }
        public string status { get; set; }
        public string timeInForce { get; set; }
        public string type { get; set; }
        public string side { get; set; }
        public string stopPrice { get; set; }
        public string icebergQty { get; set; }
        public long time { get; set; }
        public bool isWorking { get; set; }
    }
}