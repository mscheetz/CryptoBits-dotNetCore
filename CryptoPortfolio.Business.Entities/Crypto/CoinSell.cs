using System;

namespace CryptoPortfolio.Business.Entities.Crypto
{
    public class CoinSell
    {
        public double quantity { get; set; }
        public string pair { get; set; }
        public double price { get; set; }
        public DateTime saleDate { get; set; }
        public double fee { get; set; }
        public string feeSymbol { get; set; }
        public string transactionType { get; set; }
        public double qtySold { get; set; }
        public bool processed { get; set; }
    }
}
