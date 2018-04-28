using CryptoPortfolio.Business.Contracts.CryptoBits;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CryptoPortfolio.Business.Contracts.Sources;
using CryptoPortfolio.Business.Service;

namespace CryptoPortfolio.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/cryptobits")]
    public class CryptoBitsController : Controller
    {
        private ICryptoPortfolioService _service;

        public CryptoBitsController(ICryptoPortfolioService service)
        {
            this._service = service;
        }
        
        // GET: api/cryptobits/status
        [HttpGet("status")]
        public bool GetServiceStatus()
        {
            return true;
        }

        // GET: api/cryptobits/coins
        [HttpGet("coins")]
        public IEnumerable<Coin> GetCoins()
        {
            return this._service.GetCoins();
        }

        // GET: api/cryptobits/cmc
        [HttpGet("cmc")]
        public IEnumerable<CMCCoin> GetCMCCoins()
        {
            return this._service.GetCMCCoins();
        }

        // POST: api/cryptobits/cmc
        [HttpPost("cmc")]
        public IEnumerable<CMCCoin> GetCMCCoins([FromBody]string[] symbols)
        {
            return this._service.GetCMCCoins(symbols);
        }

        // GET: api/cryptobits/cmc/{coinName}
        [HttpGet("cmc/{name}", Name = "Get")]
        public CMCCoin GetCMCCoin(string name)
        {
            return this._service.GetCMCCoin(name);
        }

        // GET: api/cryptobits/events/{coinName}
        [HttpGet("events/{name}")]
        public IEnumerable<Event> GetEvents(string name)
        {
            return this._service.GetEvents(name);
        }

        // POST: api/cryptobits/transaction
        [HttpPost("transaction")]
        public IEnumerable<DisplayCoin> PostTransaction([FromBody]NewTransaction transaction)
        {
            return this._service.PostTransaction(transaction);
        }

        // GET: api/cryptobits/transaction
        [HttpGet("transaction")]
        public IEnumerable<Transaction> GetTransactions()
        {
            return this._service.GetTransactions();
        }

        // GET: api/cryptobits/displaycoin
        [HttpGet("displaycoin")]
        public IEnumerable<DisplayCoin> GetDisplayCoins()
        {
            return this._service.GetDisplayCoins();
        }

        // GET: api/cryptobits/displaycoin/{symbol}
        [HttpGet("displaycoin/{symbol}")]
        public DisplayCoin GetDisplayCoin(string symbol)
        {
            return this._service.GetDisplayCoin(symbol);
        }

        // GET: api/cryptobits/apiInformation
        [HttpGet("apiInformation")]
        public IEnumerable<ApiInformation> GetApiInformaition()
        {
            return this._service.GetApiInformation();
        }

        // GET: api/cryptobits/apiInformation/{apiSource}
        [HttpGet("apiInformation/{apiSource}")]
        public ApiInformation GetApiInformaition(string apiSource)
        {
            return this._service.GetApiInformation(apiSource);
        }

        // POST: api/cryptobits/apiInformation
        [HttpPost("apiInformation")]
        public bool PostApiInformation([FromBody]ApiInformation apiInformation)
        {
            return this._service.PostApiInformation(apiInformation);
        }

        // PUT: api/cryptobits/apiInformation
        [HttpPut("apiInformation")]
        public bool PutApiInformation([FromBody]ApiInformation apiInformation)
        {
            return this._service.PutApiInformation(apiInformation);
        }

        // DELETE: api/cryptobits/apiInformation/{apiId}
        [HttpDelete("apiInformation/{apiId}")]
        public bool DeleteApiInformation(string apiId)
        {
            return this._service.DeleteApiInformation(apiId);
        }

        // GET: api/cryptobits/binance/balances
        [HttpGet("binance/balances")]
        public IEnumerable<BinanceBalance> GetBinanceBalances()
        {
            return this._service.GetBinanceBalances();
        }

        // GET: api/cryptobits/binance/balances
        [HttpGet("binance/balances/nozero")]
        public IEnumerable<BinanceBalance> GetBinanceBalancesNoZero()
        {
            return this._service.GetBinanceBalances(true);
        }

        // GET: api/cryptobits/binance/transactions
        [HttpGet("binance/transactions")]
        public bool BinanceUpdate()
        {
            return this._service.UpdateBinanceTransactions();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
