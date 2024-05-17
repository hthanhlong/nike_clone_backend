using nike_clone_backend.Models.DTOs;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services;
public interface IUserService
{
    Task<UserModel?> GetUser(int id);
    Task<List<UserModel>> GetUsers();
    Task DeleteUser(int id);
    Task UpdateUser(int id, UpdateUserDto updateUserDto);
}

