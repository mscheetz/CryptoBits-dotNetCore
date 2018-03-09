using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Coinbase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface ICoinbaseRepository
    {
        bool SetExchangeApi(ApiInformation exchangeApi);

        Task<TransactionResponse> GetTransactions(Guid accountId);

        Task<Account> GetBalance();

        Task<CoinbasePrice> GetPrice(string pair);

        Task<long> GetCBTime();
    }
}
