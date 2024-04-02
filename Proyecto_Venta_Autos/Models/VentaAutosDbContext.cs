using Microsoft.EntityFrameworkCore;

namespace Proyecto_Venta_Autos.Models
{
    public class VentaAutosDbContext : DbContext
    {
        public VentaAutosDbContext(DbContextOptions<VentaAutosDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Auto> Autos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Contraseña).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Rol).IsRequired().HasMaxLength(20);

                entity.HasCheckConstraint("CK_Rol", "[Rol] IN ('Cliente', 'Administrador')");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
