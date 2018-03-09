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

namespace CryptoPortfolio.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/cryptobits")]
    public class CryptoBitsController : Controller
    {
        private INinetyNineCryptoBuilder _nnBldr;
        private ICoinMarketCapBuilder _cmcBldr;

        public CryptoBitsController()
        {
            this._nnBldr = new NinetyNineCryptoBuilder();
            this._cmcBldr = new CoinMarketCapBuilder();
        }

        // GET: api/CryptoBits
        [HttpGet]
        public IEnumerable<Coin> GetCoins()
        {
            return this._nnBldr.GetAllCoins();
        }

        // GET: api/CryptoBits/bitcoin
        [HttpGet("{name}", Name = "Get")]
        public CMCCoin Get(string name)
        {
            return this._cmcBldr.GetCoin(name);
        }
        
        // POST: api/CryptoBits
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/CryptoBits/5
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
