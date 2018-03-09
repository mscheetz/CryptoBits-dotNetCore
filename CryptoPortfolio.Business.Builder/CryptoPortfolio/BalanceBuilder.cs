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
    public class BalanceBuilder : IBalanceBuilder
    {
        private IBalanceRepository _repo;
        private ObjectHelper _objectHelper;
        private List<Contracts.CryptoBits.Balance> _balanceContractList;

        public BalanceBuilder(IOptions<MongoDbSettings> settings)
        {
            _repo = new BalanceRepository(settings);
            _objectHelper = new ObjectHelper();
            _balanceContractList = new List<Contracts.CryptoBits.Balance>();
        }

        public void SetBalanceList()
        {
            var entityList = _repo.GetBalances().Result;

            _balanceContractList = GetContractList(entityList.ToList());
        }

        public IEnumerable<Contracts.CryptoBits.Balance> GetBalanceList()
        {
            if (_balanceContractList.Count == 0)
            {
                SetBalanceList();
            }
            return _balanceContractList;
        }

        public IEnumerable<Contracts.CryptoBits.Balance> GetBalance(string symbol)
        {
            return _balanceContractList.Where(a => a.symbol.Equals(symbol));
        }

        public IEnumerable<Contracts.CryptoBits.Balance> GetBalance(string symbol, string location)
        {
            return _balanceContractList.Where(a => a.symbol.Equals(symbol) && a.location.Equals(location));
        }

        public bool AddBalance(Contracts.CryptoBits.Balance newBalance)
        {
            var entity = GetEntity(newBalance);
            var result = _repo.AddBalance(entity);

            if (result.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateBalance(Contracts.CryptoBits.Balance balance)
        {
            var entity = GetEntity(balance);
            return _repo.UpdateBalance(entity).Result;
        }

        public bool UpdateBalances(List<Contracts.CryptoBits.Balance> balances)
        {
            var entityList = GetEntityList(balances);
            foreach(var entity in entityList)
            {
                _repo.UpdateBalance(entity);
            }

            return true;
        }

        public bool DeleteBalance(Contracts.CryptoBits.Balance balance)
        {
            var entity = GetEntity(balance);
            return _repo.DeleteBalance(entity).Result;
        }

        private Entities.Crypto.Balance GetEntity(Contracts.CryptoBits.Balance apiInfo)
        {
            return _objectHelper.CreateEntity<Contracts.CryptoBits.Balance, Entities.Crypto.Balance>(apiInfo);
        }

        private List<Entities.Crypto.Balance> GetEntityList(List<Contracts.CryptoBits.Balance> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Contracts.CryptoBits.Balance>, List<Entities.Crypto.Balance>>(apiInfo);
        }

        private Contracts.CryptoBits.Balance GetContract(Entities.Crypto.Balance apiInfo)
        {
            return _objectHelper.CreateEntity<Entities.Crypto.Balance, Contracts.CryptoBits.Balance>(apiInfo);
        }

        private List<Contracts.CryptoBits.Balance> GetContractList(List<Entities.Crypto.Balance> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Entities.Crypto.Balance>, List<Contracts.CryptoBits.Balance>>(apiInfo);
        }
    }
}
