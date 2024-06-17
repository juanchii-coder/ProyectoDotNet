namespace SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repo)
{
  private const string ERROR_MESSAGE = "Error en la Consulta - ";
  public List<Expediente> Ejecutar()
  {
    List<Expediente> expedientes = repo.ExpedienteConsultaTodos();
    if (expedientes != null)
    {
      return expedientes;
    }
    else
    {
      throw new RepositorioException(ERROR_MESSAGE + "No se Cargo Ningun Expediente");
    }
  }
}
