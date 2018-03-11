using CryptoPortfolio.Business.Entities.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces.CoinMarketCap
{
    public interface ICoinMarketCapRepository
    {
        /// <summary>
        /// Gets all coin tickers
        /// </summary>
        /// <returns>Collection of Coin</returns>
        Task<IEnumerable<Coin>> GetCoins();

        /// <summary>
        /// Gets coin ticker
        /// </summary>
        /// <param name="name">String of coin name</param>
        /// <returns>Coin object</returns>
        Task<Coin> GetCoin(string name);
    }
}
