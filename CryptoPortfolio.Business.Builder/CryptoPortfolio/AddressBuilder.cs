using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Entities.Crypto;
using CryptoPortfolio.Business.Helper;
using CryptoPortfolio.Data;
using CryptoPortfolio.Data.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoPortfolio.Business.Builder.CryptoPortfolio
{
    public class AddressBuilder : IAddressBuilder
    {
        private IAddressRepository _repo;
        private ObjectHelper _objectHelper;
        private List<Contracts.CryptoBits.AddressOG> _addressContractList;

        public AddressBuilder(IOptions<MongoDbSettings> settings)
        {
            _repo = new AddressRepository(settings);
            _objectHelper = new ObjectHelper();
            _addressContractList = new List<Contracts.CryptoBits.AddressOG>();
        }

        public void SetAddressList()
        {
            var entityList = _repo.GetAddresses().Result;

            _addressContractList = GetContractList(entityList.ToList());
        }

        public IEnumerable<Contracts.CryptoBits.AddressOG> GetAddressList()
        {
            if (_addressContractList.Count == 0)
            {
                SetAddressList();
            }
            return _addressContractList;
        }

        public IEnumerable<Contracts.CryptoBits.AddressOG> GetAddress(string symbol)
        {
            return _addressContractList.Where(a => a.symbol.Equals(symbol));
        }

        public bool AddAddress(Contracts.CryptoBits.AddressOG newAddress)
        {
            var entity = GetEntity(newAddress);
            var result = _repo.AddAddress(entity);

            if (result.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAddress(Contracts.CryptoBits.AddressOG address)
        {
            var entity = GetEntity(address);
            return _repo.UpdateAddress(entity).Result;
        }

        public bool DeleteAddress(Contracts.CryptoBits.AddressOG address)
        {
            var entity = GetEntity(address);
            return _repo.DeleteAddress(entity).Result;
        }

        private Entities.Crypto.Address_OG GetEntity(Contracts.CryptoBits.AddressOG apiInfo)
        {
            return _objectHelper.CreateEntity<Contracts.CryptoBits.AddressOG, Entities.Crypto.Address_OG>(apiInfo);
        }

        private List<Entities.Crypto.Address_OG> GetEntityList(List<Contracts.CryptoBits.AddressOG> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Contracts.CryptoBits.AddressOG>, List<Entities.Crypto.Address_OG>>(apiInfo);
        }

        private Contracts.CryptoBits.AddressOG GetContract(Entities.Crypto.Address_OG apiInfo)
        {
            return _objectHelper.CreateEntity<Entities.Crypto.Address_OG, Contracts.CryptoBits.AddressOG>(apiInfo);
        }

        private List<Contracts.CryptoBits.AddressOG> GetContractList(List<Entities.Crypto.Address_OG> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Entities.Crypto.Address_OG>, List<Contracts.CryptoBits.AddressOG>>(apiInfo);
        }
    }
}
