using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Database;
using Reformation.Dtos;
using Reformation.Models;
using Reformation.Services;

namespace Reformation.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUser(int id);
        Task<List<UserModel>> GetUsers();
        Task<UserModel?> GetUserByEmail(string email);
        Task AddUser(CreateUserDto user);
        // Task DeleteUser(int id);
        // Task UpdateUser(UserModel user);
    }
}