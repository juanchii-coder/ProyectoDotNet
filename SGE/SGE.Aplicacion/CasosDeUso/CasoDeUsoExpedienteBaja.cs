namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo)
{
  public void Ejecutar(int id, Permiso permiso)
  {
    if (permiso == 0)
    {
      repo.ExpedienteBaja(id);
    }
    else
    {
      throw new AutorizacionException();
    }
  }
}
