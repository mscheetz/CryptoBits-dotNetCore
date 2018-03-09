using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface ICryptoValueRepository
    {
        Task<IEnumerable<CryptoValue>> GetCryptoValues();

        Task<IEnumerable<CryptoValue>> GetCryptoValue(string symbol);

        Task AddCryptoValue(CryptoValue crypto);

        Task<bool> UpdateCryptoValue(CryptoValue crypto);

        Task<bool> DeleteCryptoValue(CryptoValue cryptoValue);
    }
}
