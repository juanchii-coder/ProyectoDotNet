namespace SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioPermiso auto)
{
  private const string ERROR_MESSAGE = "Error en baja del tramite - ";
  public void Ejecutar(int idTramite, int idUsuario, string permiso)
  {
    Tramite? x = repo.TramiteConsultaPorId(idTramite);
    if (!auto.UsuarioTienePermiso(idUsuario, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id{idUsuario}, Permiso={permiso}");
    }
    if (x == null)
    {
      throw new RepositorioException(ERROR_MESSAGE + "Tramite no Existe");
    }

    repo.TramiteBaja(idTramite);
  }
}