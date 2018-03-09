using CryptoPortfolio.Business.Entities.NinetyNineCrypto;
using CryptoPortfolio.Data.Interfaces;
using CryptoPortfolio.Data.Interfaces.NinetyNineCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.NinetyNineCrypto
{
    public class NinetyNineCryptoRepository : INinetyNineCryptoRepository
    {
        private IRESTRepository _restRepo;
        private string baseUrl;

        public NinetyNineCryptoRepository()
        {
            _restRepo = new RESTRepository();
            baseUrl = "https://api.99cryptocoin.com";
        }

        public async Task<IEnumerable<NinetyNineCryptoCoin>> GetCoins()
        {
            var url = baseUrl + $"/v1/coins";
            
            var response = await _restRepo.GetApiStream<NinetyNineResponse>(url);

            return response.result;
        }
    }
}
