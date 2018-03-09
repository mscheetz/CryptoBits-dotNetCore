using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    public class TransactionResponse : CoinbaseResponse
    {
        public Transaction data { get; set; }
    }
}
