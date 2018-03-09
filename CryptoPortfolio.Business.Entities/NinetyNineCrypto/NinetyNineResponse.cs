using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Entities.NinetyNineCrypto
{
    public class NinetyNineResponse
    {
        public string status { get; set; }
        public NinetyNineCryptoCoin[] result { get; set; }
    }
}
