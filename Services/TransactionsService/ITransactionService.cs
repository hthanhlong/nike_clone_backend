using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services;
public interface ITransactionsService
{
    Task<TransactionModel> GetTransaction(int id);
    Task<IEnumerable<TransactionModel>> GetTransactions();
    Task<TransactionModel> AddTransaction(TransactionModel transaction);
    Task<TransactionModel> UpdateTransaction(TransactionModel transaction);
    Task<TransactionModel> DeleteTransaction(int id);
}

