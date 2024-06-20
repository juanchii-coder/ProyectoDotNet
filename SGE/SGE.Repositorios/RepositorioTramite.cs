namespace SGE.Repositorios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Repositorios.Configuracion;


public class RepositorioTramite : ITramiteRepositorio
{

  private readonly GestionExpedienteContext _db = new GestionExpedienteContext();
  public List<Tramite> ListarTramites()
  {
    return _db.Tramites.ToList();
  }

  public void TramiteAlta(Tramite tramite, int idUsuario)
  {
    tramite.IdUsuarioUltimaModificacion = idUsuario;
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
      _db.Remove(tramiteAEliminar);
      _db.SaveChanges();
    }
  }

    public Tramite? TramiteConsultaPorId(int id)
    {
        return _db.Tramites.Where(t => t.Id == id).SingleOrDefault();
    }

    public void TramiteModificacion(int id, Tramite tramite, int idUsuario)
  {
    var tramiteModificar = TramiteConsultaPorId(id);
    if (tramiteModificar != null)
    {
      tramiteModificar.IdUsuarioUltimaModificacion = idUsuario;
      tramiteModificar.Contenido = tramite.Contenido;
      tramiteModificar.UltimaModificacion = DateTime.Now;
      tramiteModificar.Etiqueta = tramite.Etiqueta;
      _db.Update(tramiteModificar);
      _db.SaveChanges();
      Console.WriteLine("Tramite modificado");
    }

  }

    public List<Tramite> TramitesPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var tramitesEtiqueta = _db.Tramites.Where(t => t.Etiqueta == etiqueta).ToList();
        return tramitesEtiqueta;
    }
}
