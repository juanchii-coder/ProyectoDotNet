namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
  void ExpedienteAlta(Expediente expediente, int idUsuario);//crear expediente
  void ExpedienteBaja(int id);//eliminar expediente
  void ExpedienteModificacion(int id, string caratula, EstadoExpediente estado, int idUsuario);//borrar tramites
  List<Expediente> ExpedienteConsultaTodos();
  Expediente ExpedienteConsultaPorId(int id);

}
