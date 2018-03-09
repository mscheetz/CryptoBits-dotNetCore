using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Prohashing
{
    public class Transaction
    {
        public DateTime blocktime { get; set; }
        public string transaction_hash { get; set; }
        public double value { get; set; }
        public int height { get; set; }
    }
}
