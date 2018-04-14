using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions();

        Task<IEnumerable<Transaction>> GetTransactionsBySymbol(string symbol);

        Task<IEnumerable<Transaction>> GetTransactionsByLocation(string location);

        Task<IEnumerable<Transaction>> GetTransactionsBySymbolAndLocation(string symbol, string location);

        Task<IEnumerable<Transaction>> GetTransactionsByDate(long time);

        Task<IEnumerable<Transaction>> GetTransactionsByDateRange(long from, long to);

        Task<Transaction> GetTransaction(string id);

        Task AddTransaction(Transaction transaction);

        Task AddTransactions(IEnumerable<Transaction> transactions);

        Task<bool> UpdateTransaction(Transaction transaction);
    }
}
