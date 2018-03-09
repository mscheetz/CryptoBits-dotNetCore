using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPortfolio.Business.Helper
{
    public class ObjectHelper
    {
        public ObjectHelper()
        {
        }
        
        public E CreateEntity<C, E>(C contract)
        {
            return Mapper.Map<C, E>(contract);
        }

        public C CreateContract<E, C>(E entity)
        {
            return Mapper.Map<E, C>(entity);
        }

    }
}
