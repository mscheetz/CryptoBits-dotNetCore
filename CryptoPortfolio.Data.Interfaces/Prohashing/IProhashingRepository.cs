using CryptoPortfolio.Business.Entities.Prohashing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Prohashing
{
    public interface IProhashingRepository
    {
        Task<IEnumerable<Cryptocurrency>> GetCryptos();

        Task<AddressDetail> GetAddressDetail(CoinGetter coin);

        Task<IEnumerable<Transaction>> GetAddressTransactions(CoinGetter coin);
    }
}
