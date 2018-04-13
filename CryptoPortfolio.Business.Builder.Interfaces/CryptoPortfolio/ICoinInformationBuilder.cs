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
        /// <param name="updateCoin">Update coin info in database? (default = true)</param>
        /// <returns>boolean when complete</returns>
        bool NewTransaction(Contracts.CryptoBits.NewTransaction transaction, bool updateCoin = true);
        
        /// <summary>
        /// Process new transactions from an exchange
        /// </summary>
        /// <param name="transactionList">Collection of transactions to process</param>
        /// <returns>boolean when complete</returns>
        bool NewTransactions(IEnumerable<Entities.Crypto.Transaction> transactionList);
    }
}
