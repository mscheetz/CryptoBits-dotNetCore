using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.KuCoin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface IKuCoinRepository
    {
        bool SetExchangeApi(ApiInformation exchangeApi);

        Task<TransactionResponse> GetTransactions();

        Task<Account> GetBalance();

        long GetKuCoinTime();
    }
}
