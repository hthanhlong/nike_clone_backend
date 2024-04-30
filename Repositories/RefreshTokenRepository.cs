using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Database;
using Reformation.Models;
using Reformation.Repositories.Interface;

namespace Reformation.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshTokenModel>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<RefreshTokenModel?> GetByToken(string token)
        {
            return Task.FromResult(_context.RefreshTokenModel.FirstOrDefault(x => x.RefreshToken == token));
        }
    }
}