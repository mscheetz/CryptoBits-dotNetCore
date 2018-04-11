using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface ICMCCoinRepository
    {
        Task<IEnumerable<CMCCoin>> GetCMCCoins();

        Task<bool> InsertCMCCoins(IEnumerable<CMCCoin> coinList);

        Task<bool> DeleteAllRecords();
    }
}
