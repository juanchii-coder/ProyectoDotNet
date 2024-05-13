namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion auto, TramiteValidador val)
{
  private const ERROR_MESSAGE: 'Error en baja del tramite - ';
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
   
    repo.TramiteBaja(id);
  }
}
1