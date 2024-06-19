namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class ServicioValidacion : IValidacionServicio
{
    private readonly GestionExpedienteContext contexto;

    public ServicioValidacion(GestionExpedienteContext context)
    {
        contexto = context;
    }
    public bool ValidarPassword(string password, string Contrasenia)
    {
        using( var hsha256= SHA256.Create())
        {
            var hash= sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

             return Contrasenia == Convert.ToBase64String(hash);
        }
    }
    public bool ValidarLogin(string email, string password)
    {
        var usuario = contexto.Usuarios.SingleOrDefault(u => u.Email == email);
        if (usuario != null)
        {
            return ValidarPassword(password, usuario.Contrasenia);
        }
        return false;   
    }
    public bool ValidarUsuario(Usuario usuario)
    {    
        return !string.IsNullOrEmpty(usuario.Nombre) && !string.IsNullOrEmpty(usuario.Apellido) && !string.IsNullOrEmpty(usuario.Contrasenia) && !string.IsNullOrEmpty(usuario.Email);
    }
   public bool ValidarExpediente(int idUsuario, Expediente expediente)
    {    
    var usuario = contexto.Usuarios.Any(u => u.Id == idUsuario);
    return usuario && !string.IsNullOrEmpty(expediente.Caratula);
    }
    public bool ValidarTramite(int idUsuario, Tramite tramite)
    {
    var usuario = contexto.Usuarios.Any(u => u.Id == idUsuario);
    
    return usuario && !string.IsNullOrEmpty(tramite.Contenido);
    }
}
