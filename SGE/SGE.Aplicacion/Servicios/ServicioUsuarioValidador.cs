namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class ServicioUsuarioValidador : IServicioUsuarioValidador
{    
    public bool ValidarUsuario(Usuario usuario)
    {    
        return !string.IsNullOrEmpty(usuario.Nombre) && !string.IsNullOrEmpty(usuario.Apellido) && !string.IsNullOrEmpty(usuario.Contrasenia) && !string.IsNullOrEmpty(usuario.Email);
    }
  
}