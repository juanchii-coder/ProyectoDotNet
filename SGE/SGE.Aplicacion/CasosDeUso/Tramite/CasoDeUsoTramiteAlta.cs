namespace SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Servicios;
public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, IServicioAutorizacion auto, TramiteValidador val, ServicioActualizacionEstado act)
{
  private const string ERROR_MESSAGE = "Error en alta de tramite - ";
  public void Ejecutar(Tramite tramite, int id, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id{id}, Permiso={permiso}");
    }
    if (!val.EsTramiteValido(id, tramite))
    {
      throw new ValidacionException(ERROR_MESSAGE + $" id | Contenido={tramite.Contenido} no valido");
    }
    tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;
    repo.TramiteAlta(tramite, id);
    act.ActualizarEstado(tramite.ExpedienteId, id);
  }
}
