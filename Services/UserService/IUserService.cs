
using Reformation.Classes;
using Reformation.Models;

namespace Reformation.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel?> GetUser(int id);
        Task<List<UserModel>> GetUsers();
        Task AddUser(ISignUp user);
        // Task DeleteUser(int id);
        // Task UpdateUser(UserModel user);
    }
}

