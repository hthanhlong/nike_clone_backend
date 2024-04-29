using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserByEmail(string email);
    }
}

