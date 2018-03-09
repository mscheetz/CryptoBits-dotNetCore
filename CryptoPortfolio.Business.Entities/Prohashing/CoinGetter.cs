using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.Prohashing
{
    public class CoinGetter
    {
        public string address { get; set; }
        public int coinId { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }

        public CoinGetter(string address, int coinId)
        {
            this.address = address;
            this.coinId = coinId;
            this.page = 1;
            this.pageCount = 2000;
        }

    }
}
