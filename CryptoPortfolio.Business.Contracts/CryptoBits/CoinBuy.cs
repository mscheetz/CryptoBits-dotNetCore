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
        public double quantity { get; set; }
        public string pair { get; set; }
        public double price { get; set; }
        public DateTime buyDate { get; set; }
        public List<CoinSell> coinSellList { get; set; }
        public double fee { get; set; }
        public string feeSymbol { get; set; }
        public TransactionType transactionType { get; set; }
        public double available { get; set; }
    }
}
