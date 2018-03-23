using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Contracts.CryptoBits;
using CryptoPortfolio.Business.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Builder.CryptoPortfolio
{
    public class DisplayCoinBuilder : IDisplayCoinBuilder
    {
        private List<DisplayCoin> _displayCoinList;
        private ICoinInformationBuilder _coinInfoBuilder;
        private ObjectHelper _helper;
        private double zeroSats;

        public DisplayCoinBuilder()
        {
            this._displayCoinList = new List<DisplayCoin>();
            this._coinInfoBuilder = new CoinInformationBuilder();
            this._helper = new ObjectHelper();
            zeroSats = _helper.ZeroSats();
        }

        /// <summary>
        /// Get display coins
        /// </summary>
        /// <returns>Collection of display coins</returns>
        public List<DisplayCoin> GetDisplayCoins()
        {
            if (this._displayCoinList.Count == 0)
                UpdateDisplayCoins();

            return this._displayCoinList;
        }

        /// <summary>
        /// Update display coins
        /// </summary>
        /// <returns>bool when complete</returns>
        public bool UpdateDisplayCoins()
        {
            var coinInfoList = this._coinInfoBuilder.GetCoinInformation();
            this._displayCoinList = new List<DisplayCoin>();

            foreach(var coin in coinInfoList)
            {
                var displayCoin = new DisplayCoin
                {
                    symbol = coin.symbol,
                    name = coin.name,
                    ticker = coin.ticker,
                    locations = coin.walletList.Count
                };

                double quantity = zeroSats;
                double lowBuy = zeroSats;
                double highBuy = zeroSats;
                double avgBuy = zeroSats;
                double totalBuy = zeroSats;
                foreach(var wallet in coin.walletList)
                {
                    foreach(var coinBuy in wallet.coinBuyList)
                    {
                        if(coinBuy.available > 0)
                        {
                            double buyPrice = coinBuy.price;
                            double buyQty = coinBuy.available;
                            if(buyQty > 0)
                            {
                                if (lowBuy == zeroSats || lowBuy > buyPrice)
                                    lowBuy = buyPrice;

                                if (highBuy < buyPrice)
                                    highBuy = buyPrice;

                                totalBuy += (buyPrice * buyQty);
                                quantity += buyQty;
                            }
                        }
                    }
                }
                avgBuy = (totalBuy / quantity);
                displayCoin.quanity = quantity;
                displayCoin.low = lowBuy;
                displayCoin.high = highBuy;
                displayCoin.avg = avgBuy;

                _displayCoinList.Add(displayCoin);
            }

            return true;
        }

    }
}
