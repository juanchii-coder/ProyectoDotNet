namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo)
{
  public void Ejecutar(int id,string caratula,int idUsuario){
    repo.ExpedienteModificacion(id, caratula, idUsuario);
  } 
}
