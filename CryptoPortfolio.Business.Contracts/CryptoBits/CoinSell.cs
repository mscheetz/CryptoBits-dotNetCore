using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a single Coin Sell
    /// </summary>
    public class CoinSell
    {
        public decimal quantity { get; set; }
        public string pair { get; set; }
        public decimal price { get; set; }
        public DateTime saleDate { get; set; }
        public decimal fee { get; set; }
        public string feeSymbol { get; set; }
        public TransactionType transactionType { get; set; }
        public decimal qtySold { get; set; }
        public bool processed { get; set; }
    }
}
