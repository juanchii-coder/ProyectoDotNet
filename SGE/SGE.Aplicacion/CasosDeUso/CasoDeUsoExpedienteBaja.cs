using System.Runtime.InteropServices;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion auto, ITramiteRepositorio tramiteRepo)
{
   private const string ERROR_MESSAGE="Error en la Baja - ";
  public void Ejecutar(int id, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE+ $"id{id}, Permiso={permiso}");
    }
    Expediente x = repo.ExpedienteConsultaPorId(id);
    if ((x != null) && (x.Estado == EstadoExpediente.Finalizado))
    {
      repo.ExpedienteBaja(id);
      List<Tramite> tramites = tramiteRepo.TramiteConsultaTodos();
      foreach (Tramite tramite in tramites)
      {
        if (tramite.ExpedienteId == id)
        {
          tramiteRepo.TramiteBaja(tramite.Id);
        }
      }
    }
    else
    {
      throw new RepositorioException(ERROR_MESSAGE+ $"no existe el expediente {id}");
    }
  }
}
