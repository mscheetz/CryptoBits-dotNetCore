using System;

namespace CryptoPortfolio.Business.Contracts.CryptoBits
{
    public class ApiInformation
    {
        public string Id { get; set; }
        public string apiSource { get; set; }
        public string apiKey { get; set; }
        public string apiSecret { get; set; }
        public string extraValue { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}
