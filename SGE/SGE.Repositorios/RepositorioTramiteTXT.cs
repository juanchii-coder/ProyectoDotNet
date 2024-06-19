using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Repositorios;

public class RepositorioTramite : ITramiteRepositorio
{

  private readonly GestionExpedienteContext _db = new GestionExpedienteContext();
  public List<Tramite> ListarTramites()
  {
    return _db.Tramites.ToList();
  }



  public void TramiteAlta(Tramite tramite)
  {

    tramite.FechaCreacion = DateTime.Now;
    tramite.UltimaModificacion = DateTime.Now;
    tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;
    _db.Add(tramite);
    _db.SaveChanges();
    Console.WriteLine("Usuario dado de alta");

  }
  public void TramiteBaja(int id)
  {

    var tramiteAEliminar = TramiteConsultaPorId(id);
    if (tramiteAEliminar != null)
    {
      db.Remove(tramiteAEliminar);
      db.SaveChanges();
    }
  }
  public void TramiteModificacion(int id, Tramite tramite)
  {
    var tramiteModificar = TramiteConsultaPorId(id);
    if (tramiteModificar != null)
    {
      tramiteModificar.Contenido = tramite.Contenido;
      tramiteModificar.UltimaModificacion = DateTime.Now;
      tramiteModificar.Etiqueta = tramite.Etiqueta;
      _db.Update(tramiteModificar);
      _db.SaveChanges();
      Console.WriteLine("Tramite modificado");
    }

  }
}

public List<Tramite> TramitesPorEtiqueta(EtiquetaTramite etiqueta)
{
  var tramitesEtiqueta = _db.Tramites.Where(t => t.Etiqueta == etiqueta).ToList();
  return tramitesEtiqueta;
}



public Tramite TramiteConsultaPorId(int id)
{
  return _db.Tramites.Where(t => t.Id == id).SingleOrDefault();
}
