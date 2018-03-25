using CryptoPortfolio.Business.Contracts.CryptoBits;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CryptoPortfolio.Business.Builder.Interfaces.Sources;
using CryptoPortfolio.Business.Builder.Sources;
using CryptoPortfolio.Business.Contracts.Sources;
using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Builder.CryptoPortfolio;
using CryptoPortfolio.Business.Manager;
using CryptoPortfolio.Business.Service;

namespace CryptoPortfolio.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/cryptobits")]
    public class CryptoBitsController : Controller
    {
        private ICryptoPortfolioService _service;

        public CryptoBitsController()
        {
            this._service = new CryptoPortfolioManager();
        }

        // GET: api/cryptobits/status
        [HttpGet]
        public bool GetServiceStatus()
        {
            return true;
        }

        // GET: api/cryptobits
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

        // PUT: api/cryptobits/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
