namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion auto)
{
  private const string ERROR_MESSAGE="Error en baja del tramite - ";
  public void Ejecutar(int id, Permiso permiso)
  {
    Tramite x= repo.TramiteConsultaPorId(id);
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id{id}, Permiso={permiso}");
    }
    if (x==null)
    {
      throw new RepositorioException(ERROR_MESSAGE + "Tramite no Existe");
    }
   
    repo.TramiteBaja(id);
  }
}