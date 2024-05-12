namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion auto)
{
  public void Ejecutar(int id, string caratula, int idUsuario, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException();
    }
    repo.ExpedienteModificacion(id, caratula, idUsuario);
  }
}
