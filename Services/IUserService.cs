using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Services
{
    public interface IUserService
    {
        // Task<UserModel> GetUser(int id);
        Task<List<UserModel>> GetUsers();
        Task AddUser(UserModel user);
        // Task DeleteUser(int id);
        // Task UpdateUser(UserModel user);
    }
}

