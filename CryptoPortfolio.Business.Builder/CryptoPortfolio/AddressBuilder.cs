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
        private List<Contracts.CryptoBits.Address> _addressContractList;

        public AddressBuilder(IOptions<MongoDbSettings> settings)
        {
            _repo = new AddressRepository(settings);
            _objectHelper = new ObjectHelper();
            _addressContractList = new List<Contracts.CryptoBits.Address>();
        }

        public void SetAddressList()
        {
            var entityList = _repo.GetAddresses().Result;

            _addressContractList = GetContractList(entityList.ToList());
        }

        public IEnumerable<Contracts.CryptoBits.Address> GetAddressList()
        {
            if (_addressContractList.Count == 0)
            {
                SetAddressList();
            }
            return _addressContractList;
        }

        public IEnumerable<Contracts.CryptoBits.Address> GetAddress(string symbol)
        {
            return _addressContractList.Where(a => a.symbol.Equals(symbol));
        }

        public bool AddAddress(Contracts.CryptoBits.Address newAddress)
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

        public bool UpdateAddress(Contracts.CryptoBits.Address address)
        {
            var entity = GetEntity(address);
            return _repo.UpdateAddress(entity).Result;
        }

        public bool DeleteAddress(Contracts.CryptoBits.Address address)
        {
            var entity = GetEntity(address);
            return _repo.DeleteAddress(entity).Result;
        }

        private Entities.Crypto.Address GetEntity(Contracts.CryptoBits.Address apiInfo)
        {
            return _objectHelper.CreateEntity<Contracts.CryptoBits.Address, Entities.Crypto.Address>(apiInfo);
        }

        private List<Entities.Crypto.Address> GetEntityList(List<Contracts.CryptoBits.Address> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Contracts.CryptoBits.Address>, List<Entities.Crypto.Address>>(apiInfo);
        }

        private Contracts.CryptoBits.Address GetContract(Entities.Crypto.Address apiInfo)
        {
            return _objectHelper.CreateEntity<Entities.Crypto.Address, Contracts.CryptoBits.Address>(apiInfo);
        }

        private List<Contracts.CryptoBits.Address> GetContractList(List<Entities.Crypto.Address> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Entities.Crypto.Address>, List<Contracts.CryptoBits.Address>>(apiInfo);
        }
    }
}
