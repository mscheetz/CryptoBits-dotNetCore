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
    public class CoinInfoRepository : ICoinInfoRepository
    {
        private readonly CryptoPortfolioContext _context = null;        

        public CoinInfoRepository(IOptions<MongoDbSettings> settings)
        {
            _context = new CryptoPortfolioContext(settings);
        }

        public async Task<IEnumerable<CoinInfo>> GetCoinInfo()
        {
            try
            {
                return await _context.CoinInfo.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CoinInfo>> GetCoinInfo(string symbol)
        {
            var filter = Builders<CoinInfo>.Filter.Eq("symbol", symbol);

            try
            {
                return await _context.CoinInfo.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddCoinInfo(CoinInfo coinInfo)
        {
            try
            {
                await _context.CoinInfo.InsertOneAsync(coinInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateCoinInfo(CoinInfo coinInfo)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.CoinInfo
                                    .ReplaceOneAsync(n => n.Id.Equals(coinInfo.Id)
                                            , coinInfo
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteCoinInfo(CoinInfo coinInfo)
        {
            try
            {
                DeleteResult actionResult = await _context.ApiInformation.DeleteOneAsync(nameof => nameof.Id.Equals(coinInfo.Id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
