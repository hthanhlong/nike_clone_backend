using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Database;
using Reformation.Models;
using Reformation.Services;

namespace Reformation.Repositories
{
    public interface IUserRepository
    {
        // Task<UserModel> GetUser(int id);
        Task<List<UserModel>> GetUsers();
        Task AddUser(UserModel user);
        // Task DeleteUser(int id);
        // Task UpdateUser(UserModel user);
    }
}