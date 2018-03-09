using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Prohashing
{
    public class AddressDetail
    {
        public double balance { get; set; }
        public string address { get; set; }
        public int transactionCount { get; set; }
    }
}
