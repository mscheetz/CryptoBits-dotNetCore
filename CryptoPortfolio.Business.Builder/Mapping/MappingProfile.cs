using AutoMapper;
using CryptoPortfolio.Business.Contracts.CryptoBits;
using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Builder.Mapping
{
    public class MappingProfile : Profile, IProfile
    {
        public MappingProfile()
        {
            CreateMap<Entities.CoinMarketCap.Coin, CMCCoin>()
                .ForMember(c => c.available_supply, map => map.MapFrom(e => e.available_supply))
                .ForMember(c => c.id, map => map.MapFrom(e => e.id))
                .ForMember(c => c.last_updated, map => map.MapFrom(e => e.last_updated))
                .ForMember(c => c.market_cap_usd, map => map.MapFrom(e => e.market_cap_usd))
                .ForMember(c => c.max_supply, map => map.MapFrom(e => e.max_supply))
                .ForMember(c => c.name, map => map.MapFrom(e => e.name))
                .ForMember(c => c.percent_change_1h, map => map.MapFrom(e => e.percent_change_1h))
                .ForMember(c => c.percent_change_24h, map => map.MapFrom(e => e.percent_change_24h))
                .ForMember(c => c.percent_change_7d, map => map.MapFrom(e => e.percent_change_7d))
                .ForMember(c => c.price_btc, map => map.MapFrom(e => e.price_btc))
                .ForMember(c => c.price_usd, map => map.MapFrom(e => e.price_usd))
                .ForMember(c => c.rank, map => map.MapFrom(e => e.rank))
                .ForMember(c => c.symbol, map => map.MapFrom(e => e.symbol))
                .ForMember(c => c.total_supply, map => map.MapFrom(e => e.total_supply));

            CreateMap<Entities.Crypto.CMCCoin, CMCCoin>()
                .ForMember(c => c.available_supply, map => map.MapFrom(e => e.available_supply))
                .ForMember(c => c.id, map => map.MapFrom(e => e.id))
                .ForMember(c => c.last_updated, map => map.MapFrom(e => e.last_updated))
                .ForMember(c => c.market_cap_usd, map => map.MapFrom(e => e.market_cap_usd))
                .ForMember(c => c.max_supply, map => map.MapFrom(e => e.max_supply))
                .ForMember(c => c.name, map => map.MapFrom(e => e.name))
                .ForMember(c => c.percent_change_1h, map => map.MapFrom(e => e.percent_change_1h))
                .ForMember(c => c.percent_change_24h, map => map.MapFrom(e => e.percent_change_24h))
                .ForMember(c => c.percent_change_7d, map => map.MapFrom(e => e.percent_change_7d))
                .ForMember(c => c.price_btc, map => map.MapFrom(e => e.price_btc))
                .ForMember(c => c.price_usd, map => map.MapFrom(e => e.price_usd))
                .ForMember(c => c.rank, map => map.MapFrom(e => e.rank))
                .ForMember(c => c.symbol, map => map.MapFrom(e => e.symbol))
                .ForMember(c => c.total_supply, map => map.MapFrom(e => e.total_supply));

            CreateMap<Entities.CoinMarketCap.Coin, Entities.Crypto.CMCCoin>()
                .ForMember(c => c.available_supply, map => map.MapFrom(e => e.available_supply))
                .ForMember(c => c.id, map => map.MapFrom(e => e.id))
                .ForMember(c => c.last_updated, map => map.MapFrom(e => e.last_updated))
                .ForMember(c => c.market_cap_usd, map => map.MapFrom(e => e.market_cap_usd))
                .ForMember(c => c.max_supply, map => map.MapFrom(e => e.max_supply))
                .ForMember(c => c.name, map => map.MapFrom(e => e.name))
                .ForMember(c => c.percent_change_1h, map => map.MapFrom(e => e.percent_change_1h))
                .ForMember(c => c.percent_change_24h, map => map.MapFrom(e => e.percent_change_24h))
                .ForMember(c => c.percent_change_7d, map => map.MapFrom(e => e.percent_change_7d))
                .ForMember(c => c.price_btc, map => map.MapFrom(e => e.price_btc))
                .ForMember(c => c.price_usd, map => map.MapFrom(e => e.price_usd))
                .ForMember(c => c.rank, map => map.MapFrom(e => e.rank))
                .ForMember(c => c.symbol, map => map.MapFrom(e => e.symbol))
                .ForMember(c => c.total_supply, map => map.MapFrom(e => e.total_supply));

            CreateMap<Entities.Coindar.CalendarItem, Event>()
                .ForMember(c => c.caption, map => map.MapFrom(e => e.caption))
                .ForMember(c => c.coinName, map => map.MapFrom(e => e.coin_name))
                .ForMember(c => c.coinSymbol, map => map.MapFrom(e => e.coin_symbol))
                .ForMember(c => c.endDate, map => map.MapFrom(e => e.end_date))
                .ForMember(c => c.proof, map => map.MapFrom(e => e.proof))
                .ForMember(c => c.publicDate, map => map.MapFrom(e => e.public_date))
                .ForMember(c => c.startDate, map => map.MapFrom(e => e.start_date));

            CreateMap<Entities.ApiInformation, ApiInformation>()
                .ForMember(c => c.apiKey, map => map.MapFrom(e => e.apiKey))
                .ForMember(c => c.apiSecret, map => map.MapFrom(e => e.apiSecret))
                .ForMember(c => c.apiSource, map => map.MapFrom(e => e.apiSource))
                .ForMember(c => c.extraValue, map => map.MapFrom(e => e.extraValue))
                .ForMember(c => c.Id, map => map.MapFrom(e => e.Id))
                .ForMember(c => c.lastUpdate, map => map.MapFrom(e => e.lastUpdate));

            CreateMap<Entities.Crypto.CoinInfo, CoinInformation>()
                .ForMember(c => c.Id, map => map.MapFrom(e => e.Id))
                .ForMember(c => c.name, map => map.MapFrom(e => e.name))
                .ForMember(c => c.symbol, map => map.MapFrom(e => e.symbol))
                .ForMember(c => c.walletList, map => map.MapFrom(e => e.walletList));

            CreateMap<Entities.Crypto.Wallet, Wallet>()
                .ForMember(c => c.address, map => map.MapFrom(e => e.address))
                .ForMember(c => c.coinBuyList, map => map.MapFrom(e => e.coinBuyList))
                .ForMember(c => c.location, map => map.MapFrom(e => e.location));

            CreateMap<Entities.Crypto.CoinBuy, CoinBuy>()
                .ForMember(c => c.available, map => map.MapFrom(e => e.available))
                .ForMember(c => c.buyDate, map => map.MapFrom(e => e.buyDate))
                .ForMember(c => c.coinSellList, map => map.MapFrom(e => e.coinSellList))
                .ForMember(c => c.fee, map => map.MapFrom(e => e.fee))
                .ForMember(c => c.feeSymbol, map => map.MapFrom(e => e.feeSymbol))
                .ForMember(c => c.pair, map => map.MapFrom(e => e.pair))
                .ForMember(c => c.price, map => map.MapFrom(e => e.price))
                .ForMember(c => c.quantity, map => map.MapFrom(e => e.quantity))
                .ForMember(c => c.transactionType, map => map.MapFrom(e => e.transactionType));

            CreateMap<Entities.Crypto.CoinSell, CoinSell>()
                .ForMember(c => c.fee, map => map.MapFrom(e => e.fee))
                .ForMember(c => c.feeSymbol, map => map.MapFrom(e => e.feeSymbol))
                .ForMember(c => c.pair, map => map.MapFrom(e => e.pair))
                .ForMember(c => c.price, map => map.MapFrom(e => e.price))
                .ForMember(c => c.processed, map => map.MapFrom(e => e.processed))
                .ForMember(c => c.qtySold, map => map.MapFrom(e => e.qtySold))
                .ForMember(c => c.quantity, map => map.MapFrom(e => e.quantity))
                .ForMember(c => c.saleDate, map => map.MapFrom(e => e.saleDate))
                .ForMember(c => c.transactionType, map => map.MapFrom(e => e.transactionType));

            CreateMap<Entities.Crypto.Address, Address>()
                .ForMember(c => c.addressId, map => map.MapFrom(e => e.addressId))
                .ForMember(c => c.addressName, map => map.MapFrom(e => e.addressName));

            CreateMap<Entities.Crypto.Transaction, Transaction>()
                .ForMember(c => c.clientOrderId, map => map.MapFrom(e => e.clientOrderId))
                .ForMember(c => c.exchange, map => map.MapFrom(e => e.exchange))
                .ForMember(c => c.executedQty, map => map.MapFrom(e => e.executedQty))
                .ForMember(c => c.icebergQty, map => map.MapFrom(e => e.icebergQty))
                .ForMember(c => c.Id, map => map.MapFrom(e => e.Id))
                .ForMember(c => c.isWorking, map => map.MapFrom(e => e.isWorking))
                .ForMember(c => c.orderId, map => map.MapFrom(e => e.orderId))
                .ForMember(c => c.origQty, map => map.MapFrom(e => e.origQty))
                .ForMember(c => c.price, map => map.MapFrom(e => e.price))
                .ForMember(c => c.side, map => map.MapFrom(e => e.side))
                .ForMember(c => c.status, map => map.MapFrom(e => e.status))
                .ForMember(c => c.stopPrice, map => map.MapFrom(e => e.stopPrice))
                .ForMember(c => c.symbol, map => map.MapFrom(e => e.symbol))
                .ForMember(c => c.time, map => map.MapFrom(e => e.time))
                .ForMember(c => c.timeInForce, map => map.MapFrom(e => e.timeInForce))
                .ForMember(c => c.type, map => map.MapFrom(e => e.type));

            CreateMap<Entities.Crypto.Transaction, Entities.Binance.Transaction>()
                .ForMember(b => b.clientOrderId, map => map.MapFrom(e => e.clientOrderId))
                .ForMember(b => b.executedQty, map => map.MapFrom(e => e.executedQty))
                .ForMember(b => b.icebergQty, map => map.MapFrom(e => e.icebergQty))
                .ForMember(b => b.isWorking, map => map.MapFrom(e => e.isWorking))
                .ForMember(b => b.orderId, map => map.MapFrom(e => e.orderId))
                .ForMember(b => b.origQty, map => map.MapFrom(e => e.origQty))
                .ForMember(b => b.price, map => map.MapFrom(e => e.price))
                .ForMember(b => b.side, map => map.MapFrom(e => e.side))
                .ForMember(b => b.status, map => map.MapFrom(e => e.status))
                .ForMember(b => b.stopPrice, map => map.MapFrom(e => e.stopPrice))
                .ForMember(b => b.symbol, map => map.MapFrom(e => e.symbol))
                .ForMember(b => b.time, map => map.MapFrom(e => e.time))
                .ForMember(b => b.timeInForce, map => map.MapFrom(e => e.timeInForce))
                .ForMember(b => b.type, map => map.MapFrom(e => e.type));

            CreateMap<Entities.Binance.Transaction, NewTransaction>()
                .ForMember(n => n.date, map => map.MapFrom(t => t.time))
                .ForMember(n => n.quantity, map => map.MapFrom(t => t.origQty))
                .ForMember(n => n.type, map => map.MapFrom(t => t.type))
                .ForMember(n => n.trxId, map => map.MapFrom(t => t.orderId))
                .ForMember(n => n.symbol, map => map.MapFrom(t => t.symbol))
                .ForMember(n => n.pair, map => map.MapFrom(t => t.symbol))
                .ForMember(n => n.price, map => map.MapFrom(t => t.price));
        }
    }
}
