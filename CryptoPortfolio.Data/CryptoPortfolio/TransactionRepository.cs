using CryptoPortfolio.Business.Entities.Crypto;
using CryptoPortfolio.Data.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CryptoPortfolioContext _context = null;

        public TransactionRepository(IOptions<MongoDbSettings> settings)
        {
            _context = new CryptoPortfolioContext(settings);
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            try
            {
                return await _context.Transactions.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsBySymbol(string symbol)
        {
            var filter = Builders<Transaction>.Filter.Eq("symbol", symbol);

            try
            {
                return await _context.Transactions.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByLocation(string location)
        {
            var filter = Builders<Transaction>.Filter.Eq("exchange", location);

            try
            {
                return await _context.Transactions.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsBySymbolAndLocation(string symbol, string location)
        {
            var filter = Builders<Transaction>.Filter.Eq("symbol", symbol);
            filter = filter & Builders<Transaction>.Filter.Eq("exchange", location);

            try
            {
                return await _context.Transactions.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDate(long time)
        {
            var filter = Builders<Transaction>.Filter.Eq("time", time);

            try
            {
                return await _context.Transactions.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDateRange(long from, long to)
        {
            var filter = Builders<Transaction>.Filter.Gte("time", from);
            filter = filter & Builders<Transaction>.Filter.Lte("time", to);

            try
            {
                return await _context.Transactions.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Transaction> GetTransaction(string id)
        {
            var filter = Builders<Transaction>.Filter.Eq("id", id);

            try
            {
                return await _context.Transactions.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddTransaction(Transaction transaction)
        {
            try
            {
                await _context.Transactions.InsertOneAsync(transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddTransactions(IEnumerable<Transaction> transactions)
        {
            try
            {
                await _context.Transactions.InsertManyAsync(transactions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateTransaction(Transaction transaction)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Transactions
                                    .ReplaceOneAsync(n => n.Id.Equals(transaction.Id)
                                            , transaction
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
