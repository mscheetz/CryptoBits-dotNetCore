using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface ICryptoValueBuilder
    {
        bool SetCryptoValue();

        IEnumerable<CryptoValue> GetCryptoValueList();

        CryptoValue GetCryptoValue(string symbol);

        bool AddCryptoValue(CryptoValue cryptoValue);

        bool UpdateCryptoValue(List<CryptoValue> coinInfoList);

        bool UpdateCryptoValue(CryptoValue cryptoValue);

        bool DeleteCryptoValue(CryptoValue cryptoValue);
    }
}
