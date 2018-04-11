using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Contracts.CryptoBits;
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
    public class TransactionBuilder : ITransactionBuilder
    {
        private ITransactionRepository _repo;
        private ObjectHelper _objectHelper;
        private DateTimeHelper _dtHelper;
        private List<Contracts.CryptoBits.Transaction> _transactionContractList;

        public TransactionBuilder(ITransactionRepository repository)
        {
            _repo = repository;
            _objectHelper = new ObjectHelper();
            _dtHelper = new DateTimeHelper();
            _transactionContractList = new List<Contracts.CryptoBits.Transaction>();
        }

        public IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionsByDate(DateTime from)
        {
            long fromNonce = _dtHelper.UTCtoUnixTime(from.ToUniversalTime());

            return GetTransactionsByDT(fromNonce, 0);
        }

        public IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionsByDate(DateTime from, DateTime to)
        {
            long fromNonce = _dtHelper.UTCtoUnixTime(from.ToUniversalTime());
            long toNonce = to == null ? 0 : _dtHelper.UTCtoUnixTime(to.ToUniversalTime());

            return GetTransactionsByDT(fromNonce, toNonce);
        }

        public IEnumerable<Contracts.CryptoBits.Transaction> GetTransactions()
        {
            var entityList = _repo.GetTransactions().Result.ToList();

            return GetContractList(entityList);
        }

        public IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionBySymbol(string symbol)
        {
            var entityList = _repo.GetTransactionsBySymbol(symbol).Result.ToList();

            return GetContractList(entityList);
        }

        public IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionByLocation(string location)
        {
            var entityList = _repo.GetTransactionsByLocation(location).Result.ToList();

            return GetContractList(entityList);
        }

        public IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionsBySymbolAndLocation(string symbol, string location)
        {
            var entityList = _repo.GetTransactionsBySymbolAndLocation(symbol, location).Result.ToList();

            return GetContractList(entityList);
        }

        public bool AddNewTransaction(NewTransaction newTransaction)
        {
            var entity = NewTransactionToEntity(newTransaction);

            return AddTransactionToDB(entity);
        }

        public bool AddTransaction(Contracts.CryptoBits.Transaction newTransaction)
        {
            var entity = GetEntity(newTransaction);

            return AddTransactionToDB(entity);
        }

        private bool AddTransactionToDB(Entities.Crypto.Transaction entity)
        {
            var result = _repo.AddTransaction(entity);

            if (result.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddTransactions(List<Contracts.CryptoBits.Transaction> transactions)
        {
            var entityList = GetEntityList(transactions);
            foreach(var entity in entityList)
            {
                _repo.AddTransaction(entity);
            }

            return true;
        }
        
        public bool UpdateTransaction(Contracts.CryptoBits.Transaction transaction)
        {
            var entity = GetEntity(transaction);
            return _repo.UpdateTransaction(entity).Result;
        }

        public bool UpdateTransactions(List<Contracts.CryptoBits.Transaction> transactions)
        {
            var entityList = GetEntityList(transactions);
            foreach(var entity in entityList)
            {
                _repo.UpdateTransaction(entity);
            }

            return true;
        }

        private IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionsByDT(long from, long to)
        {
            var entityList = new List<Entities.Crypto.Transaction>();

            if (to == 0)
            {
                entityList = _repo.GetTransactionsByDate(from).Result.ToList();
            }
            else
            {
                entityList = _repo.GetTransactionsByDateRange(from, to).Result.ToList();
            }

            return GetContractList(entityList);
        }

        private Entities.Crypto.Transaction NewTransactionToEntity(NewTransaction newTransaction)
        {
            var entity = new Entities.Crypto.Transaction()
            {
                exchange = newTransaction.source,
                executedQty = newTransaction.quantity.ToString(),
                price = newTransaction.price.ToString(),
                status = "Complete",
                symbol = newTransaction.symbol + newTransaction.pair,
                time = _dtHelper.LocalToUnixTime(newTransaction.date),
                type = newTransaction.type
            };

            return entity;
        }

        private Entities.Crypto.Transaction GetEntity(Contracts.CryptoBits.Transaction apiInfo)
        {
            return _objectHelper.CreateEntity<Contracts.CryptoBits.Transaction, Entities.Crypto.Transaction>(apiInfo);
        }

        private List<Entities.Crypto.Transaction> GetEntityList(List<Contracts.CryptoBits.Transaction> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Contracts.CryptoBits.Transaction>, List<Entities.Crypto.Transaction>>(apiInfo);
        }

        private Contracts.CryptoBits.Transaction GetContract(Entities.Crypto.Transaction apiInfo)
        {
            return _objectHelper.CreateEntity<Entities.Crypto.Transaction, Contracts.CryptoBits.Transaction>(apiInfo);
        }

        private List<Contracts.CryptoBits.Transaction> GetContractList(List<Entities.Crypto.Transaction> apiInfo)
        {
            return _objectHelper.CreateEntity<List<Entities.Crypto.Transaction>, List<Contracts.CryptoBits.Transaction>>(apiInfo);
        }
    }
}
