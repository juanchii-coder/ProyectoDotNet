namespace SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Servicios;
public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, IServicioPermiso auto, IValidacionServicio val, ServicioActualizacionEstado act)
{
  private const string ERROR_MESSAGE = "Error en modificacion del tramite -";
  public void Ejecutar(Tramite tramite, int id, string permiso)
  {
    Tramite? x = repo.TramiteConsultaPorId(tramite.Id);
    if (!auto.UsuarioTienePermiso(id, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id{id}, Permiso={permiso}");
    }

    if (x == null)
    {
      throw new RepositorioException(ERROR_MESSAGE + "Tramite no Existe");
    }
    if (!val.ValidarTramite(id, tramite))
    {
      throw new ValidacionException(ERROR_MESSAGE + $"id={id} | Contenido={tramite.Contenido} no valido");
    }
    act.ActualizarEstado(tramite.ExpedienteId, id);
    repo.TramiteModificacion(tramite.Id, tramite, id);
  }
}