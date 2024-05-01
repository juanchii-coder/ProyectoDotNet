namespace SGE.Aplicacion;

public class Expediente
{
  int _Id;
  String _Caratula;
  DateTime FechaCreacion;
  DateTime UltimaModificacion;
  int _IdUsuario;//ultimo usuario que modifico el expediente
  EstadoExpediente estado;
}
