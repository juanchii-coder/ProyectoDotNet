namespace SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Validadores;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion auto, ExpedienteValidador val)
{
  private const string ERROR_MESSAGE = "Error en la Alta - ";
  public void Ejecutar(Expediente expediente, int idUsuario, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(idUsuario, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id usuario={idUsuario} debe ser igual a 1, Permiso={permiso}");
    }
    if (!val.EsExpedienteValido(idUsuario, expediente))
    {
      throw new ValidacionException(ERROR_MESSAGE + $"El Expediente no es Valido");
    }
    expediente.Estado = EstadoExpediente.RecienIniciado;
    repo.ExpedienteAlta(expediente, idUsuario);
  }
}
