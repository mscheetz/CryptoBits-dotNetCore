using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.KuCoin
{
    public class KuCoinTick : KuCoinResponse
    {
        public List<KuCoinValue> data { get; set; }
    }
}
