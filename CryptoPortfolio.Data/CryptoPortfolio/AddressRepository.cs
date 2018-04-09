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
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptoPortfolioContext _context = null;        

        public AddressRepository(IOptions<MongoDbSettings> settings)
        {
            _context = new CryptoPortfolioContext(settings);
        }

        public async Task<IEnumerable<Address_OG>> GetAddresses()
        {
            try
            {
                return await _context.Addresses.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Address_OG>> GetAddresses(string symbol)
        {
            var filter = Builders<Address_OG>.Filter.Eq("symbol", symbol);

            try
            {
                return await _context.Addresses.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAddress(Address_OG address)
        {
            try
            {
                await _context.Addresses.InsertOneAsync(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAddress(Address_OG address)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Addresses
                                    .ReplaceOneAsync(n => n.Id.Equals(address.Id)
                                            , address
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAddress(Address_OG address)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Addresses
                                    .DeleteOneAsync(n => n.Id.Equals(address.Id));
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
