namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, IServicioAutorizacion auto, TramiteValidador val)
{
  private const string ERROR_MESSAGE= "Error en modificacion del tramite -" ;
     public void Ejecutar(Tramite tramite, int id, Permiso permiso)
  {
    Tramite x= repo.TramiteConsultaPorId(tramite.Id);
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id{id}, Permiso={permiso}");
    }

    if (x==null)
    {
      throw new RepositorioException(ERROR_MESSAGE + "Tramite no Existe");
    }
    
    if (!val.EsTramiteValido(id, tramite))
    {
      throw new ValidacionException(ERROR_MESSAGE + $"id={id} | Contenido={tramite.Contenido} no valido");
    }
   
    repo.TramiteModificacion(tramite.Id, tramite.Contenido, id);
  }
}