using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Ethplorer
{
    public class Response
    {
        public string address { get; set; }
        public ETH ETH { get; set; }
        public int countTxs { get; set; }
        public List<Token> tokens { get; set; }
    }
}
