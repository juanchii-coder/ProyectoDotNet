namespace SGE.Repositorios.Configuracion;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

public class GestionExpedienteContext : DbContext {
    #nullable disable
    public DbSet<Tramite> Tramites { get; set; }
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Permiso> Permisos { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("data source=GestionExpedientes.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Permisos)
            .WithMany(p => p.Usuarios)
            .UsingEntity(
                "UsuarioPermiso",
                l => l.HasOne(typeof(Permiso)).WithMany().HasForeignKey("PermisosId").HasPrincipalKey(nameof(Permiso.Id)),
                r => r.HasOne(typeof(Usuario)).WithMany().HasForeignKey("UsuariosId").HasPrincipalKey(nameof(Usuario.Id)),
                j => j.HasKey("UsuariosId","PermisosId")
            );
            //.UsingEntity(j => j.ToTable("UsuarioPermissions"));
    }
}