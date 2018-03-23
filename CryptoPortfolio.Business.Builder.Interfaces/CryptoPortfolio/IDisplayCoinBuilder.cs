using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface IDisplayCoinBuilder
    {
        /// <summary>
        /// Get display coins
        /// </summary>
        /// <returns>Collection of display coins</returns>
        List<DisplayCoin> GetDisplayCoins();

        /// <summary>
        /// Update display coins
        /// </summary>
        /// <returns>bool when complete</returns>
        bool UpdateDisplayCoins();
    }
}
