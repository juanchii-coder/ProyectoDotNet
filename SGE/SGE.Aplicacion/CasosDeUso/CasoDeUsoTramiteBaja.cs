namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion auto)
{
  private const string ERROR_MESSAGE = "Error en baja del tramite - ";
  public void Ejecutar(int idTramite, int idUsuario, Permiso permiso)
  {
    Tramite x = repo.TramiteConsultaPorId(idTramite);
    if (!auto.PoseeElPermiso(idUsuario, permiso))
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