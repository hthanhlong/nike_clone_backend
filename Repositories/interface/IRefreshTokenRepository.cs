using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories.Interface
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshTokenModel?> GetByToken(string token);

    }
}