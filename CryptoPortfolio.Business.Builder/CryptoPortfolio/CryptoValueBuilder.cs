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
    public class CryptoValueBuilder : ICryptoValueBuilder
    {
        private ICryptoValueRepository _repo;
        private ObjectHelper _objectHelper;
        private List<Contracts.CryptoBits.CryptoValue> _cryptoValueList;

        public CryptoValueBuilder(IOptions<MongoDbSettings> settings)
        {
            _repo = new CryptoValueRepository(settings);
            _objectHelper = new ObjectHelper();
            this.SetCryptoValue();
        }

        public bool SetCryptoValue()
        {
            var coinEntityList = _repo.GetCryptoValues().Result.ToList();
            
            _cryptoValueList = GetContractList(coinEntityList);
            
            return true;
        }
        
        public IEnumerable<Contracts.CryptoBits.CryptoValue> GetCryptoValueList()
        {
            if( _cryptoValueList.Count == 0)
            {
                SetCryptoValue();
            }
            return _cryptoValueList;
        }

        public Contracts.CryptoBits.CryptoValue GetCryptoValue(string symbol)
        {
            return _cryptoValueList.Where(a => a.symbol.Equals(symbol)).FirstOrDefault();
        }
        
        public bool AddCryptoValue(Contracts.CryptoBits.CryptoValue cryptoValue)
        {
            var entity = GetEntity(cryptoValue);
            var result = _repo.AddCryptoValue(entity);

            if(result.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCryptoValue(List<Contracts.CryptoBits.CryptoValue> cryptoValueList)
        {
            var entityList = GetEntityList(cryptoValueList);

            foreach(var entity in entityList)
            {
                _repo.UpdateCryptoValue(entity);
            }

            return true;
        }

        public bool UpdateCryptoValue(Contracts.CryptoBits.CryptoValue cryptoValue)
        {
            var entity = GetEntity(cryptoValue);
            return _repo.UpdateCryptoValue(entity).Result;
        }

        public bool DeleteCryptoValue(Contracts.CryptoBits.CryptoValue cryptoValue)
        {
            var entity = GetEntity(cryptoValue);
            return _repo.DeleteCryptoValue(entity).Result;
        }

        private Entities.Crypto.CryptoValue GetEntity(Contracts.CryptoBits.CryptoValue cryptoValue)
        {
            return _objectHelper.CreateEntity<Contracts.CryptoBits.CryptoValue, Entities.Crypto.CryptoValue>(cryptoValue);
        }

        private List<Entities.Crypto.CryptoValue> GetEntityList(List<Contracts.CryptoBits.CryptoValue> cryptoValue)
        {
            return _objectHelper.CreateEntity<List<Contracts.CryptoBits.CryptoValue>, List<Entities.Crypto.CryptoValue>>(cryptoValue);
        }

        private Contracts.CryptoBits.CryptoValue GetContract(Entities.Crypto.CryptoValue cryptoValue)
        {
            return _objectHelper.CreateEntity<Entities.Crypto.CryptoValue, Contracts.CryptoBits.CryptoValue>(cryptoValue);
        }

        private List<Contracts.CryptoBits.CryptoValue> GetContractList(List<Entities.Crypto.CryptoValue> cryptoValue)
        {
            return _objectHelper.CreateEntity<List<Entities.Crypto.CryptoValue>, List<Contracts.CryptoBits.CryptoValue>>(cryptoValue);
        }
    }
}
