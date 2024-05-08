using Nike_clone_Backend.Database;
using Nike_clone_Backend.Repositories;
using Nike_clone_Backend.Repositories.CategoryRepository;
using Nike_clone_Backend.Repositories.PermissionRepository;
using Nike_clone_Backend.Repositories.RoleRepository;
using Nike_clone_Backend.Repositories.UserRepository;

namespace Nike_clone_Backend.UnitOfWork
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        private CategoryRepository categoryRepository;
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private PermissionRepository permissionRepository;
        private RefreshTokenRepository refreshTokenRepository;
        private readonly ApplicationDbContext _context = context;

        // CategoryRepository -----------------------
        public CategoryRepository CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(_context);
                }
                return categoryRepository;
            }
        }

        // UserRepository -----------------------
        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }
        // RoleRepository -----------------------
        public RoleRepository RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository(_context);
                }
                return roleRepository;
            }
        }
        // PermissionRepository -----------------------
        public PermissionRepository PermissionRepository
        {
            get
            {
                if (this.permissionRepository == null)
                {
                    this.permissionRepository = new PermissionRepository(_context);
                }
                return permissionRepository;
            }
        }
        // PermissionRepository -----------------------
        public RefreshTokenRepository RefreshTokenRepository
        {
            get
            {
                if (this.refreshTokenRepository == null)
                {
                    this.refreshTokenRepository = new RefreshTokenRepository(_context);
                }
                return refreshTokenRepository;
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
}