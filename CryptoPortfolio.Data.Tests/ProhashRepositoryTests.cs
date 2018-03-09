using CryptoPortfolio.Business.Entities.Prohashing;
using CryptoPortfolio.Data.Interfaces;
using CryptoPortfolio.Data.Prohashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CryptoPortfolio.Data.Tests
{
    public class ProhashRepositoryTests
    {
        private List<CoinGetter> coinList;

        public ProhashRepositoryTests()
        {
            coinList = new List<CoinGetter>()
            {
                new CoinGetter("D5BX1k9w3PsrptmKbfqz9DL6W1gnYC4LFR",146),
                //new CoinGetter("t1KkVdeLVgYcvCyV1EkkeLiNyAt93uMCNta",399),
                //new CoinGetter("MAZKrGaaCS29YYMEhzBEDDdm1ySnxqU3cM",145)
            };
        }

        [Fact]
        public void GetCryptosTest()
        {
            IProhashingRepository repo = new ProhashingRepository();

            var cryptos = repo.GetCryptos();
            cryptos.Wait();

            Assert.NotNull(cryptos.Result);
            Assert.True(cryptos.Result.Count() > 0);
        }

        [Fact]
        public void GetAddressDetailTest()
        {
            IProhashingRepository repo = new ProhashingRepository();

            var address = repo.GetAddressDetail(coinList[0]);
            address.Wait();

            Assert.NotNull(address.Result);
            Assert.True(address.Result.address == coinList[0].address);
        }

        [Fact]
        public void GetAddressTrxTest()
        {
            IProhashingRepository repo = new ProhashingRepository();

            var transactions = repo.GetAddressTransactions(coinList[0]);
            transactions.Wait();

            Assert.NotNull(transactions.Result);
            var count = transactions.Result.Count();
            Assert.True(count > 0);
        }
    }
}
