using CryptoPortfolio.Business.Entities.CoinMarketCap;
using CryptoPortfolio.Data.Interfaces;
using CryptoPortfolio.Data.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using CryptoPortfolio.Data.Interfaces.CoinMarketCap;

namespace CryptoPortfolio.Data.Tests
{
    public class CoinMarketCapRepositoryTests
    {
        public CoinMarketCapRepositoryTests()
        {
        }

        [Fact]
        public void GetCoinsTest()
        {
            ICoinMarketCapRepository repo = new CoinMarketCapRepository();

            var coins = repo.GetCoins();
            coins.Wait();

            Assert.NotNull(coins.Result);
            Assert.True(coins.Result.Count() > 0);
        }

        [Fact]
        public void GetCoinTest()
        {
            ICoinMarketCapRepository repo = new CoinMarketCapRepository();

            var coinName = "neo";

            var neoCoin = repo.GetCoin(coinName);
            neoCoin.Wait();

            Assert.NotNull(neoCoin.Result);
            Assert.True(neoCoin.Result.id == coinName);
        }
    }
}
