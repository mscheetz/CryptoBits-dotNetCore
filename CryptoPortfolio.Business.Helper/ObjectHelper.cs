using AutoMapper;
using System;
using System.Collections.Generic;
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
