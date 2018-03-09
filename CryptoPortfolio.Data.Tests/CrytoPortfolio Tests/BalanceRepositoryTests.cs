using CryptoPortfolio.Business.Entities.Crypto;
using CryptoPortfolio.Data.Interfaces;
using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using CryptoPortfolio.Data.Interfaces.CoinMarketCap;
using Microsoft.Extensions.Options;

namespace CryptoPortfolio.Data.Tests
{
    public class BalanceRepositoryTests
    {
        private MongoDbSettings _mongoSettings;
        private IOptions<MongoDbSettings> _options;

        public BalanceRepositoryTests()
        {
            _mongoSettings = new MongoDbSettings()
            {
                connectionString = "",
                database = ""
            };
            _options = Options.Create(_mongoSettings);
        }

        [Fact]
        public void GetBalanceTest()
        {
            IBalanceRepository repo = new BalanceRepository(_options);

            var symbol = "btc";
            var response = repo.GetBalance(symbol);
            response.Wait();

            var balance = response.Result;

            Assert.NotNull(balance);
            Assert.True(balance.Count() > 0);
        }
    }
}
