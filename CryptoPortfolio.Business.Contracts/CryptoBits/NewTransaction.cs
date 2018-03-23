using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    public class NewTransaction
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string pair { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }
        public double fee { get; set; }
        public string feeSymbol { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public TransactionType transactionType { get; set; }
        public Location sourceLocation { get; set; }
        public Address sourceAddress { get; set; }
        public Location destinationLocation { get; set; }
        public Address destinationAdderess { get; set; }
        public string trxId { get; set; }
        public string trxSource { get; set; }
    }
}
