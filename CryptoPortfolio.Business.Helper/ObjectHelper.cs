using AutoMapper;
using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoPortfolio.Business.Helper
{
    public class ObjectHelper
    {
        private double zeroSats = 0.00000000;

        public ObjectHelper()
        {
        }
        
        /// <summary>
        /// Map a Contract to an Entity
        /// </summary>
        /// <typeparam name="C">Type of Contract</typeparam>
        /// <typeparam name="E">Type of Entity</typeparam>
        /// <param name="contract">Contract object</param>
        /// <returns>Entity object</returns>
        public E CreateEntity<C, E>(C contract)
        {
            return Mapper.Map<C, E>(contract);
        }

        /// <summary>
        /// Map an Entity to a Contract
        /// </summary>
        /// <typeparam name="E">Type of Entity</typeparam>
        /// <typeparam name="C">Type of Contract</typeparam>
        /// <param name="entity">Entity object</param>
        /// <returns>Contract object</returns>
        public C CreateContract<E, C>(E entity)
        {
            return Mapper.Map<E, C>(entity);
        }

        /// <summary>
        /// Get zero'd satoshi count
        /// </summary>
        /// <returns>boolean of zero sats</returns>
        public double ZeroSats()
        {
            return zeroSats;
        }

        /// <summary>
        /// Get a collection from an enum
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <returns>Collection of enum values</returns>
        public IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Get trading pair from a joined symbol
        /// </summary>
        /// <param name="symbol">Symbol to disect</param>
        /// <returns>new TradingPair object</returns>
        public TradingPair GetTradingPair(string symbol)
        {
            var thisSymbol = string.Empty;
            var thisPair = string.Empty;

            var pairEnum = GetEnumValues<Pairs>();

            foreach(var pEnum in pairEnum)
            {
                var pair = pEnum.ToString();
                int len = pair.Length * -1;

                if (symbol.Substring(len) == pair)
                {
                    thisPair = pair;
                    thisSymbol = symbol.Substring(0, symbol.Length + len);
                    break;
                }
            }

            return new TradingPair { pair = thisPair, symbol = thisSymbol };
        }
    }
}
