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
    public class CryptoValueRepository : ICryptoValueRepository
    {
        private readonly CryptoPortfolioContext _context = null;

        public CryptoValueRepository(IOptions<MongoDbSettings> settings)
        {
            _context = new CryptoPortfolioContext(settings);
        }

        public async Task<IEnumerable<CryptoValue>> GetCryptoValues()
        {
            try
            {
                return await _context.CryptoValues.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CryptoValue>> GetCryptoValue(string symbol)
        {
            var filter = Builders<CryptoValue>.Filter.Eq("symbol", symbol);

            try
            {
                return await _context.CryptoValues.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddCryptoValue(CryptoValue cryptoValue)
        {
            try
            {
                await _context.CryptoValues.InsertOneAsync(cryptoValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddCryptoValues(IEnumerable<CryptoValue> cryptoValues)
        {
            try
            {
                await _context.CryptoValues.InsertManyAsync(cryptoValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateCryptoValue(CryptoValue cryptoValue)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.CryptoValues
                                    .ReplaceOneAsync(n => n.Id.Equals(cryptoValue.Id)
                                            , cryptoValue
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteCryptoValue(CryptoValue cryptoValue)
        {
            try
            {
                DeleteResult actionResult = await _context.ApiInformation.DeleteOneAsync(nameof => nameof.Id.Equals(cryptoValue.Id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
