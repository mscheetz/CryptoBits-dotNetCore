using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Business.Entities.Crypto;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CryptoPortfolio.Data
{
    public class CryptoPortfolioContext
    {
        private readonly IMongoDatabase _database = null;

        public CryptoPortfolioContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.connectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.database);
        }

        public IMongoCollection<Address> Addresses
        {
            get
            {
                return _database.GetCollection<Address>("Address");
            }
        }

        public IMongoCollection<AddressTransaction> AddressTransactions
        {
            get
            {
                return _database.GetCollection<AddressTransaction>("AddressTransaction");
            }
        }

        public IMongoCollection<ApiInformation> ApiInformation
        {
            get
            {
                return _database.GetCollection<ApiInformation>("ApiInformation");
            }
        }

        public IMongoCollection<Balance> Balances
        {
            get
            {
                return _database.GetCollection<Balance>("Balance");
            }
        }

        public IMongoCollection<CoinInfo> CoinInfo
        {
            get
            {
                return _database.GetCollection<CoinInfo>("CoinInfo");
            }
        }

        public IMongoCollection<CryptoValue> CryptoValues
        {
            get
            {
                return _database.GetCollection<CryptoValue>("CryptoValue");
            }
        }

        public IMongoCollection<Transaction> Transactions
        {
            get
            {
                return _database.GetCollection<Transaction>("Transaction");
            }
        }
    }
}
