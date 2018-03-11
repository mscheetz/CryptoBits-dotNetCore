using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Contracts.Sources
{
    public class Event
    {
        public string caption { get; set; }
        public string proof { get; set; }
        public DateTime? publicDate { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string coinName { get; set; }
        public string coinSymbol { get; set; }
    }
}
