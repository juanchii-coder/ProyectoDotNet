namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public interface IExpedienteRepositorio
{
  void ExpedienteAlta(Expediente expediente, int idUsuario);//crear expediente
  void ExpedienteBaja(int id);//eliminar expediente
  void ExpedienteModificacion(int id, string caratula, EstadoExpediente estado, int idUsuario);//borrar tramites
  List<Expediente>? ExpedienteConsultaTodos();
  Expediente? ExpedienteConsultaPorId(int id);

}
