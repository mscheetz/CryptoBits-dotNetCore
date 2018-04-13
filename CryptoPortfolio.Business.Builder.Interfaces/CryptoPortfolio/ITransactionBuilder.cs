using CryptoPortfolio.Business.Contracts.CryptoBits;
using CryptoPortfolio.Business.Entities.Crypto;
using System;
using System.Collections.Generic;

namespace CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio
{
    public interface ITransactionBuilder
    {
        IEnumerable<Contracts.CryptoBits.Transaction> GetTransactions();

        IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionBySymbol(string symbol);

        IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionByLocation(string location);

        IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionsBySymbolAndLocation(string symbol, string location);

        IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionsByDate(DateTime from);

        IEnumerable<Contracts.CryptoBits.Transaction> GetTransactionsByDate(DateTime from, DateTime to);

        bool AddNewTransaction(NewTransaction newTransaction);

        bool AddTransaction(Contracts.CryptoBits.Transaction newTransaction);

        bool AddTransactions(IEnumerable<Entities.Crypto.Transaction> entities);

        bool AddTransactions(IEnumerable<Contracts.CryptoBits.Transaction> transactions);
        
        bool UpdateTransaction(Contracts.CryptoBits.Transaction transaction);

        bool UpdateTransactions(List<Contracts.CryptoBits.Transaction> transactions);
    }
}
