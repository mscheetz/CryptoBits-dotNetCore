using CryptoPortfolio.Business.Contracts.Sources;
using CryptoPortfolio.Business.Core;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.Sources
{
    public interface INinetyNineCryptoBuilder : IBuilderEngine
    {
        IEnumerable<Coin> GetAllCoins();
    }
}
