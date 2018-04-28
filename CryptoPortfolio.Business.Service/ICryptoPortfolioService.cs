using CryptoPortfolio.Business.Contracts.CryptoBits;
using CryptoPortfolio.Business.Contracts.Sources;
using System.Collections.Generic;

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

        IEnumerable<Transaction> GetTransactions();

        IEnumerable<DisplayCoin> GetDisplayCoins();
        
        DisplayCoin GetDisplayCoin(string symbol);

        IEnumerable<ApiInformation> GetApiInformation();

        ApiInformation GetApiInformation(string apiName);

        bool PostApiInformation(ApiInformation apiInformation);

        bool PutApiInformation(ApiInformation apiInformation);

        bool DeleteApiInformation(string apiId);

        IEnumerable<BinanceBalance> GetBinanceBalances(bool omitZero = false);

        bool UpdateBinanceTransactions();
    }
}
