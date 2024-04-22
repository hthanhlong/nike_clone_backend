using Reformation.Database;
using Reformation.Models;
using Microsoft.EntityFrameworkCore;

namespace Reformation.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _context.UserModel.ToListAsync();
        }

        public async Task AddUser(UserModel user)
        {
            await _context.UserModel.AddAsync(user);
            await _context.SaveChangesAsync();
        }

    }
}

