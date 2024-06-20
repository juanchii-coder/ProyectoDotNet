namespace SGE.Aplicacion.Entidades;

public class Usuario {
    public int Id{ get; set; }
    public string? Nombre{get; set; }
    public string? Apellido{ get; set; }
    public string Email{ get; set; } = "";
    public string Contrasenia{ get; set; } = "";
    public List<Permiso> Permisos{ get; set; } =[];
    public Usuario() {}
    public override string ToString() {
        return $"Nombre y Apellido: {Nombre} {Apellido} \n"
                + $"Email: {Email} Contraseña: {Contrasenia}";
    }
}