using CryptoPortfolio.Business.Builder.Interfaces.Sources;
using CryptoPortfolio.Business.Contracts.Sources;
using CryptoPortfolio.Business.Entities.CoinMarketCap;
using CryptoPortfolio.Data.Interfaces.CoinMarketCap;
using CryptoPortfolio.Data.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Text;
using CryptoPortfolio.Business.Helper;

namespace CryptoPortfolio.Business.Builder.Sources
{
    public class CoinMarketCapBuilder : ICoinMarketCapBuilder
    {
        private ICoinMarketCapRepository _repo;
        private ObjectHelper _helper;

        public CoinMarketCapBuilder()
        {
            _repo = new CoinMarketCapRepository();
            this._helper = new ObjectHelper();
        }

        public CMCCoin GetCoin(string name)
        {
            var coinEntity = _repo.GetCoin(name).Result;

            return GetContract(coinEntity);
        }

        private CMCCoin GetContract(Entities.CoinMarketCap.Coin entity)
        {
            return this._helper.CreateContract<Entities.CoinMarketCap.Coin, CMCCoin>(entity);            
        }
    }
}
