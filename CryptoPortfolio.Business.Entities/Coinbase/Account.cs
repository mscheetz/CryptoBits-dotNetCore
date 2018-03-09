using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coinbase
{
    public class Account
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool primary { get; set; }
        public string type { get; set; }
        public string currency { get; set; }
        public Balance balance { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string resource { get; set; }
        public string resource_path { get; set; }
        public bool ready { get; set; }
    }
}
