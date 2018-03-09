using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Helper
{
    public class DateTimeHelper
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly long epochTicks = new DateTime(1970, 1, 1, 0, 0, 0).Ticks;

        public DateTimeHelper()
        {
        }

        public DateTime UnixTimeToUTC(long unixTime)
        {
            var result = epoch.AddSeconds(unixTime);

            return result;
        }

        public DateTime UnixTimeToLocal(long unixTime)
        {
            var result = epoch.AddSeconds(unixTime);

            return result.ToLocalTime();
        }

        public long UTCtoUnixTime(DateTime utcTimestamp)
        {
            return ((utcTimestamp.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
        }
    }
}
