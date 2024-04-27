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
        public DbSet<RoleModel> RoleModel { get; set; }
        public DbSet<PermissionModel> PermissionModel { get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<ProductModel> ProductModel { get; set; }
        public DbSet<TransactionModel> TransactionModel { get; set; }
        public DbSet<CategoryModel> CategoryModel { get; set; }
        public DbSet<WarehouseModel> WarehouseModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}