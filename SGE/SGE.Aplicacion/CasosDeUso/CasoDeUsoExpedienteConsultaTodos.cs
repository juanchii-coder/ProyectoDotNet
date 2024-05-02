namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repo)
{
  public void Ejecutar(){
    repo.ExpedienteConsultaTodos();
  } 
}
