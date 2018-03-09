using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface IBalanceBuilder
    {
        void SetBalanceList();

        IEnumerable<Balance> GetBalanceList();

        IEnumerable<Balance> GetBalance(string symbol);

        IEnumerable<Balance> GetBalance(string symbol, string location);

        bool AddBalance(Balance balance);

        bool UpdateBalance(Balance balance);

        bool UpdateBalances(List<Balance> balances);

        bool DeleteBalance(Balance balance);
    }
}
