using CryptoPortfolio.Business.Entities.CoinMarketCap;
using CryptoPortfolio.Data.Interfaces;
using CryptoPortfolio.Data.Interfaces.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.CoinMarketCap
{
    public class CoinMarketCapRepository : ICoinMarketCapRepository
    {
        private IRESTRepository _restRepo;
        private string baseUrl;

        public CoinMarketCapRepository()
        {
            _restRepo = new RESTRepository();
            baseUrl = "https://api.coinmarketcap.com";
        }

        /// <summary>
        /// Gets all coin tickers
        /// </summary>
        /// <returns>Collection of Coin</returns>
        public async Task<IEnumerable<Coin>> GetCoins()
        {
            var url = baseUrl + $"/v1/ticker/?limit=0";
            
            var response = await _restRepo.GetApi<List<Coin>>(url);

            return response;
        }

        /// <summary>
        /// Gets coin ticker
        /// </summary>
        /// <param name="name">String of coin name</param>
        /// <returns>Coin object</returns>
        public async Task<Coin> GetCoin(string name)
        {
            var url = baseUrl + $"/v1/ticker/{name}";

            var response = await _restRepo.GetApi<List<Coin>>(url);

            return response.FirstOrDefault();
        }
    }
}
