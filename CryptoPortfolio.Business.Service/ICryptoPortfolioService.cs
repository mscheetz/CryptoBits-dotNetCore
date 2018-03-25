using CryptoPortfolio.Business.Contracts.CryptoBits;
using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Service
{
    public interface ICryptoPortfolioService
    {

        IEnumerable<Coin> GetCoins();

        IEnumerable<CMCCoin> GetCMCCoins();

        IEnumerable<CMCCoin> GetCMCCoins(string[] symbols);

        CMCCoin GetCMCCoin(string name);

        IEnumerable<Event> GetEvents(string name);

        IEnumerable<DisplayCoin> PostTransaction(NewTransaction transaction);
    }
}
