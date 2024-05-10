

using nike_clone_backend.Models.DTOs;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel?> GetUser(int id);
        Task<List<UserModel>> GetUsers();
        Task DeleteUser(int id);
        Task UpdateUser(int id, UpdateUserDto updateUserDto);
    }
}

