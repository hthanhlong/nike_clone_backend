namespace Nike_clone_Backend.Repositories;
public interface IUnitOfWork : IDisposable
{
    public CategoryRepository CategoryRepository { get; }
    public UserRepository UserRepository { get; }
    public RoleRepository RoleRepository { get; }
    public PermissionRepository PermissionRepository { get; }
    public RefreshTokenRepository RefreshTokenRepository { get; }
    public Task SaveAsync();
}

