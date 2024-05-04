using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nike_clone_Backend.Database;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Repositories.Interface;

namespace Nike_clone_Backend.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshTokenModel>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<RefreshTokenModel?> GetByToken(string token)
        {
            return await _context.RefreshTokenModel.FirstAsync(rt => rt.RefreshToken == token);
        }
    }
}