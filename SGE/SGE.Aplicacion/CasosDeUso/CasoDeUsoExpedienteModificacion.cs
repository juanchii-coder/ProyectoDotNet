namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion auto)
{
  public void Ejecutar(int id, string caratula, int idUsuario, Permiso permiso)
  {
    Expediente x = repo.ExpedienteConsultaPorId(id);
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException();
    }
    if (x == null)
    {
      throw new RepositorioException();
    }
    repo.ExpedienteModificacion(id, caratula, idUsuario);
  }
}
