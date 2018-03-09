using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    public class AddressTransaction
    {
        public DateTime blockTime { get; set; }
        public string hash { get; set; }
        public double value { get; set; }
    }
}
