using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    public class Request
    {
        public string method { get; set; }
        public string path { get; set; }
        public string body { get; set; }
    }
}
