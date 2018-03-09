using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface ICoinInfoBuilder
    {
        bool SetCoinInfo();

        IEnumerable<CoinInfo> GetCoinInfoList();

        CoinInfo GetCoinInformation(string apiName);

        bool AddCoinInfo(CoinInfo api);

        bool UpdateCoinInfo(List<CoinInfo> coinInfoList);

        bool UpdateCoinInfo(CoinInfo api);

        bool DeleteCoinInfo(CoinInfo api);
    }
}
