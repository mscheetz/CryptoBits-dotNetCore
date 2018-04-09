using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CryptoPortfolio.Business.Entities.Crypto;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CryptoPortfolio.Data.Core
{
    public class Repository<TEntity> //: IRepository<TEntity> where TEntity : class
    {
        //private readonly MongoDbContext _context;
        //private IMongoCollection<TEntity> _collection;

        //public Repository(MongoDbContext context)
        //{
        //    _context = context;
        //    _collection = GetCollection();
        //}

        //public async Task Add(TEntity entity)
        //{
        //    await _collection.InsertOneAsync(entity);
        //}

        //public async Task AddRange(IEnumerable<TEntity> entities)
        //{
        //    await _collection.InsertManyAsync(entities);
        //}

        //public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await _collection.Find(predicate).ToListAsync();
        //}
        
        //public async Task<IEnumerable<TEntity>> GetAll()
        //{
        //    return await _collection.Find(_ => true).ToListAsync();
        //}

        //public async Task Remove(TEntity entity)
        //{
        //    await _collection.DeleteOneAsync(entity);
        //}

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<UpdateResult> Update(TEntity entity)
        //{
        //    await _collection.ReplaceOneAsync(entity);
        //}

        //private IMongoCollection<TEntity> GetCollection()
        //{
        //    var collectionName = typeof(TEntity).Name.ToLower();

        //    collectionName = collectionName.Substring(-1).Equals("s") ? collectionName : collectionName + "s";

        //    return _context.GetDatabase().GetCollection<TEntity>(collectionName);
        //}
    }
}
