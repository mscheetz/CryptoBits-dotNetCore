using CryptoPortfolio.Business.Entities;
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
    public class ApiInformationRepository : IApiInformationRepository
    {
        private readonly CryptoPortfolioContext _context = null;

        public ApiInformationRepository(IOptions<MongoDbSettings> settings)
        {
            _context = new CryptoPortfolioContext(settings);
        }
        
        public async Task<IEnumerable<ApiInformation>> GetApiInfo()
        {
            try
            {
                return await _context.ApiInformation.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ApiInformation>> GetApiInfo(string apiSource)
        {
            var filter = Builders<ApiInformation>.Filter.Eq("apiSource", apiSource);

            try
            {
                return await _context.ApiInformation.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddApiInfo(ApiInformation api)
        {
            try
            {
                await _context.ApiInformation.InsertOneAsync(api);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateApiInfo(ApiInformation api)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.ApiInformation
                                    .ReplaceOneAsync(n => n.Id.Equals(api.Id)
                                            , api
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteApiInfoById(string Id)
        {
            try
            {
                DeleteResult actionResult = await _context.ApiInformation.DeleteOneAsync(nameof => nameof.Id.Equals(Id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteApiInfo(ApiInformation api)
        {
            try
            {
                DeleteResult actionResult = await _context.ApiInformation.DeleteOneAsync(nameof => nameof.Id.Equals(api.Id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
