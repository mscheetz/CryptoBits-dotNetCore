using CryptoPortfolio.Business.Entities.Ethplorer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Ethplorer
{
    public interface IEthplorerRepository
    {
        Task<List<Token>> GetTokenInfo(string address);
    }
}
