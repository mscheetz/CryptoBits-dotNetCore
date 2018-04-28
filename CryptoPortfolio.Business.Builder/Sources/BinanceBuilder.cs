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
using CryptoPortfolio.Data;
using CryptoPortfolio.Business.Contracts.CryptoBits;
using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;

namespace CryptoPortfolio.Business.Builder.Sources
{
    public class BinanceBuilder : IBinanceBuilder
    {
        private IBinanceRepository _binanceRepo;
        private ITransactionBuilder _trxBldr;
        private IApiInformationBuilder _apiBldr;
        private ICoinInformationBuilder _coinBldr;
        private ICMCCoinRepository _coinRepo;
        private ObjectHelper _helper;
        private DateTimeHelper _dtHelper;
        private DateTime? lastRun;
        private List<CMCCoin> _coinList;
        private string thisLocation = Location.Binance.ToString();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cMCCoinRepository">Repository Interface</param>
        public BinanceBuilder(ITransactionBuilder transactionBuilder, IApiInformationBuilder apiInformationBuilder, ICoinInformationBuilder coinInformationBuilder)
        {
            _trxBldr = transactionBuilder;
            _apiBldr = apiInformationBuilder;
            _coinBldr = coinInformationBuilder;
            _binanceRepo = new BinanceRepository();
            this._helper = new ObjectHelper();
            this._dtHelper = new DateTimeHelper();
            this.lastRun = null;
        }
        
        /// <summary>
        /// Get current balances for account
        /// </summary>
        /// <returns>Collection of BinanceBalance objects</returns>
        public IEnumerable<BinanceBalance> GetBinanceCoins()
        {
            SetupExchangeRepo();

            var account = _binanceRepo.GetBalance().Result;

            var balanceList = _helper.CreateContract<List<Business.Entities.Binance.Balance>, List<BinanceBalance>>(account.balances);

            return balanceList;
        }
        
        /// <summary>
        /// Process new transactions
        /// </summary>
        /// <returns>Boolean value of result</returns>
        public bool ProcessNewTransactions()
        {
            var dbTrxList = GetDBTransactions();
            var exchangeTrxList = GetExchangeTransactions();
            var exchangeList = ExchangeEntityListToDbEntityList(exchangeTrxList);
            
            var newTrx = exchangeList.Where(e => !dbTrxList.Any(d => d.orderId == e.orderId));

            foreach(var trx in newTrx)
            {
                trx.exchange = Location.Binance.ToString();
            }

            var result = AddTransactionsToDb(newTrx);

            result = UpdateCoins(newTrx);

            return result;
        }

        private void SetupExchangeRepo()
        {
            var apiEntity = _apiBldr.GetApiInformationEntity(Location.Binance.ToString());

            _binanceRepo.SetExchangeApi(apiEntity);
        }

        private IEnumerable<Contracts.CryptoBits.Transaction> GetDBTransactions()
        {
            var dbTransactionList = _trxBldr.GetTransactionByLocation(thisLocation);

            return dbTransactionList;
        }

        private IEnumerable<Entities.Binance.Transaction> GetExchangeTransactions()
        {
            SetupExchangeRepo();

            var exchangeTransactionList = _binanceRepo.GetTransactions().Result.ToList();
            
            return exchangeTransactionList;
        }

        private bool AddTransactionsToDb(IEnumerable<Entities.Crypto.Transaction> transactionList)
        {
            var result = _trxBldr.AddTransactions(transactionList);

            return result;
        }

        private bool UpdateCoins(IEnumerable<Entities.Crypto.Transaction> transactionList)
        {
            var sortedTrxList = transactionList.OrderByDescending(t => t.time);

            var result = _coinBldr.NewTransactions(sortedTrxList);

            return result;
        }

        private List<Entities.Crypto.Transaction> ExchangeEntityListToDbEntityList(IEnumerable<Entities.Binance.Transaction> exchangeList)
        {
            return _helper.CreateEntity<List<Entities.Binance.Transaction>, List<Entities.Crypto.Transaction>>(exchangeList.ToList());
        }

        private Entities.ApiInformation GetApiEntity(Contracts.CryptoBits.ApiInformation contract)
        {
            return _helper.CreateEntity<Contracts.CryptoBits.ApiInformation, Entities.ApiInformation>(contract);
        }
    }
}
