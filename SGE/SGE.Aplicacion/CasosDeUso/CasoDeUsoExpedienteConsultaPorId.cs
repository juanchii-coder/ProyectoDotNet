namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo)
{
  public Expediente Ejecutar(int id)
  {
    Expediente expediente = repo.ExpedienteConsultaPorId(id);
    if (expediente != null)
    {
      return expediente;
    }
    else
    {
      throw new RepositorioException("");
    }
  }
}
