namespace SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioPermiso perm, IServicioExpedienteValidador val)
{

  private const string ERROR_MESSAGE = "Error en la Modificacion - ";
  public void Ejecutar(Expediente expediente, int idUsuario, string permiso)
  {
    Expediente? x = repo.ExpedienteConsultaPorId(expediente.Id);
    if (!perm.UsuarioTienePermiso(idUsuario, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id usuario={idUsuario} debe ser igual a 1, Permiso={permiso}");
    }
    if (!val.ValidarExpediente(idUsuario, expediente))
    {
      throw new ValidacionException(ERROR_MESSAGE + $"El Expediente no es Valido");
    }
    if (x == null)
    {
      throw new RepositorioException(ERROR_MESSAGE + "Expediente no Existe");
    }
    repo.ExpedienteModificacion(expediente.Id, expediente, idUsuario);
  }
}
