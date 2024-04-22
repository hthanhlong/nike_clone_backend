using Microsoft.EntityFrameworkCore;
using Reformation.Models;

namespace Reformation.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<UserModel> UserModel { get; set; }

    }
}