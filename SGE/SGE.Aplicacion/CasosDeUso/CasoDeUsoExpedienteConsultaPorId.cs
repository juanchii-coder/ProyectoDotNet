namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo)
{
  public void Ejecutar(int id){
    repo.ExpedienteConsultaPorId(id);
  } 
}
