using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.Sources
{
    public interface ICoindarBuilder
    {
        /// <summary>
        /// Get Events for a given coin
        /// </summary>
        /// <param name="coinName">String of coin name</param>
        /// <returns>Collection of Cal</returns>
        IEnumerable<Event> GetEvents(string coinName);
    }
}
