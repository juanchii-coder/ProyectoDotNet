namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repo)
{
  public void Ejecutar(string caratula){
    repo.ExpedienteAlta(caratula);
  } 
}
