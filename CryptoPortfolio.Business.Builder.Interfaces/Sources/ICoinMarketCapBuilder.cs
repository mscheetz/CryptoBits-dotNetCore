using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.Sources
{
    public interface ICoinMarketCapBuilder
    {
        /// <summary>
        /// Get all coins
        /// </summary>
        /// <returns>Collection of CMCCoin</returns>
        IEnumerable<CMCCoin> GetCoins();

        /// <summary>
        /// Get all coins matching given symbols
        /// </summary>
        /// <param name="symbols">Array of symbols</param>
        /// <returns>Collection of CMCCoin</returns>
        IEnumerable<CMCCoin> GetCoins(string[] symbols);

        /// <summary>
        /// Get a coin by a name
        /// </summary>
        /// <param name="name">String of name</param>
        /// <returns>CMCCoin object</returns>
        CMCCoin GetCoin(string name);
    }
}
