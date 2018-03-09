using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface IBalanceRepository
    {
        Task<IEnumerable<Balance>> GetBalances();

        Task<IEnumerable<Balance>> GetBalance(string symbol);

        Task AddBalance(Balance balance);

        Task<bool> UpdateBalance(Balance balance);

        Task<bool> DeleteBalance(Balance balance);
    }
}
