using CryptoPortfolio.Business.Entities.Prohashing;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Prohashing
{
    public class ProhashingRepository : IProhashingRepository
    {
        private IRESTRepository _restRepo;
        private string baseUrl;

        public ProhashingRepository()
        {
            _restRepo = new RESTRepository();
            baseUrl = "https://prohashing.com/explorerJson";
        }

        public async Task<IEnumerable<Cryptocurrency>> GetCryptos()
        {
            var url = baseUrl + "/explorerCoins";
            
            var response = await _restRepo.GetApi<List<Cryptocurrency>>(url);

            return response;
        }

        public async Task<AddressDetail> GetAddressDetail(CoinGetter coin)
        {
            var url = baseUrl + $"/getAddress?address={coin.address}&coin_id={coin.coinId}";

            var response = await _restRepo.GetApi<AddressDetail>(url);

            return response;
        }

        public async Task<IEnumerable<Transaction>> GetAddressTransactions(CoinGetter coin)
        {
            var url = baseUrl + $"/getTransactionsByAddress?$params=%7B%22page%22:{coin.page},%22count%22:{coin.pageCount},%22filter%22:%7B%7D,%22sorting%22:%7B%22blocktime%22:%22asc%22%7D,%22group%22:%7B%7D,%22groupBy%22:null%7D&address={coin.address}&coin_id={coin.coinId}";
            
            var response = await _restRepo.GetApi<TransactionResponse>(url);

            return response.data;
        }
    }
}
