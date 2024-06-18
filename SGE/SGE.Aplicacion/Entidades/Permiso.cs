namespace SGE.Aplicacion.Entidades;
public class Permiso
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}