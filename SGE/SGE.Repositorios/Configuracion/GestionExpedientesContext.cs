
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

public class GestionExpedienteContext : DbContext {
    #nullable disable
    public DbSet<Tramite> Tramites { get; set; }
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("data source=GestionExpedientes.sqlite");
    }
}