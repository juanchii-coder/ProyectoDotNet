using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Repositorios;

public class RepositorioExpediente : IExpedienteRepositorio
{
  private readonly GestionExpedienteContext _db = new GestionExpedienteContext();
  public void ExpedienteAlta(Expediente expediente)
  {
    expediente.FechaCreacion = DateTime.Now;
    expediente.UltimaModificacion = DateTime.Now;
    _db.Add(expediente);
    _db.SaveChanges();
  }

  public void ExpedienteBaja(int id)
  {
    var expedienteAEliminar = ExpedienteConsultaPorId(id);
    if (expedienteAEliminar != null)
    {
      db.Remove(expedienteAEliminar);
      db.SaveChanges();
    }

    public void ExpedienteModificacion(int id, Expediente expediente)
    {
      var expedienteModificar = ExpedienteConsultaPorId(id);
      if (tramiteModificar != null)
      {

        _db.Update();
        _db.SaveChanges();
        Console.WriteLine("Expediente modificado");
      }

    }



    public Expediente? ExpedienteConsultaPorId(int id)
    {
      return _db.Expedientes.Where(e => e.Id == id).SingleOrDefault();
    }

    public List<Expediente>? ExpedienteConsultaTodos()
    {
      return ListarExpediente();
    }

    private List<Expediente> ListarExpediente()
    {

      var query = _db.Expedientes.ToList();
      return query;
    }


  }

}
