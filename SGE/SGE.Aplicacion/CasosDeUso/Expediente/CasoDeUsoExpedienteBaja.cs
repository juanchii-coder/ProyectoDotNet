namespace SGE.Aplicacion.CasosDeUso.Expediente;
using System.Runtime.InteropServices;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Enumerativos;



public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion auto, ITramiteRepositorio tramiteRepo)
{
  private const string ERROR_MESSAGE = "Error en la Baja - ";
  public void Ejecutar(int idExpediente, int idUsuario, Permiso permiso)
  {
    if (!auto.PoseeElPermiso(idUsuario, permiso))
    {
      throw new AutorizacionException(ERROR_MESSAGE + $"id usuario={idUsuario} debe ser igual a 1, Permiso={permiso}");
    }
    Expediente x = repo.ExpedienteConsultaPorId(idExpediente);
    if ((x != null) && (x.Estado != EstadoExpediente.Finalizado))
    {
      repo.ExpedienteBaja(idExpediente);
      List<Tramite> tramites = tramiteRepo.TramiteConsultaTodos();
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
