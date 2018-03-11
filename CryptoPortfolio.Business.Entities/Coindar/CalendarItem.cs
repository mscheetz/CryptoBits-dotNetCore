using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Coindar
{
    public class CalendarItem
    {
        public string caption { get; set; }
        public string proof { get; set; }
        public string caption_ru { get; set; }
        public string proof_ru { get; set; }
        public DateTime? public_date { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string coin_name { get; set; }
        public string coin_symbol { get; set; }
    }
}
