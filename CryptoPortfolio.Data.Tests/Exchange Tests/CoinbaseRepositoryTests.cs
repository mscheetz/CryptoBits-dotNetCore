using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CryptoPortfolio.Data.Tests
{
    public class CoinbaseRepositoryTests
    {
        private ApiInformation _apiInfo;

        public CoinbaseRepositoryTests()
        {
            _apiInfo = new ApiInformation()
            {
                apiKey = "",
                apiSecret = "",
                apiSource = "Coinbase",
                lastUpdate = DateTime.UtcNow
            };
        }

        [Fact]
        public void GetAccountTest()
        {
            ICoinbaseRepository repo = new CoinbaseRepository();
            repo.SetExchangeApi(_apiInfo);

            var response = repo.GetBalance();
            response.Wait();

            var account = response.Result;

            Assert.NotNull(account);
        }

        [Fact]
        public void GetCoinbaseTimeTest()
        {
            ICoinbaseRepository repo = new CoinbaseRepository();

            var response = repo.GetCBTime();
            response.Wait();

            var coinbaseTime = response.Result;

            Assert.True(coinbaseTime > 0);
        }
    }
}
