using Reformation.Database;
using Reformation.Models;
using Microsoft.EntityFrameworkCore;
using Reformation.Repositories.Interface;

namespace Reformation.Repositories.UserRepository
{
    public class UserRepository(ApplicationDbContext context) : GenericRepository<UserModel>(context), IUserRepository
    {
        public async Task<UserModel?> GetUserByEmail(string email)
        {
            return await _context.UserModel.Include("Role").FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}

