using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface ICoinInfoRepository
    {
        Task<IEnumerable<CoinInfo>> GetCoinInfo();

        Task<IEnumerable<CoinInfo>> GetCoinInfo(string symbol);

        Task AddCoinInfo(CoinInfo coinInfo);

        Task<bool> UpdateCoinInfo(CoinInfo coinInfo);

        Task<bool> DeleteCoinInfo(CoinInfo coinInfo);
    }
}
