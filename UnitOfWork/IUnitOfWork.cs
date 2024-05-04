using Nike_clone_Backend.Repositories;
using Nike_clone_Backend.Repositories.CategoryRepository;
using Nike_clone_Backend.Repositories.PermissionRepository;
using Nike_clone_Backend.Repositories.RoleRepository;
using Nike_clone_Backend.Repositories.UserRepository;

namespace Nike_clone_Backend.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public CategoryRepository CategoryRepository { get; }
        public UserRepository UserRepository { get; }
        public RoleRepository RoleRepository { get; }
        public PermissionRepository PermissionRepository { get; }
        public RefreshTokenRepository RefreshTokenRepository { get; }
        public Task SaveAsync();
    }
}

