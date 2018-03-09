using CryptoPortfolio.Business.Builder.Interfaces;
using CryptoPortfolio.Data;
using CryptoPortfolio.Data.Interfaces;
using System;

namespace CryptoPortfolio.Business.Builder
{
    public class BinanceBuilder : IBinanceBuilder
    {
        private IBinanceRepository _repo;

        public BinanceBuilder()
        {
            _repo = new BinanceRepository();
        }

        public bool GetAccount()
        {
            var account = _repo.GetBalance();

            return account.Result != null ? true : false;
        }
    }
}
