using Reformation.Database;
using Microsoft.EntityFrameworkCore;

namespace Reformation.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        public virtual TEntity? GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Delete(object id)
        {
            TEntity? entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }
        public virtual async Task<TEntity?> GetByIDAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}