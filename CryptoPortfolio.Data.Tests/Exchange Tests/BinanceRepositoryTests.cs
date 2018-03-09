using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CryptoPortfolio.Data.Tests
{
    public class BinanceRepositoryTests
    {
        private ApiInformation _exchangeApi;

        public BinanceRepositoryTests()
        {
            _exchangeApi = new ApiInformation()
            {
                apiKey = "",
                apiSecret = "",
                apiSource = "Binance",
                lastUpdate = DateTime.UtcNow
            };
        }

        [Fact]
        public void GetAccountTest()
        {
            IBinanceRepository repo = new BinanceRepository();
            repo.SetExchangeApi(_exchangeApi);

            var account = repo.GetBalance();

            Assert.NotNull(account.Result);
        }

        [Fact]
        public void GetBinanceTimeTest()
        {
            IBinanceRepository repo = new BinanceRepository();
            repo.SetExchangeApi(_exchangeApi);

            var binanceTime = repo.GetBinanceTime();

            Assert.True(binanceTime > 0);
        }
    }
}
