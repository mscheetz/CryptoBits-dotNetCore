using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface IAddressBuilder
    {
        void SetAddressList();

        IEnumerable<AddressOG> GetAddressList();

        IEnumerable<AddressOG> GetAddress(string symbol);

        bool AddAddress(AddressOG newAddress);

        bool UpdateAddress(AddressOG address);

        bool DeleteAddress(AddressOG address);
    }
}
