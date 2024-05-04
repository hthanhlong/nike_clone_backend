
using Nike_clone_Backend.Classes;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.UserService
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

