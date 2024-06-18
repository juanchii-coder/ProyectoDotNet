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
}