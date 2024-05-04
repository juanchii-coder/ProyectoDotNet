namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo)
{
  public void Ejecutar(int id, string caratula, int idUsuario, Permiso permiso)
  {
    if (permiso == Permiso.ExpedienteModificacion)
    {
      repo.ExpedienteModificacion(id, caratula, idUsuario);
    }
    else
    {
      throw new AutorizacionException();
    }
  }
}
