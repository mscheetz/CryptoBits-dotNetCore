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
    public class CMCCoinRepository : ICMCCoinRepository
    {
        private readonly CryptoPortfolioContext _context = null;
        private IMongoCollection<CMCCoin> collection;

        public CMCCoinRepository(IOptions<MongoDbSettings> settings)
        {
            _context = new CryptoPortfolioContext(settings);
            collection = _context.CMCCoin;
        }
        
        public async Task<IEnumerable<CMCCoin>> GetCMCCoins()
        {
            try
            {
                return await _context.CMCCoin.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertCMCCoins(IEnumerable<CMCCoin> coinList)
        {
            try
            {
                await collection.InsertManyAsync(coinList);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAllRecords()
        {
            try
            {
                DeleteResult actionResult = await collection.DeleteManyAsync(_ => true);

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
