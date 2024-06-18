namespace SGE.Aplicacion.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SGE.Aplicacion;

public class Usuario {
    public int Id{ get; set; }
    public string? Nombre{get; set; }
    public string? Apellido{ get; set; }
    public string Email{ get; set; } = "";
    public string Contrasenia{ get; set; } = "";
    public List<Permiso> Permisos{ get; set; } = new List<Permiso>();
    public Usuario() {}
    public override string ToString() {
        return $"Nombre y Apellido: {Nombre} {Apellido} \n"
                + $"Email: {Email} Contraseña: {Contrasenia}";
    }
}