using CryptoPortfolio.Business.Builder.CryptoPortfolio;
using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Builder.Interfaces.Sources;
using CryptoPortfolio.Business.Builder.Sources;
using CryptoPortfolio.Business.Service;
using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;
using System.Text;
using CryptoPortfolio.Business.Contracts.CryptoBits;
using System.Net.Http;
using System.Net;
using System.Linq;

namespace CryptoPortfolio.Business.Manager
{
    public class CryptoPortfolioManager : ICryptoPortfolioService
    {
        private INinetyNineCryptoBuilder _nnBldr;
        private ICoindarBuilder _coindarBldr;
        private ICoinMarketCapBuilder _cmcBldr;
        private ICoinInformationBuilder _coinInfoBldr;
        private IDisplayCoinBuilder _displayCoinBldr;
        private IApiInformationBuilder _apiBldr;
        private ITransactionBuilder _trxBldr;

        public CryptoPortfolioManager(IApiInformationBuilder apiInformationBuilder, ICoinInformationBuilder coinInfoBuilder, ITransactionBuilder transactionBuilder)
        {
            this._nnBldr = new NinetyNineCryptoBuilder();
            this._coindarBldr = new CoindarBuilder();
            this._cmcBldr = new CoinMarketCapBuilder();
            this._coinInfoBldr = coinInfoBuilder;
            this._displayCoinBldr = new DisplayCoinBuilder(coinInfoBuilder);
            this._apiBldr = apiInformationBuilder;
            this._trxBldr = transactionBuilder;
        }

        public IEnumerable<Coin> GetCoins()
        {
            return this._nnBldr.GetAllCoins();
        }

        public IEnumerable<CMCCoin> GetCMCCoins()
        {
            return this._cmcBldr.GetCoins();
        }

        public IEnumerable<CMCCoin> GetCMCCoins(string[] symbols)
        {
            return this._cmcBldr.GetCoins(symbols);
        }

        public CMCCoin GetCMCCoin(string name)
        {
            return this._cmcBldr.GetCoin(name);
        }

        public IEnumerable<Event> GetEvents(string name)
        {
            return this._coindarBldr.GetEvents(name);
        }

        public IEnumerable<DisplayCoin> PostTransaction(NewTransaction transaction)
        {
            var status = this._trxBldr.AddNewTransaction(transaction);

            if(!status)
            {
                // TODO: Throw error
                return new List<DisplayCoin>();
            }

            status = this._coinInfoBldr.NewTransaction(transaction);

            if (status)
            {
                return this._displayCoinBldr.GetDisplayCoins(status);
            }
            else
            {
                // TODO: Throw error
                return new List<DisplayCoin>();
            }
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return this._trxBldr.GetTransactions();
        }

        public IEnumerable<DisplayCoin> GetDisplayCoins()
        {
            return this._displayCoinBldr.GetDisplayCoins();
        }

        public DisplayCoin GetDisplayCoin(string symbol)
        {
            var displayCoins = this._displayCoinBldr.GetDisplayCoins();

            return displayCoins.Where(d => d.symbol.Equals(symbol)).FirstOrDefault();
        }

        public IEnumerable<ApiInformation> GetApiInformation()
        {
            return _apiBldr.GetApiInformation();
        }

        public ApiInformation GetApiInformation(string apiName)
        {
            var apiInformationList = _apiBldr.GetApiInformation();

            return apiInformationList.Where(a => a.apiSource.Equals(apiName)).FirstOrDefault();
        }

        public bool PostApiInformation(ApiInformation apiInformation)
        {
            return _apiBldr.AddApiInformation(apiInformation);
        }

        public bool DeleteApiInformation(string apiId)
        {
            return _apiBldr.DeleteApiInformation(apiId);
        }
    }
}
