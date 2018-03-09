using CryptoPortfolio.Business.Entities.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces.CoinMarketCap
{
    public interface ICoinMarketCapRepository
    {
        Task<IEnumerable<Coin>> GetCoins();

        Task<Coin> GetCoin(string name);
    }
}
