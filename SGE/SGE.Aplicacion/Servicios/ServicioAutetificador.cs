namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class ServicioAutentificador : IServicioAutentificador
{
    private readonly GestionExpedienteContext contexto;

    public ServicioAutentificador(GestionExpedienteContext context)
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
   
}