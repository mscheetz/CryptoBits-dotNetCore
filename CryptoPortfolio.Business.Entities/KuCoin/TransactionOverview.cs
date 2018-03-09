using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.KuCoin
{
    public class TransactionOverview
    {
        public int total { get; set; }
        public List<Transaction> datas { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
    }
}
