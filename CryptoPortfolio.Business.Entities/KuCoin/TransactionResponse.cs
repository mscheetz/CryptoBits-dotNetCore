using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.KuCoin
{
    public class TransactionResponse : KuCoinResponse
    {
        public TransactionOverview data { get; set; }
    }
}
