using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.KuCoin
{
    public class Transaction
    {
        public object createdAt { get; set; }
        public double amount { get; set; }
        public double dealValue { get; set; }
        public double dealPrice { get; set; }
        public double fee { get; set; }
        public int feeRate { get; set; }
        public string oid { get; set; }
        public string orderOid { get; set; }
        public string coinType { get; set; }
        public string coinTypePair { get; set; }
        public string direction { get; set; }
        public string dealDirection { get; set; }
    }
}
