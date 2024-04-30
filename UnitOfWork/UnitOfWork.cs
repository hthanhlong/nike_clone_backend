using Reformation.Database;
using Reformation.Models;
using Reformation.Repositories;
using Reformation.Repositories.CategoryRepository;
using Reformation.Repositories.PermissionRepository;
using Reformation.Repositories.RoleRepository;
using Reformation.Repositories.UserRepository;

namespace Reformation.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CategoryRepository categoryRepository;
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private PermissionRepository permissionRepository;
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

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