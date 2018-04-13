using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.Sources
{
    public interface IBinanceBuilder
    {
        /// <summary>
        /// Process new transactions
        /// </summary>
        /// <returns>Boolean value of result</returns>
        bool ProcessNewTransactions();
    }
}
