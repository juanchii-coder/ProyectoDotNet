namespace SGE.Repositorios.Servicios;
using SGE.Aplicacion.Interfaces;
using SGE.Repositorios.Configuracion;
using System.Text;

public class ServicioAutentificador : IServicioAutentificador
{
    private readonly GestionExpedienteContext contexto;

    public ServicioAutentificador(GestionExpedienteContext context)
    {
        contexto = context;
    }
    public bool ValidarLogin(string email, string password)
    {
        var usuario = contexto.Usuarios.SingleOrDefault(u => u.Email == email);
        if (usuario != null)
        {
            ServicioCodificacion codificador = new ServicioCodificacion();
            password = codificador.codificarContrasenia(password);
            return password.Equals(usuario.Contrasenia);
        }
        return false;   
    }
   
}