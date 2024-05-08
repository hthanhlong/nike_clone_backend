

using Nike_clone_Backend.Models;
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel?> GetUser(int id);
        Task<List<UserModel>> GetUsers();
        Task AddUser(SignUpDto user);
        // Task DeleteUser(int id);
        // Task UpdateUser(UserModel user);
    }
}

