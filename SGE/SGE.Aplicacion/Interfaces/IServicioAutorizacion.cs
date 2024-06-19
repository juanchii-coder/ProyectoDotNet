namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface IServicioAutentificador
{
    bool ValidarLogin(string email, string password)
}
