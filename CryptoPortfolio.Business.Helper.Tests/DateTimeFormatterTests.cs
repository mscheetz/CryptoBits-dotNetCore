using System;
using Xunit;

namespace CryptoPortfolio.Business.Helper.Tests
{
    public class DateTimeFormatterTests
    {
        [Fact]
        public void UnixToUTCTest()
        {
            DateTimeHelper dth = new DateTimeHelper();
            var unixTime = 1516378151;

            var result = dth.UnixTimeToUTC(unixTime);
            
            Assert.False(result < new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        }

        [Fact]
        public void UnixToLocalTest()
        {
            DateTimeHelper dth = new DateTimeHelper();
            var unixTime = 1516378151;

            var result = dth.UnixTimeToLocal(unixTime);

            Assert.False(result < new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local));
        }

        [Fact]
        public void UtcToUnixTest()
        {
            DateTimeHelper dth = new DateTimeHelper();
            var utcTime = DateTime.UtcNow;

            var result = dth.UTCtoUnixTime(utcTime);

            Assert.True(result > 0);
        }
    }
}
