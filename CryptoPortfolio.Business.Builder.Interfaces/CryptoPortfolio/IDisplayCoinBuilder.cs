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
        /// <param name="newTransaction">Boolean if new transaction</param>
        /// <returns>Collection of display coins</returns>
        List<DisplayCoin> GetDisplayCoins(bool newTransaction = false);

        /// <summary>
        /// Update display coins
        /// </summary>
        /// <returns>bool when complete</returns>
        bool UpdateDisplayCoins();
    }
}
