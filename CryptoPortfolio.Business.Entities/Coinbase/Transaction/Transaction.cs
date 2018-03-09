using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    public class Transaction
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public Balance amount { get; set; }
        public Balance native_amount { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string resource { get; set; }
        public string resource_path { get; set; }
        public Buy buy { get; set; }
        public Details details { get; set; }
        public To to { get; set; }
        public Network network { get; set; }
    }
}
