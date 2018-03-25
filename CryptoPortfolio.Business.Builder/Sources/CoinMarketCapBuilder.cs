using CryptoPortfolio.Business.Builder.Interfaces.Sources;
using CryptoPortfolio.Business.Contracts.Sources;
using CryptoPortfolio.Business.Entities.CoinMarketCap;
using CryptoPortfolio.Data.Interfaces.CoinMarketCap;
using CryptoPortfolio.Data.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Text;
using CryptoPortfolio.Business.Helper;
using System.Linq;

namespace CryptoPortfolio.Business.Builder.Sources
{
    public class CoinMarketCapBuilder : ICoinMarketCapBuilder
    {
        private ICoinMarketCapRepository _repo;
        private ObjectHelper _helper;
        private DateTime? lastRun;
        private DateTime currentTime;
        private List<CMCCoin> _coinList;

        public CoinMarketCapBuilder()
        {
            _repo = new CoinMarketCapRepository();
            this._helper = new ObjectHelper();
            this.lastRun = null;
        }

        /// <summary>
        /// Get all coins
        /// </summary>
        /// <returns>Collection of CMCCoin</returns>
        public IEnumerable<CMCCoin> GetCoins()
        {
            if (RunSetter())
            {
                SetCoins();
            }

            return this._coinList;
        }

        /// <summary>
        /// Get all coins matching given symbols
        /// </summary>
        /// <param name="symbols">Array of symbols</param>
        /// <returns>Collection of CMCCoin</returns>
        public IEnumerable<CMCCoin> GetCoins(string[] symbols)
        {
            if (RunSetter())
            {
                SetCoins();
            }
            
            var symbolSet = new HashSet<string>(symbols);

            return this._coinList.Where(c => symbolSet.Contains(c.symbol));
        }

        /// <summary>
        /// Get a coin by a name
        /// </summary>
        /// <param name="name">String of name</param>
        /// <returns>CMCCoin object</returns>
        public CMCCoin GetCoin(string name)
        {
            if (RunSetter())
            {
                SetCoins();
            }

            return this._coinList.Where(c => c.name == name).FirstOrDefault();
        }

        /// <summary>
        /// Calculate if setters should be re-run
        /// Re-run if more than 30 seconds have passed since last run
        /// Or if no runs have been made
        /// </summary>
        /// <returns>Bool of result</returns>
        private bool RunSetter()
        {
            if (lastRun == null || _helper.CompareSeconds((DateTime)lastRun) >= 30)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set CoinList
        /// </summary>
        private void SetCoins()
        {
            var coinEntityList = _repo.GetCoins().Result;

            this.lastRun = DateTime.UtcNow;

            this._coinList = GetContractList(coinEntityList);
        }

        /// <summary>
        /// Set one coin in CoinList
        /// </summary>
        /// <param name="name"></param>
        private void SetCoin(string name)
        {
            var coinEntity = _repo.GetCoin(name).Result;

            this.lastRun = DateTime.UtcNow;

            var coin = GetContract(coinEntity);

            var index = _coinList.IndexOf(_coinList.Where(c => c.name == name).FirstOrDefault());

            if(index < 0)
            {
                _coinList.Add(coin);
            }
            else
            {
                _coinList[index] = coin;
            }
        }

        /// <summary>
        /// Conver entity object to contract object
        /// </summary>
        /// <param name="entity">Entity object to convert</param>
        /// <returns>CMCCoin object</returns>
        private CMCCoin GetContract(Entities.CoinMarketCap.Coin entity)
        {
            return this._helper.CreateContract<Entities.CoinMarketCap.Coin, CMCCoin>(entity);
        }

        /// <summary>
        /// Convert entity collection to contract collection
        /// </summary>
        /// <param name="entityList">Entity collection to convert</param>
        /// <returns>Collection of CMCCoin objects</returns>
        private List<CMCCoin> GetContractList(IEnumerable<Entities.CoinMarketCap.Coin> entityList)
        {
            return this._helper.CreateContract<IEnumerable<Entities.CoinMarketCap.Coin>, List<CMCCoin>>(entityList);
        }
    }
}
