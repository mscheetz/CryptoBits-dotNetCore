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
        }
    }
}
