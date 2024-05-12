namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion auto, ExpedienteValidador val)
{
  public void Ejecutar(Expediente expediente, int id, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException();
    }
    if (!val.EsExpedienteValido(id, expediente))
    {
      throw new ValidacionException();
    }
    expediente.Estado = EstadoExpediente.RecienIniciado;
    repo.ExpedienteAlta(expediente, id);
  }
}
