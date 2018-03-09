using CryptoPortfolio.Business.Entities;
using CryptoPortfolio.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CryptoPortfolio.Data.Tests
{
    public class KuCoinRepositoryTests
    {
        private ApiInformation _exchangeApi;

        public KuCoinRepositoryTests()
        {
            _exchangeApi = new ApiInformation()
            {
                apiKey = "",
                apiSecret = "",
                apiSource = "KuCoin",
                lastUpdate = DateTime.UtcNow
            };
        }

        [Fact]
        public void GetAccountTest()
        {
            IKuCoinRepository repo = new KuCoinRepository();
            repo.SetExchangeApi(_exchangeApi);

            var account = repo.GetBalance();

            Assert.NotNull(account.Result);
        }

        [Fact]
        public void GetBinanceTimeTest()
        {
            IKuCoinRepository repo = new KuCoinRepository();
            repo.SetExchangeApi(_exchangeApi);

            var kucoinTime = repo.GetKuCoinTime();

            Assert.True(kucoinTime > 0);
        }
    }
}
