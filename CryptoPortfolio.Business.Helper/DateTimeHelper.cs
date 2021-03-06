﻿using System;
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

        /// <summary>
        /// Convert unix timestamp to UTC DateTime
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns>DateTime object</returns>
        public DateTime UnixTimeToUTC(long unixTime)
        {
            var result = epoch.AddSeconds(unixTime);

            return result;
        }

        /// <summary>
        /// Convert string of unix timestamp to UTC DateTime
        /// </summary>
        /// <param name="unixTime">string of Unix Timestamp</param>
        /// <returns>DateTime object</returns>
        public DateTime? UnixTimeToUTC(string unixTime)
        {
            if (string.IsNullOrEmpty(unixTime))
                return null;

            long unixTimeInt = Int64.Parse(unixTime);

            var result = UnixTimeToUTC(unixTimeInt);

            return result;
        }

        /// <summary>
        /// Convert unix timestamp to Local DateTime
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns>DateTime object</returns>
        public DateTime UnixTimeToLocal(long unixTime)
        {
            var result = epoch.AddSeconds(unixTime);

            return result.ToLocalTime();
        }

        /// <summary>
        /// Convert Local DateTime to unix timestamp
        /// </summary>
        /// <param name="localTime">Local DateTime object</param>
        /// <returns>unix timestamp</returns>
        public long LocalToUnixTime(DateTime localTime)
        {
            var utcTime = localTime.ToUniversalTime();

            return UTCtoUnixTime(utcTime);
        }

        /// <summary>
        /// Convert current UTC DateTime to unix timestamp
        /// </summary>
        /// <returns>unix timestamp</returns>
        public long UTCtoUnixTime()
        {
            return UTCtoUnixTime(DateTime.UtcNow);
        }

        /// <summary>
        /// Convert UTC DateTime to unix timestamp
        /// </summary>
        /// <param name="localTime">UTC DateTime object</param>
        /// <returns>unix timestamp</returns>
        public long UTCtoUnixTime(DateTime utcTimestamp)
        {
            return ((utcTimestamp.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
        }

        /// <summary>
        /// Get seconds from a timestamp to now
        /// </summary>
        /// <param name="timeStart">DateTime to compare</param>
        /// <returns>Double of seconds</returns>
        public double CompareSeconds(DateTime timeStart)
        {
            var timeNow = DateTime.UtcNow;

            return (timeStart - timeNow).TotalSeconds;
        }
    }
}
