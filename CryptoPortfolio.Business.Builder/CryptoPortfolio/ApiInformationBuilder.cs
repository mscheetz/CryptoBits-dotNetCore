using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Entities.Crypto;
using CryptoPortfolio.Business.Helper;
using CryptoPortfolio.Data;
using CryptoPortfolio.Data.Interfaces;
using Microsoft.Extensions.Options;
using System;
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
            var apiEntityList = GetApiInformationFromDB();
            
            _apiInfoList = GetContractList(apiEntityList.ToList());
            
            foreach(var api in _apiInfoList)
            {
                api.apiSecret = "****secret****";
                api.extraValue = "****secret****";
            }

            return true;
        }
        
        private IEnumerable<Entities.ApiInformation> GetApiInformationFromDB()
        {
            var apiEntityList = _repo.GetApiInfo().Result.ToList();

            return apiEntityList;
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
            if (_apiInfoList.Count == 0)
            {
                SetApiInformation();
            }
            return _apiInfoList.Where(a => a.apiSource.ToLower().Equals(apiName.ToLower())).FirstOrDefault();
        }

        public Entities.ApiInformation GetApiInformationEntity(string apiName)
        {
            var entityList = GetApiInformationFromDB();

            return entityList.Where(a => a.apiSource.ToLower().Equals(apiName.ToLower())).FirstOrDefault();
        }

        public bool AddApiInformation(Contracts.CryptoBits.ApiInformation api)
        {
            api.lastUpdate = DateTime.UtcNow;

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
            api.lastUpdate = DateTime.UtcNow;

            var entity = GetEntity(api);
            return _repo.UpdateApiInfo(entity).Result;
        }

        public bool DeleteApiInformation(string apiId)
        {
            return _repo.DeleteApiInfoById(apiId).Result;
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
