namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface IValidationService
{
    bool ValidarLogin(string email, string password)
    bool ValidarUsuario(Usuario usuario);
    bool ValidarExpediente(int idExpediente);
    bool ValidarTramite(int idTramite);
}