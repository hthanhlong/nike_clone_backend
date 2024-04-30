using Reformation.Models;

namespace Reformation.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserByEmail(string email);
    }
}

