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
        private Contracts.CryptoBits.NewTransaction newTransaction;
        private List<CoinInformation> coinInfoList;

        public CoinInformationBuilder()
        {
        }

        /// <summary>
        /// Get coin information
        /// </summary>
        /// <returns>Collection of CoinInformation</returns>
        public IEnumerable<CoinInformation> GetCoinInformation()
        {
            return coinInfoList;
        }
        
        /// <summary>
        /// Process a new transaction from the UI
        /// </summary>
        /// <param name="transaction">NewTransaction object to process</param>
        /// <returns>boolean when complete</returns>
        public bool NewTransaction(Contracts.CryptoBits.NewTransaction transaction)
        {
            this.newTransaction = transaction;

            //TODO: push to transaction log

            var newCoin = GetCoin(transaction);

            var myCoin = this.coinInfoList.Where(c => c.symbol.Equals(newCoin.symbol)).FirstOrDefault();

            if(myCoin != null)
            {
                this.coinInfoList.Add(newCoin);
            }
            else
            {
                foreach(var coin in this.coinInfoList)
                {
                    if (coin.symbol.Equals(newCoin.symbol))
                    {
                        coin.walletList = newCoin.walletList;
                        break;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Get a Coin from a transaction
        /// </summary>
        /// <param name="transaction">New Transaction object</param>
        /// <returns>CoinInformation object</returns>
        private CoinInformation GetCoin(Contracts.CryptoBits.NewTransaction transaction)
        {
            CoinInformation thisCoin = this.coinInfoList.Where(c => c.symbol == transaction.symbol).FirstOrDefault();
            
            if(thisCoin == null)
            {
                thisCoin = this.CreateCoin(transaction);
            }
            else
            {
                Wallet wallet = GetWallet(transaction, thisCoin);
                if(wallet == null && transaction.transactionType == TransactionType.BUY)
                {
                    var buyList = CreateCoinBuyList(transaction);
                    var newWallet = this.CreateCoinWallet(transaction, buyList);
                }
                else if (transaction.transactionType == TransactionType.BUY)
                {
                    var coinBuy = CreateCoinBuy(transaction);

                    wallet.coinBuyList.Add(coinBuy);
                }
                else if (transaction.transactionType == TransactionType.SELL)
                {
                    var buyList = wallet.coinBuyList;

                    wallet.coinBuyList = SellCoins(buyList, transaction);
                }
            }

            return thisCoin;
        }

        /// <summary>
        /// Get a wallet from a transaction
        /// </summary>
        /// <param name="transaction">NewTransaction object</param>
        /// <param name="thisCoin">CoinInformation object</param>
        /// <returns>Wallet object</returns>
        private static Wallet GetWallet(NewTransaction transaction, CoinInformation thisCoin)
        {
            Wallet thisWallet = null;
            if (transaction.sourceLocation == Location.Address)
            {
                thisWallet = thisCoin.walletList.Where(w => w.location == transaction.sourceLocation
                                            && w.address.addressId == transaction.sourceAddress.addressId).FirstOrDefault();
            }
            else
            {
                thisWallet = thisCoin.walletList.Where(w => w.location == transaction.sourceLocation).FirstOrDefault();
            }

            return thisWallet;
        }

        /// <summary>
        /// Create a coin from a transaction
        /// </summary>
        /// <param name="transaction">NewTransaction object</param>
        /// <returns>CoinInformation object</returns>
        private CoinInformation CreateCoin(NewTransaction transaction)
        {
            var newCoin = new CoinInformation();
            var buys = this.CreateCoinBuyList(transaction);
            var walletList = new List<Wallet>();
            walletList.Add(this.CreateCoinWallet(transaction, buys));

            newCoin.name = transaction.name;
            newCoin.symbol = transaction.symbol;
            newCoin.walletList = walletList;

            return newCoin;
        }

        /// <summary>
        /// Create CoinBuy collection from a transaction
        /// </summary>
        /// <param name="transaction">NewTransaction object</param>
        /// <returns>Collection of CoinBuy</returns>
        private List<CoinBuy> CreateCoinBuyList(NewTransaction transaction)
        {
            var buyList = new List<CoinBuy>();

            buyList.Add(CreateCoinBuy(transaction));

            return buyList;
        }
        /// <summary>
        /// Create a CoinBuy object from a transaction
        /// </summary>
        /// <param name="transaction">NewTransaction object</param>
        /// <returns>CoinBuy object</returns>
        private CoinBuy CreateCoinBuy(NewTransaction transaction)
        {
            var coinBuy = new CoinBuy
            {
                available = transaction.quantity,
                buyDate = transaction.date,
                coinSellList = new List<CoinSell>(),
                fee = transaction.fee,
                feeSymbol = transaction.feeSymbol,
                pair = transaction.pair,
                price = transaction.price,
                quantity = transaction.quantity,
                transactionType = transaction.transactionType
            };

            return coinBuy;
        }

        /// <summary>
        /// Create a wallet from a transaction
        /// </summary>
        /// <param name="transaction">NewTransaction object</param>
        /// <param name="buyList">Collection of CoinBuy</param>
        /// <returns>Wallet object</returns>
        private Wallet CreateCoinWallet(NewTransaction transaction, List<CoinBuy> buyList)
        {
            var wallet = new Wallet()
            {
                address = transaction.sourceAddress,
                coinBuyList = buyList,
                location = transaction.sourceLocation,
            };

            return wallet;
        }

        /// <summary>
        /// Sell coins from a CoinBuy Collection
        /// </summary>
        /// <param name="buyList">Collection of CoinBuy</param>
        /// <param name="transaction">NewTransaction object</param>
        /// <returns>Collection of CoinBuy</returns>
        private List<CoinBuy> SellCoins(List<CoinBuy> coinBuyList, NewTransaction transaction)
        {
            var sellQty = transaction.quantity;

            foreach(var coinBuy in coinBuyList)
            {
                var available = coinBuy.available;
                CoinSell coinSell = null;
                if(sellQty >= available)
                {
                    coinBuy.available = 0;
                    sellQty = sellQty - available;
                    coinSell = CreateCoinSell(transaction, available);
                }
                else if(available > sellQty)
                {
                    coinBuy.available = (available - sellQty);
                    coinSell = CreateCoinSell(transaction, sellQty);
                    sellQty = 0;
                }
                coinBuy.coinSellList.Add(coinSell);
            }

            return coinBuyList;
        }

        /// <summary>
        /// Create a CoinSell from a transaction
        /// </summary>
        /// <param name="transaction">NewTransaction object</param>
        /// <param name="sellQuantity">double of quantity to sell</param>
        /// <returns>CoinSell object</returns>
        private CoinSell CreateCoinSell(NewTransaction transaction, double sellQuantity)
        {
            var coinSell = new CoinSell
            {
                fee = transaction.fee,
                feeSymbol = transaction.feeSymbol,
                pair = transaction.pair,
                price = transaction.price,
                quantity = sellQuantity,
                transactionType = transaction.transactionType,
                saleDate = transaction.date,
                processed = true,
                qtySold = sellQuantity
            };

            return coinSell;
        }
    }
}
