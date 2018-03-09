using System.Linq;
using Xunit;
using CryptoPortfolio.Data.NinetyNineCrypto;
using CryptoPortfolio.Data.Interfaces.NinetyNineCrypto;

namespace CryptoPortfolio.Data.Tests
{
    public class NinetyNineCryptoRepositoryTests
    {
        public NinetyNineCryptoRepositoryTests()
        {
        }

        [Fact]
        public void GetCoinsTest()
        {
            INinetyNineCryptoRepository repo = new NinetyNineCryptoRepository();

            var coins = repo.GetCoins();
            coins.Wait();

            Assert.NotNull(coins.Result);
            Assert.True(coins.Result.Count() > 0);
        }
    }
}
