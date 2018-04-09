using CryptoPortfolio.Business.Entities.Crypto;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Core
{
    public interface IMongoRepository<T, TKey> where T : IEntity<TKey>
    {
        //IMongoCollection<T> Collection();

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task Add(T entity);

        Task AddMany(IEnumerable<T> entities);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
