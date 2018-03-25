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

namespace CryptoPortfolio.Business.Manager
{
    public class CryptoPortfolioManager : ICryptoPortfolioService
    {
        private INinetyNineCryptoBuilder _nnBldr;
        private ICoindarBuilder _coindarBldr;
        private ICoinMarketCapBuilder _cmcBldr;
        private ICoinInformationBuilder _coinInfoBldr;
        private IDisplayCoinBuilder _displayCoinBldr;

        public CryptoPortfolioManager()
        {
            this._nnBldr = new NinetyNineCryptoBuilder();
            this._coindarBldr = new CoindarBuilder();
            this._cmcBldr = new CoinMarketCapBuilder();
            this._coinInfoBldr = new CoinInformationBuilder();
            this._displayCoinBldr = new DisplayCoinBuilder();
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
            var status = this._coinInfoBldr.NewTransaction(transaction);

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
    }
}
