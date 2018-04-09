using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface IApiInformationBuilder
    {
        bool SetApiInformation();

        IEnumerable<ApiInformation> GetApiInformation();

        ApiInformation GetApiInformation(string apiName);

        bool AddApiInformation(ApiInformation api);

        bool UpdateApiInformation(ApiInformation api);

        bool DeleteApiInformation(string apiId);
    }
}
