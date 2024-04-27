using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.TransactionRepository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionModel>> GetTransactions();
        Task<TransactionModel> GetTransaction(int id);
        Task<TransactionModel> AddTransaction(TransactionModel transaction);
        Task<TransactionModel> UpdateTransaction(TransactionModel transaction);
        Task<TransactionModel> DeleteTransaction(int id);
    }
}