using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.KuCoin;
using CryptoPortfolio.Business.Helper;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data
{
    public class KuCoinRepository : IKuCoinRepository
    {
        private Security security;
        private IRESTRepository _restRepo;
        private string baseUrl;
        private ApiInformation _apiInfo;

        public KuCoinRepository()
        {
            security = new Security();
            _restRepo = new RESTRepository();
            baseUrl = "https://api.kucoin.com";
            _apiInfo = new ApiInformation();
        }

        public bool SetExchangeApi(ApiInformation apiInfo)
        {
            _apiInfo = apiInfo;
            return true;
        }

        public async Task<TransactionResponse> GetTransactions()
        {
            string endpoint = "/v1/order/dealt";
            string url = baseUrl + endpoint;
            
            var response = await _restRepo.GetApi<TransactionResponse>(url, GetRequestHeaders(endpoint));

            return response;
        }

        public async Task<Account> GetBalance()
        {
            string endpoint = "/v1/account/balances";
            string url = baseUrl + endpoint;
            
            var response = await _restRepo.GetApi<Account>(url, GetRequestHeaders(endpoint));

            return response;
        }

        public async Task<IEnumerable<KuCoinValue>> GetCrytpos()
        {
            string endpoint = "/v1/open/tick";
            string url = baseUrl + endpoint;

            var response = await _restRepo.GetApi<KuCoinTick>(url);

            return response.data;
        }

        public long GetKuCoinTime()
        {
            string endpoint = "/v1/time";
            string url = baseUrl + endpoint;

            var response = _restRepo.GetApi<ServerTime>(url);

            response.Wait();

            return response.Result.timestamp;
        }

        private Dictionary<string, string> GetRequestHeaders(string endpoint, string queryString = "")
        {
            string nonce = GetKuCoinTime().ToString();

            var headers = new Dictionary<string, string>();
            headers.Add("KC-API-KEY", _apiInfo.apiKey);
            headers.Add("KC-API-NONCE", nonce);
            headers.Add("KC-API-SIGNATURE", CreateSignature(endpoint, queryString, nonce));
            
            return headers;
        }

        private string CreateSignature(string endpoint, string queryString, string nonce)
        {
            string signatureString = $"{endpoint}/{nonce}/{queryString}";
            var hmac = security.GetKuCoinHMCACSignature(_apiInfo.apiSecret, signatureString);
            return hmac;
        }
    }
}
