namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion auto)
{
  private const string ERROR_MESSAGE="Error en baja del tramite - ";
  public void Ejecutar(int idTramite,int idUsuario, Permiso permiso)
  {
    Tramite x= repo.TramiteConsultaPorId(idTramite);
    if (!auto.PoseeElPermiso(idUsuario, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id{idUsuario}, Permiso={permiso}");
    }
    if (x==null)
    {
      throw new RepositorioException(ERROR_MESSAGE + "Tramite no Existe");
    }
   
    repo.TramiteBaja(idTramite);
  }
}