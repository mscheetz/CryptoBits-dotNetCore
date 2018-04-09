using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface IApiInformationRepository
    {
        Task<IEnumerable<ApiInformation>> GetApiInfo();

        Task<IEnumerable<ApiInformation>> GetApiInfo(string apiSource);

        Task AddApiInfo(ApiInformation api);

        Task<bool> UpdateApiInfo(ApiInformation api);

        Task<bool> DeleteApiInfo(ApiInformation api);

        Task<bool> DeleteApiInfoById(string Id);
    }
}
