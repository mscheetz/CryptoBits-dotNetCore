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
    public class BalanceRepository : IBalanceRepository
    {
        private readonly CryptoPortfolioContext _context = null;        

        public BalanceRepository(IOptions<MongoDbSettings> settings)
        {
            _context = new CryptoPortfolioContext(settings);
        }

        public async Task<IEnumerable<Balance>> GetBalances()
        {
            try
            {
                return await _context.Balances.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Balance>> GetBalance(string symbol)
        {
            var filter = Builders<Balance>.Filter.Eq("symbol", symbol);

            try
            {
                return await _context.Balances.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddBalance(Balance balance)
        {
            try
            {
                await _context.Balances.InsertOneAsync(balance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateBalance(Balance balance)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Balances
                                    .ReplaceOneAsync(n => n.Id.Equals(balance.Id)
                                            , balance
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteBalance(Balance balance)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Addresses
                                    .DeleteOneAsync(n => n.Id.Equals(balance.Id));
                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
