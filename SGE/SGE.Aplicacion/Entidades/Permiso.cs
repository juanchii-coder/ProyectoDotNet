public class Permission
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Usuario> Ususuarios { get; set; } = new List<Usuario>();
}