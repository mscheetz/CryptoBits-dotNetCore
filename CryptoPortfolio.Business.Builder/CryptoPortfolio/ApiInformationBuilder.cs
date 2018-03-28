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
    public class ApiInformationBuilder : IApiInformationBuilder
    {
        private IApiInformationRepository _repo;
        private ObjectHelper _objectHelper;
        private List<Contracts.CryptoBits.ApiInformation> _apiInfoList;

        public ApiInformationBuilder(IApiInformationRepository apiInformationRepository)
        {
            _repo = apiInformationRepository;
            _objectHelper = new ObjectHelper();
            this.SetApiInformation();
        }

        public bool SetApiInformation()
        {
            var apiEntityList = _repo.GetApiInfo().Result.ToList();
            
            _apiInfoList = GetContractList(apiEntityList);
            
            return true;
        }
        
        public IEnumerable<Contracts.CryptoBits.ApiInformation> GetApiInformation()
        {
            if( _apiInfoList.Count == 0)
            {
                SetApiInformation();
            }
            return _apiInfoList;
        }

        public Contracts.CryptoBits.ApiInformation GetApiInformation(string apiName)
        {
            return _apiInfoList.Where(a => a.apiSource.Equals(apiName)).FirstOrDefault();
        }
        
        public bool AddApiInformation(Contracts.CryptoBits.ApiInformation api)
        {
            var entity = GetEntity(api);
            var result = _repo.AddApiInfo(entity);

            if(result.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateApiInformation(Contracts.CryptoBits.ApiInformation api)
        {
            var entity = GetEntity(api);
            return _repo.UpdateApiInfo(entity).Result;
        }

        public bool DeleteApiInformation(Contracts.CryptoBits.ApiInformation api)
        {
            var entity = GetEntity(api);
            return _repo.DeleteApiInfo(entity).Result;
        }

        private Entities.ApiInformation GetEntity(Contracts.CryptoBits.ApiInformation apiInfo)
        {
            return _objectHelper.CreateEntity<Contracts.CryptoBits.ApiInformation, Entities.ApiInformation>(apiInfo);
        }

        private List<Entities.ApiInformation> GetEntityList(List<Contracts.CryptoBits.ApiInformation> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Contracts.CryptoBits.ApiInformation>, List<Entities.ApiInformation>>(apiInfo);
        }

        private Contracts.CryptoBits.ApiInformation GetContract(Entities.ApiInformation apiInfo)
        {
            return _objectHelper.CreateEntity<Entities.ApiInformation, Contracts.CryptoBits.ApiInformation>(apiInfo);
        }

        private List<Contracts.CryptoBits.ApiInformation> GetContractList(List<Entities.ApiInformation> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Entities.ApiInformation>, List<Contracts.CryptoBits.ApiInformation>>(apiInfo);
        }
    }
}
