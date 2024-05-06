namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
{
  public void Ejecutar(Expediente expediente, int id, Permiso permiso)
  {
    if (permiso == Permiso.ExpedienteAlta)
    {
      repo.ExpedienteAlta(expediente, id);
    }
    else
    {
      throw new AutorizacionException();
    }
  }
}
