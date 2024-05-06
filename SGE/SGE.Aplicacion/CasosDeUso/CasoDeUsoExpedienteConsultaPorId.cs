namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo)
{
  public Expediente Ejecutar(int id)
  {
    return repo.ExpedienteConsultaPorId(id);
  }
}
