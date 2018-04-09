using CryptoPortfolio.Business.Entities.Crypto;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Core
{
    public class MongoRepository<T, TKey> : IMongoRepository<T, TKey> where T : IEntity<TKey>
    {
        private MongoDbContext _context;
        private IMongoCollection<T> _collection;

        public MongoRepository(MongoDbContext context)
        {
            _context = context;
            GetCollection();
        }
        
        public IMongoCollection<T> Collection()
        {
            return this._collection;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task AddMany(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public async Task Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(t => t.Id, entity.Id);

            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(t => t.Id, entity.Id);

            await _collection.DeleteOneAsync(filter);
        }

        private void GetCollection()
        {
            var name = typeof(T).Name.ToLower();

            //_collection = _context.GetDatabase().GetCollection<T>(name);
        }

        //private readonly CryptoPortfolioContext _context = null;

        //public MongoRepository(IOptions<MongoDbSettings> settings)
        //{
        //    _context = new CryptoPortfolioContext(settings);
        //}

        //public CryptoPortfolioContext GetContext()
        //{
        //    return this._context;
        //}


    }
}
