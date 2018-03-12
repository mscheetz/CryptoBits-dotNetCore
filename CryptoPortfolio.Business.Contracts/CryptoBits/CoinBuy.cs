using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    /// <summary>
    /// Represents a single CoinBuy
    /// </summary>
    public class CoinBuy
    {
        public decimal quantity { get; set; }
        public string pair { get; set; }
        public decimal price { get; set; }
        public DateTime buyDate { get; set; }
        public List<CoinSell> coinSellList { get; set; }
        public decimal fee { get; set; }
        public string feeSymbol { get; set; }
        public TransactionType transactionType { get; set; }
        public decimal available { get; set; }
    }
}
