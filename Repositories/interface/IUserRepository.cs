using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserByEmail(string email);
    }
}

