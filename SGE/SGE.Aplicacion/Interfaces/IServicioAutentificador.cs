namespace SGE.Aplicacion.Interfaces;
public interface IServicioAutentificador
{
    bool ValidarLogin(string email, string password);
}
