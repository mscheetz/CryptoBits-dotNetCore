using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Entities.Crypto;
using CryptoPortfolio.Business.Helper;
using CryptoPortfolio.Data;
using CryptoPortfolio.Data.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace CryptoPortfolio.Business.Builder.CryptoPortfolio
{
    public class CoinInfoBuilder : ICoinInfoBuilder
    {
        private ICoinInfoRepository _repo;
        private ObjectHelper _objectHelper;
        private List<Contracts.CryptoBits.CoinInfo> _coinInfoList;

        public CoinInfoBuilder(IOptions<MongoDbSettings> settings)
        {
            _repo = new CoinInfoRepository(settings);
            _objectHelper = new ObjectHelper();
            this.SetCoinInfo();
        }

        public bool SetCoinInfo()
        {
            var coinEntityList = _repo.GetCoinInfo().Result.ToList();
            
            _coinInfoList = GetContractList(coinEntityList);
            
            return true;
        }
        
        public IEnumerable<Contracts.CryptoBits.CoinInfo> GetCoinInfoList()
        {
            if( _coinInfoList.Count == 0)
            {
                SetCoinInfo();
            }
            return _coinInfoList;
        }

        public Contracts.CryptoBits.CoinInfo GetCoinInformation(string symbol)
        {
            return _coinInfoList.Where(a => a.symbol.Equals(symbol)).FirstOrDefault();
        }
        
        public bool AddCoinInfo(Contracts.CryptoBits.CoinInfo coinInfo)
        {
            var entity = GetEntity(coinInfo);
            var result = _repo.AddCoinInfo(entity);

            if(result.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCoinInfo(List<Contracts.CryptoBits.CoinInfo> coinInfoList)
        {
            var entityList = GetEntityList(coinInfoList);

            foreach(var entity in entityList)
            {
                _repo.UpdateCoinInfo(entity);
            }

            return true;
        }

        public bool UpdateCoinInfo(Contracts.CryptoBits.CoinInfo coinInfo)
        {
            var entity = GetEntity(coinInfo);
            return _repo.UpdateCoinInfo(entity).Result;
        }

        public bool DeleteCoinInfo(Contracts.CryptoBits.CoinInfo coinInfo)
        {
            var entity = GetEntity(coinInfo);
            return _repo.DeleteCoinInfo(entity).Result;
        }

        private Entities.Crypto.CoinInfo GetEntity(Contracts.CryptoBits.CoinInfo coinInfo)
        {
            return _objectHelper.CreateEntity<Contracts.CryptoBits.CoinInfo, Entities.Crypto.CoinInfo>(coinInfo);
        }

        private List<Entities.Crypto.CoinInfo> GetEntityList(List<Contracts.CryptoBits.CoinInfo> coinInfo)
        {
            return _objectHelper.CreateEntity<List<Contracts.CryptoBits.CoinInfo>, List<Entities.Crypto.CoinInfo>>(coinInfo);
        }

        private Contracts.CryptoBits.CoinInfo GetContract(Entities.Crypto.CoinInfo coinInfo)
        {
            return _objectHelper.CreateEntity<Entities.Crypto.CoinInfo, Contracts.CryptoBits.CoinInfo>(coinInfo);
        }

        private List<Contracts.CryptoBits.CoinInfo> GetContractList(List<Entities.Crypto.CoinInfo> coinInfo)
        {
            return _objectHelper.CreateEntity<List<Entities.Crypto.CoinInfo>, List<Contracts.CryptoBits.CoinInfo>>(coinInfo);
        }
    }
}
