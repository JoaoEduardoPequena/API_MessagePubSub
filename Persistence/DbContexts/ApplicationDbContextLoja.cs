using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.DbContexts
{
    public class ApplicationDbContextLoja : DbContext
    {
        public ApplicationDbContextLoja()
        {

        }
        public ApplicationDbContextLoja(DbContextOptions<ApplicationDbContextLoja> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NBUCLDSI-47;Database=BD_DevBantu;User ID=sa;Password=P3quen@123#;TrustServerCertificate=True");
        }
    }
}
