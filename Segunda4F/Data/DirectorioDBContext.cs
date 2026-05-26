using Microsoft.EntityFrameworkCore;

namespace Segunda4F.Data
{
    public class DirectorioDBContext : DbContext
    {
        public DirectorioDBContext(
            DbContextOptions<DirectorioDBContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<TipoCliente> TipoClientes { get; set; }

        public DbSet<Interes> Intereses { get; set; }

        public DbSet<ClienteInteres> ClienteIntereses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteInteres>()
                .HasKey(ci => new
                {
                    ci.ClienteId,
                    ci.InteresId
                });

            modelBuilder.Entity<ClienteInteres>()
                .HasOne(ci => ci.Cliente)
                .WithMany(c => c.ClienteIntereses)
                .HasForeignKey(ci => ci.ClienteId);

            modelBuilder.Entity<ClienteInteres>()
                .HasOne(ci => ci.Interes)
                .WithMany(i => i.ClienteIntereses)
                .HasForeignKey(ci => ci.InteresId);
        }
    }
}