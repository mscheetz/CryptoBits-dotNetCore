using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();

        Task<IEnumerable<Address>> GetAddresses(string symbol);

        Task AddAddress(Address address);

        Task<bool> UpdateAddress(Address address);

        Task<bool> DeleteAddress(Address address);
    }
}
