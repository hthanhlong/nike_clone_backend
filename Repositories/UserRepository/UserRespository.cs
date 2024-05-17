using Nike_clone_Backend.Database;
using Nike_clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Nike_clone_Backend.Repositories;
public class UserRepository(ApplicationDbContext context) : GenericRepository<UserModel>(context), IUserRepository
{
    public async Task<UserModel?> GetUserByEmail(string email)
    {
        return await _context.UserModel.Include("Role").FirstOrDefaultAsync(user => user.Email == email);
    }
}

