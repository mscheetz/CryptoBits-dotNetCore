using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface ICoinInformationBuilder
    {
        /// <summary>
        /// Get coin information
        /// </summary>
        /// <returns>Collection of CoinInformation</returns>
        IEnumerable<CoinInformation> GetCoinInformation();

        /// <summary>
        /// Process a new transaction from the UI
        /// </summary>
        /// <param name="transaction">NewTransaction object to process</param>
        /// <returns>boolean when complete</returns>
        bool NewTransaction(Contracts.CryptoBits.NewTransaction transaction);
    }
}
