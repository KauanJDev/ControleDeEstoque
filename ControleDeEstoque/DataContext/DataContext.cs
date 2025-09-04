using ControleDeEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
