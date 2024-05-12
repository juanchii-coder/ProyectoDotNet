namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repo)
{
  public List<Expediente> Ejecutar()
  {
    List<Expediente> expedientes = repo.ExpedienteConsultaTodos();
    if (expedientes != null)
    {
      return expedientes;
    }
    else
    {
      throw new RepositorioException("");
    }
  }
}
