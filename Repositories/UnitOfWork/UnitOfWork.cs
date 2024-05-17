using Nike_clone_Backend.Database;

namespace Nike_clone_Backend.Repositories;
public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private CategoryRepository? _categoryRepository;
    private UserRepository? _userRepository;
    private RoleRepository? _roleRepository;
    private PermissionRepository? _permissionRepository;
    private RefreshTokenRepository? _refreshTokenRepository;
    private readonly ApplicationDbContext _context = context;

    // CategoryRepository -----------------------
    public CategoryRepository CategoryRepository
    {
        get
        {

            if (this._categoryRepository == null)
            {
                this._categoryRepository = new CategoryRepository(_context);
            }
            return _categoryRepository;
        }
    }

    // UserRepository -----------------------
    public UserRepository UserRepository
    {
        get
        {
            if (this._userRepository == null)
            {
                this._userRepository = new UserRepository(_context);
            }
            return _userRepository;
        }
    }
    // RoleRepository -----------------------
    public RoleRepository RoleRepository
    {
        get
        {
            if (this._roleRepository == null)
            {
                this._roleRepository = new RoleRepository(_context);
            }
            return _roleRepository;
        }
    }
    // PermissionRepository -----------------------
    public PermissionRepository PermissionRepository
    {
        get
        {
            if (this._permissionRepository == null)
            {
                this._permissionRepository = new PermissionRepository(_context);
            }
            return _permissionRepository;
        }
    }
    // PermissionRepository -----------------------
    public RefreshTokenRepository RefreshTokenRepository
    {
        get
        {
            if (this._refreshTokenRepository == null)
            {
                this._refreshTokenRepository = new RefreshTokenRepository(_context);
            }
            return _refreshTokenRepository;
        }
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}