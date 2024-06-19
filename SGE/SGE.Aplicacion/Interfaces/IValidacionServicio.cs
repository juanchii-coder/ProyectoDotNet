namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface IServicioValidacion
{
    bool ValidarLogin(string email, string password)
    bool ValidarUsuario(Usuario usuario);
    bool ValidarExpediente(int idUsuario, Expediente expediente);
    bool ValidarTramite(int idusuario, Tramite tramite);
}
