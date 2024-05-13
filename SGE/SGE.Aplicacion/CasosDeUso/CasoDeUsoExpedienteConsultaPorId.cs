namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo)
{
   private const string ERROR_MESSAGE="Error en la Consulta - ";
  public Expediente Ejecutar(int id)
  {
    Expediente expediente = repo.ExpedienteConsultaPorId(id);
    if (expediente != null)
    {
      return expediente;
    }
    else
    {
      throw new RepositorioException(ERROR_MESSAGE+$"Expediente {id} No Existe");
    }
  }
}
