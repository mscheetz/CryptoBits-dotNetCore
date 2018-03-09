using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Coinbase;
using CryptoPortfolio.Business.Helper;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data
{
    public class CoinbaseRepository : ICoinbaseRepository
    {
        private Security security;
        private IRESTRepository _restRepo;
        private string baseUrl;
        private ApiInformation _apiInfo;

        public CoinbaseRepository()
        {
            security = new Security();
            _restRepo = new RESTRepository();
            baseUrl = "https://api.coinbase.com";
            _apiInfo = new ApiInformation();
        }

        public bool SetExchangeApi(ApiInformation exchangeApi)
        {
            _apiInfo = exchangeApi;
            return true;
        }

        public async Task<TransactionResponse> GetTransactions(Guid accountId)
        {
            var req = new Request
            {
                method = "GET",
                path = $"/v2/accounts/{accountId}/transactions",
                body = ""
            };

            string url = baseUrl + req.path;

            var response = await _restRepo.GetApi<TransactionResponse>(url, GetRequestHeaders(req));

            return response;
        }

        public async Task<Account> GetBalance()
        {
            var req = new Request
            {
                method = "GET",
                path = "/v2/account",
                body = ""
            };

            string url = baseUrl + req.path;

            var response = await _restRepo.GetApi<Account>(url, GetRequestHeaders(req));

            return response;
        }

        public async Task<CoinbasePrice> GetPrice(string pair)
        {
            var req = new Request
            {
                method = "GET",
                path = $"/v2/prices/{pair}/spot",
                body = ""
            };

            string url = baseUrl + req.path;

            var response = await _restRepo.GetApi<CoinbasePriceResponse>(url, GetRequestHeaders(null));

            return response.data;
        }

        public async Task<long> GetCBTime()
        {
            var req = new Request
            {
                method = "GET",
                path = "/v2/time",
                body = ""
            };

            string url = baseUrl + req.path;

            var response = await _restRepo.GetApi<CoinbaseTimeReponse>(url, GetRequestHeaders(null));
            
            return response.data.epoch;
        }

        private Dictionary<string, string> GetRequestHeaders(Request request)
        {
            string utcDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var headers = new Dictionary<string, string>();

            if (request != null)
            {
                string nonce = GetCBTime().ToString();
                string message = $"{nonce}{request.method}{request.path}{request.body}";
                headers.Add("CB-ACCESS-KEY", _apiInfo.apiKey);
                headers.Add("CB-ACCESS-SIGN", CreateSignature(message));
                headers.Add("CB-ACCESS-TIMESTAMP", nonce);
            }
            headers.Add("CB-VERSION", utcDate);

            return headers;
        }

        private string CreateSignature(string message)
        {
            var hmac = security.GetHMACSignature(_apiInfo.apiSecret, message);
            return hmac;
        }
    }
}
