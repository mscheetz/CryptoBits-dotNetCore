using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    public class Address
    {
        public string Id { get; set; }
        public string symbol { get; set; }
        public string address { get; set; }
        public double qty { get; set; }
        public List<AddressTransaction> transactionList { get; set; }
    }
}
