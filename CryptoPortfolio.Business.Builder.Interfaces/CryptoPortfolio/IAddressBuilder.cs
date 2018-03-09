using CryptoPortfolio.Business.Contracts.CryptoBits;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface IAddressBuilder
    {
        void SetAddressList();

        IEnumerable<Address> GetAddressList();

        IEnumerable<Address> GetAddress(string symbol);

        bool AddAddress(Address newAddress);

        bool UpdateAddress(Address address);

        bool DeleteAddress(Address address);
    }
}
