using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.Sources
{
    public interface ICoinMarketCapBuilder
    {
        IEnumerable<CMCCoin> GetCoins();

        CMCCoin GetCoin(string name);
    }
}
