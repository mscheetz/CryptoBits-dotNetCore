using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Ethplorer;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Ethplorer
{
    public class EthplorerRepository : IEthplorerRepository
    {
        private IRESTRepository _restRepo;
        private string baseUrl;
        private ApiInformation _apiInfo;

        public EthplorerRepository()
        {
            _restRepo = new RESTRepository();
            baseUrl = "https://api.ethplorer.io";
            //apiKey = "freeKey";
            _apiInfo = new ApiInformation();
        }

        public void SetApiInfo(ApiInformation apiInfo)
        {
            _apiInfo = apiInfo;
        }

        public async Task<List<Token>> GetTokenInfo(string address)
        {
            var url = baseUrl + $"/getAddressInfo/{address}?apiKey={_apiInfo.apiKey}";
            
            var response = await _restRepo.GetApi<Response>(url);

            return response.tokens;
        }
    }
}
