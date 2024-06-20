namespace SGE.Repositorios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Repositorios.Configuracion;

public class RepositorioExpediente : IExpedienteRepositorio
{
  private readonly GestionExpedienteContext _db = new GestionExpedienteContext();
  public void ExpedienteAlta(Expediente expediente, int idUsuario)
  {
    expediente.IdUsuario = idUsuario;
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
      _db.Remove(expedienteAEliminar);
      _db.SaveChanges();
    }
  }

    public void ExpedienteModificacion(int id, Expediente expediente, int idUsuario)
    {
      var expedienteModificar = ExpedienteConsultaPorId(id);
      if (expedienteModificar != null)
      {
        expediente.IdUsuario = idUsuario;
        expedienteModificar.Caratula = expediente.Caratula;
        expedienteModificar.UltimaModificacion = DateTime.Now;
        _db.Update(expedienteModificar);
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


