using CryptoPortfolio.Business.Builder.Interfaces.Sources;
using CryptoPortfolio.Business.Contracts.Sources;
using CryptoPortfolio.Business.Core;
using CryptoPortfolio.Business.Entities.NinetyNineCrypto;
using CryptoPortfolio.Data.Interfaces.NinetyNineCrypto;
using CryptoPortfolio.Data.NinetyNineCrypto;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace CryptoPortfolio.Business.Builder.Sources
{
    [Export(typeof(INinetyNineCryptoBuilder))]
    public class NinetyNineCryptoBuilder : BuilderEngineCore, INinetyNineCryptoBuilder
    {
        private INinetyNineCryptoRepository _repo;

        public NinetyNineCryptoBuilder()
        {
            _repo = new NinetyNineCryptoRepository();
        }

        public IEnumerable<Coin> GetAllCoins()
        {
            var coinEntityList = _repo.GetCoins().Result;

            return GetContract(coinEntityList);
        }

        private IEnumerable<Coin> GetContract(IEnumerable<NinetyNineCryptoCoin> entityList)
        {
            var contractList = new List<Coin>();

            foreach(var entity in entityList)
            {
                var contract = new Coin()
                {
                    name = entity.name,
                    symbol = entity.symbol
                };

                contractList.Add(contract);
            }

            return contractList;
        }
    }
}
