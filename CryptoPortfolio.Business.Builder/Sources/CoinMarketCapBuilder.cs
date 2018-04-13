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
using CryptoPortfolio.Data.Interfaces;
using System.Globalization;

namespace CryptoPortfolio.Business.Builder.Sources
{
    public class CoinMarketCapBuilder : ICoinMarketCapBuilder
    {
        private ICoinMarketCapRepository _cmcRepo;
        private ICMCCoinRepository _coinRepo;
        private ObjectHelper _helper;
        private DateTimeHelper _dtHelper;
        private DateTime? lastRun;
        private List<CMCCoin> _coinList;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cMCCoinRepository">Repository Interface</param>
        public CoinMarketCapBuilder(ICMCCoinRepository cMCCoinRepository)
        {
            _coinRepo = cMCCoinRepository;
            _cmcRepo = new CoinMarketCapRepository();
            this._helper = new ObjectHelper();
            this._dtHelper = new DateTimeHelper();
            this.lastRun = null;
            LoadCoinsFromDB();
        }

        /// <summary>
        /// Load CMC coins from database
        /// </summary>
        public void LoadCoinsFromDB()
        {
            var entityList = _coinRepo.GetCMCCoins().Result.ToList();

            _coinList = GetContractListFromDbEntityList(entityList);

            string lastRunDate = entityList == null || entityList.Count == 0 ? null : entityList.Select(e => e.last_imported).First();

            lastRun = lastRunDate == null ? null : _dtHelper.UnixTimeToUTC(lastRunDate);
            
            if(RunSetter())
            {
                SetCoins();
            }
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
            if (lastRun == null || _dtHelper.CompareSeconds((DateTime)lastRun) <= -1000)
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
            var coinEntityList = _cmcRepo.GetCoins().Result;

            var lastRunUnix = _dtHelper.UTCtoUnixTime();

            this.lastRun = _dtHelper.UnixTimeToUTC(lastRunUnix);

            this._coinList = GetContractListFromApiEntityList(coinEntityList);

            UpdateDbCoins(coinEntityList, lastRunUnix);
        }

        /// <summary>
        /// Update coin list in database
        /// </summary>
        /// <param name="entityList">Collection of API Entities</param>
        /// <param name="unixTimeStamp">Current unix timestamp</param>
        private void UpdateDbCoins(IEnumerable<Entities.CoinMarketCap.Coin> entityList, long unixTimeStamp)
        {
            var dbEntityList = ApiEntityListToDbEntityList(entityList);

            _coinRepo.DeleteAllRecords();

            foreach(var dbEntity in dbEntityList)
            {
                dbEntity.last_imported = unixTimeStamp.ToString();
            }

            _coinRepo.InsertCMCCoins(dbEntityList);

        }

        /// <summary>
        /// Set one coin in CoinList
        /// </summary>
        /// <param name="name"></param>
        private void SetCoin(string name)
        {
            var coinEntity = _cmcRepo.GetCoin(name).Result;

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
        /// Convert Api Entity list to DB Entity List
        /// </summary>
        /// <param name="entityList">Api Entity list to convert</param>
        /// <returns>Collection of DB Entity objects</returns>
        private List<Entities.Crypto.CMCCoin> ApiEntityListToDbEntityList(IEnumerable<Entities.CoinMarketCap.Coin> entityList)
        {
            return this._helper.CreateEntity<IEnumerable<Entities.CoinMarketCap.Coin>, List<Entities.Crypto.CMCCoin>>(entityList);
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
        private List<CMCCoin> GetContractListFromApiEntityList(IEnumerable<Entities.CoinMarketCap.Coin> entityList)
        {
            return this._helper.CreateContract<IEnumerable<Entities.CoinMarketCap.Coin>, List<CMCCoin>>(entityList);
        }

        /// <summary>
        /// Convert entity collection to contract collection
        /// </summary>
        /// <param name="entityList">Entity collection to convert</param>
        /// <returns>Collection of CMCCoin objects</returns>
        private List<CMCCoin> GetContractListFromDbEntityList(IEnumerable<Entities.Crypto.CMCCoin> entityList)
        {
            return this._helper.CreateContract<IEnumerable<Entities.Crypto.CMCCoin>, List<CMCCoin>>(entityList);
        }
    }
}
