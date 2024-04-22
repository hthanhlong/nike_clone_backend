using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Dtos;
using Reformation.Models;

namespace Reformation.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel?> GetUser(int id);
        Task<List<UserModel>> GetUsers();
        Task AddUser(CreateUserDto user);
        // Task DeleteUser(int id);
        // Task UpdateUser(UserModel user);
    }
}

