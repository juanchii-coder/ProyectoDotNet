using Microsoft.EntityFrameworkCore;
using SGE.Entidades

public class PermissionDbContext : DbContext

{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Permissions)
            .WithMany(p => p.Usuarios)
            .UsingEntity(j => j.ToTable("UsuarioPermissions"));
    }
}