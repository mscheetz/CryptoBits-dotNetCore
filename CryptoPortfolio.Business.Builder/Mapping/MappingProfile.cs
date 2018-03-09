using AutoMapper;
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
                .ForMember(e => e.available_supply, map => map.MapFrom(c => c.available_supply))
                .ForMember(e => e.id, map => map.MapFrom(c => c.id))
                .ForMember(e => e.last_updated, map => map.MapFrom(c => c.last_updated))
                .ForMember(e => e.market_cap_usd, map => map.MapFrom(c => c.market_cap_usd))
                .ForMember(e => e.max_supply, map => map.MapFrom(c => c.max_supply))
                .ForMember(e => e.name, map => map.MapFrom(c => c.name))
                .ForMember(e => e.percent_change_1h, map => map.MapFrom(c => c.percent_change_1h))
                .ForMember(e => e.percent_change_24h, map => map.MapFrom(c => c.percent_change_24h))
                .ForMember(e => e.percent_change_7d, map => map.MapFrom(c => c.percent_change_7d))
                .ForMember(e => e.price_btc, map => map.MapFrom(c => c.price_btc))
                .ForMember(e => e.price_usd, map => map.MapFrom(c => c.price_usd))
                .ForMember(e => e.rank, map => map.MapFrom(c => c.rank))
                .ForMember(e => e.symbol, map => map.MapFrom(c => c.symbol))
                .ForMember(e => e.total_supply, map => map.MapFrom(c => c.total_supply));

        }
    }
}
