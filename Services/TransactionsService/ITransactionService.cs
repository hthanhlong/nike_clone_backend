using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.TransactionsService
{
    public interface ITransactionsService
    {
        Task<TransactionModel> GetTransaction(int id);
        Task<IEnumerable<TransactionModel>> GetTransactions();
        Task<TransactionModel> AddTransaction(TransactionModel transaction);
        Task<TransactionModel> UpdateTransaction(TransactionModel transaction);
        Task<TransactionModel> DeleteTransaction(int id);
    }
}

