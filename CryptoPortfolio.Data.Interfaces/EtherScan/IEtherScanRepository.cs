using CryptoPortfolio.Business.Entities.EtherScan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.EtherScan
{
    public interface IEtherScanRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions(string address);
    }
}
