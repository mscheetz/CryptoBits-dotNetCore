using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Crypto;
using MongoDB.Driver;
using System;

namespace CryptoPortfolio.Data
{
    public class MongoDbContext
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }

        private IMongoDatabase _database { get; }

        public MongoDbContext(MongoDbSettings dbSettings)
        {
            ConnectionString = dbSettings.connectionString;
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }

        public IMongoCollection<Balance> Balances
        {
            get
            {
                return _database.GetCollection<Balance>("Balances");
            }
        }

        public IMongoCollection<ApiInformation> ExchangeApis
        {
            get
            {
                return _database.GetCollection<ApiInformation>("ExchangeApis");
            }
        }

        public IMongoCollection<CryptoValue> CryptoValues
        {
            get
            {
                return _database.GetCollection<CryptoValue>("CryptoValues");
            }
        }

        public IMongoCollection<Transaction> Transactions
        {
            get
            {
                return _database.GetCollection<Transaction>("Transactions");
            }
        }
    }
}
