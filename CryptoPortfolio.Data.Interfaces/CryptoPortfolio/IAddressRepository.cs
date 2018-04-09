using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address_OG>> GetAddresses();

        Task<IEnumerable<Address_OG>> GetAddresses(string symbol);

        Task AddAddress(Address_OG address);

        Task<bool> UpdateAddress(Address_OG address);

        Task<bool> DeleteAddress(Address_OG address);
    }
}
