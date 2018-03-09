using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    public class Pagination
    {
        public object ending_before { get; set; }
        public object starting_after { get; set; }
        public int limit { get; set; }
        public string order { get; set; }
        public object previous_uri { get; set; }
        public object next_uri { get; set; }
    }
}
