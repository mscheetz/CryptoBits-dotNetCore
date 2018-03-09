using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.EtherScan
{
    public class Response
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Transaction> result { get; set; }
    }
}
