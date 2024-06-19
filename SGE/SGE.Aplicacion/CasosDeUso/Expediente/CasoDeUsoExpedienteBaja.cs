namespace SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Enumerativos;



public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioPermiso auto, ITramiteRepositorio tramiteRepo)
{
  private const string ERROR_MESSAGE = "Error en la Baja - ";
  public void Ejecutar(int idExpediente, int idUsuario, string permiso)
  {
    if (!auto.UsuarioTienePermiso(idUsuario, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id usuario={idUsuario} debe ser igual a 1, Permiso={permiso}");
    }
    Expediente? x = repo.ExpedienteConsultaPorId(idExpediente);
    if ((x != null) && (x.Estado != EstadoExpediente.Finalizado))
    {
      repo.ExpedienteBaja(idExpediente);
      List<Tramite> tramites = tramiteRepo.ListarTramites();
      foreach (Tramite tramite in tramites)
      {
        if (tramite.ExpedienteId == idExpediente)
        {
          tramiteRepo.TramiteBaja(tramite.Id);
        }
      }
    }
    else
    {
      throw new RepositorioException(ERROR_MESSAGE + $"no existe el expediente {idExpediente}");
    }
  }
}
