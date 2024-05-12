using System.Runtime.InteropServices;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion auto, ITramiteRepositorio tramiteRepo)
{
  public void Ejecutar(int id, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(id, permiso))
    {
      throw new AutorizacionException();
    }
    if (repo.ExpedienteConsultaPorId(id).Estado == EstadoExpediente.Finalizado)
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
  }
}
