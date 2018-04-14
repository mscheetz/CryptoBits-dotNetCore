using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Binance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface IBinanceRepository
    {
        bool SetExchangeApi(ApiInformation exchangeApi);

        Task<IEnumerable<Transaction>> GetTransactions();

        Task<Account> GetBalance();

        Task<IEnumerable<BinanceTick>> GetCrytpos();

        long GetBinanceTime();
    }
}
