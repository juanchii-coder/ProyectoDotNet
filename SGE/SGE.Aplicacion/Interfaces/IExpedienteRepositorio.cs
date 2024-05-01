namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
  void ExpedienteAlta(Expediente expediente,int idUsuario);//crear expediente
  void ExpedienteBaja(int id);//eliminar expediente
  void ExpedienteModificacion(int id);//borrar tramites
}
