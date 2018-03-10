using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CryptoPortfolio.Business.Builder.Interfaces.Sources;
using CryptoPortfolio.Business.Builder.Sources;
using CryptoPortfolio.Business.Contracts.Sources;
using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Builder.CryptoPortfolio;
using Microsoft.Extensions.Options;
using CryptoPortfolio.Business.Entities.Crypto;

namespace CryptoPortfolio.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/cryptobits")]
    public class CryptoBitsController : Controller
    {
        private INinetyNineCryptoBuilder _nnBldr;
        private ICoinMarketCapBuilder _cmcBldr;
        private ITransactionBuilder _trxBldr;

        public CryptoBitsController(ITransactionBuilder trxBuilder)
        {
            this._nnBldr = new NinetyNineCryptoBuilder();
            this._cmcBldr = new CoinMarketCapBuilder();
            this._trxBldr = trxBuilder;
        }

        // GET: api/cryptobits
        [HttpGet]
        public IEnumerable<Coin> GetCoins()
        {
            return this._nnBldr.GetAllCoins();
        }

        // GET: api/cryptobits/cmc
        [HttpGet("cmc")]
        public IEnumerable<CMCCoin> GetCMCCoins()
        {
            return this._cmcBldr.GetCoins();
        }

        // GET: api/cryptobits/bitcoin
        [HttpGet("{name}", Name = "Get")]
        public CMCCoin GetCMCCoin(string name)
        {
            return this._cmcBldr.GetCoin(name);
        }

        // POST: api/cryptobits/transaction
        [HttpPost("transaction")]
        public void Post([FromBody]Business.Contracts.CryptoBits.Transaction transaction)
        {
            this._trxBldr.AddTransaction(transaction);
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
