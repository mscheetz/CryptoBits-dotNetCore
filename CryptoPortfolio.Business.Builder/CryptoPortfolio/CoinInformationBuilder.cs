using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Contracts.CryptoBits;
using CryptoPortfolio.Business.Helper;
using CryptoPortfolio.Data;
using CryptoPortfolio.Data.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace CryptoPortfolio.Business.Builder.CryptoPortfolio
{
    public class CoinInformationBuilder : ICoinInformationBuilder
    {
        private ICoinInfoRepository _repo;
        private ObjectHelper _objectHelper;
        private List<Contracts.CryptoBits.CoinInfo> _coinInfoList;
        private Contracts.CryptoBits.Transaction newTransaction;
        private List<CoinInformation> coinInfoList;

        public CoinInformationBuilder()
        {
        }

        public CoinInformationBuilder(Contracts.CryptoBits.Transaction transaction)
        {
            this.newTransaction = transaction;
        }

        public IEnumerable<CoinInformation> GetCoinInformation()
        {
            return coinInfoList;
        }

        public bool NewTransaction(Contracts.CryptoBits.Transaction transaction)
        {
            return true;
        }

        public CoinInformation GetCoin(Transaction transaction)
        {
            var newCoin = this.coinInfoList.Where(c => c.symbol == transaction.symbol).FirstOrDefault();
            
            return newCoin;
        }
        
        public CoinInformation CreateCoin(Transaction transaction)
        {
            var newCoin = new CoinInformation();
            var buys = this.CreateCoinBuys(transaction);
            var walletList = new List<Wallet>();
            walletList.Add(this.CreateCoinWallet(transaction, buys));

            newCoin.name = transaction.name;
            newCoin.symbol = transaction.symbol;
            newCoin.walletList = walletList;

            return newCoin;
        }

        public List<CoinBuy> CreateCoinBuys(Transaction transaction)
        {
            var buyList = new List<CoinBuy>();

            return buyList;
        }

        public Wallet CreateCoinWallet(Transaction transaction, List<CoinBuy> buyList)
        {
            var wallet = new Wallet();

            return wallet;
        }
    }
}
