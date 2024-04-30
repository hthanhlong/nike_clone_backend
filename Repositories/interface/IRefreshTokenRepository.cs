using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.Interface
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshTokenModel?> GetByToken(string token);
        
    }
}