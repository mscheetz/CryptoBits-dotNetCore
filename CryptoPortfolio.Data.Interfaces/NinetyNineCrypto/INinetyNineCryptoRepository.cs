using CryptoPortfolio.Business.Entities.NinetyNineCrypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces.NinetyNineCrypto
{
    public interface INinetyNineCryptoRepository
    {
        Task<IEnumerable<NinetyNineCryptoCoin>> GetCoins();
    }
}
