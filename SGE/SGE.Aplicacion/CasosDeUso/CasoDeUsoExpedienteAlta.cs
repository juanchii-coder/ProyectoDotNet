namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repo)
{
  public void Ejecutar(Expediente expediente, int id){
    repo.ExpedienteAlta(expediente,id);
  } 
}
