namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion auto,ExpedienteValidador valo)
{
  
  private const string ERROR_MESSAGE="Error en la Modificacion - ";
  public void Ejecutar(Expediente expediente, int idUsuario, Permiso permiso)
  {
    Expediente x=repo.ExpedienteConsultaPorId(expediente.Id);
    if (!auto.PoseeElPermiso(idUsuario, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE+ $"id usuario={idUsuario} debe ser igual a 1, Permiso={permiso}");
    }
    if(!valo.EsExpedienteValido(idUsuario, expediente))
    {
      throw new ValidacionException(ERROR_MESSAGE+$"El Expediente no es Valido");
    }
    if (x==null)
    {
      throw new RepositorioException(ERROR_MESSAGE+"Expediente no Existe");
    }
    repo.ExpedienteModificacion(expediente.Id, expediente.Caratula, expediente.Estado, idUsuario);
  }
}
