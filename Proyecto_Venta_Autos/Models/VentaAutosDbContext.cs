using Microsoft.EntityFrameworkCore;

namespace Proyecto_Venta_Autos.Models
{
    public class VentaAutosDbContext : DbContext
    {
        public VentaAutosDbContext(DbContextOptions<VentaAutosDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.Nombres).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Correo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EsAdministrador).IsRequired().HasMaxLength(20);

                entity.HasCheckConstraint("CK_Rol", "[Rol] IN ('Cliente', 'Administrador')");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
