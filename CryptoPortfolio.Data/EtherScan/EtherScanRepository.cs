using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.EtherScan;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.EtherScan
{
    public class EtherScanRepository : IEtherScanRepository
    {
        private IRESTRepository _restRepo;
        private string _baseUrl;
        private ApiInformation _apiInfo;

        public EtherScanRepository()
        {
            _restRepo = new RESTRepository();
            _baseUrl = "http://api.etherscan.io/api?";
            _apiInfo = new ApiInformation();
        }

        public void SetApiInfo(ApiInformation apiInfo)
        {
            _apiInfo = apiInfo;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(string address)
        {
            var url = _baseUrl + $"?module=account&action=txlist&address={address}&startblock=0&endblock=99999999&sort=asc&apikey={_apiInfo.apiKey}";
            
            var response = await _restRepo.GetApi<Response>(url);

            return response.result;
        }
    }
}
