using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories;
public interface IRefreshTokenRepository
{
    Task<RefreshTokenModel?> GetByToken(string token);

}