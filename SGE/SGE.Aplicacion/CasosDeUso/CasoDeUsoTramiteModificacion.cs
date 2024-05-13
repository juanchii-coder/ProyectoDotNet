namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, IServicioAutorizacion auto, TramiteValidador val)
{
  private const ERROR_MESSAGE: 'Error en modificacion del tramite - ';
     public void Ejecutar(Tramite tramite, int id, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id{id}, Permiso={permiso}");
    }
    if (!val.EsTramiteValido(id, tramite))
    {
      throw new ValidacionException(ERROR_MESSAGE + $"id={id} | Contenido={tramite.Contenido} no valido");
    }
   
    repo.TramiteModificacion(id, contenido, idUsuario)
  }
}