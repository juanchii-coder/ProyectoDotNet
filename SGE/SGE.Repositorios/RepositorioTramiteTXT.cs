using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramiteTXT:ItramiteRepositorio
{
readonly string _nombreArch = "tramites.xt";

private List<Tramite> ListarTramites()
  {
    var listado = new List<tramite>();
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      var tramite = new Tramite();
      tramite.Id = int.Parse(sr.ReadLine() ?? "");
      tramite.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
      tramite.Etiqueta = sr.ReadLine() ?? "";
      tramite.Contenido = sr.ReadLine() ?? "";
      tramite.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
      tramite.UltimaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
      tramite.IdUsuarioUltimaModificacion = int.Parse(sr.ReadLine() ?? "");

      listado.Add(tramite);
    }   
    return listado;
  }

  private int ObtenerUltimoId()
  {
    if (!File.Exists(_nombreArch))
      return 0; // Cuando el archivo no existe

    int ultimoId = 0;
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      ultimoId = int.Parse(sr.ReadLine() ?? "0");
      sr.ReadLine();
      sr.ReadLine();
      sr.ReadLine();
      sr.ReadLine();
      sr.ReadLine();
    }
    return ultimoId;
  }
private void ReescribirArchivo(List<Tramite> tramites)
{
    using (StreamWriter sw = new StreamWriter(_nombreArchivo, false))
    {
        foreach (var tramite in tramites)
        {
            sw.WriteLine(tramite.Id);
            sw.WriteLine(tramite.ExpedienteId);
            sw.WriteLine(tramite.Etiqueta);
            sw.WriteLine(tramite.Contenido);
            sw.WriteLine(tramite.FechaCreacion);
            sw.WriteLine(tramite.UltimaModificacion);
            sw.WriteLine(tramite.IdUsuarioUltimaModificacion);
        }
    }
}
public void TramiteAlta(Tramite tramite, int idUsuario)
  {
    int nuevoId = ObtenerUltimoId();
    tramite.Id = nuevoId;    
    tramite.FechaCreacion = DateTime.Now;
    tramite.UltimaModificacion = DateTime.Now;
    tramite.IdUsuario = idUsuario;
    tramite.etiqueta = EtiquetaTramite.RecienIniciado;

    using var sw = new StreamWriter(_nombreArch, true);
    sw.WriteLine(tramite.Id);
    sw.WriteLine(tramite.ExpedienteId);
    sw.WriteLine(tramite.Etiqueta);
    sw.WriteLine(tramite.Contenido);
    sw.WriteLine(tramite.FechaCreacion);
    sw.WriteLine(tramite.UltimaModificacion);
    sw.WriteLine(tramite.IdUsuarioUltimaModificacion);
  }
public void TramiteBaja(int id){ 
    
    var tramites= ListarTramites()
    var tramiteAEliminar = tramites.Find(x => x.Id == id);
    if (tramiteAEliminar != null)
    {
      tramites.Remove(tramiteAEliminar);

      ReescribirArchivo(tramites);
    }
  }
public void TramiteModificacion(int id, string etiqueta, int idUsuario)
{
    var tramites = ListarTramites();
    var index = tramites.FindIndex(t => t.Id == id);
    if (index >= 0)
    {
        tramites[index].Etiqueta = etiqueta;
        tramites[index].IdUsuarioUltimaModificacion = idUsuario;
        tramites[index].UltimaModificacion = DateTime.Now;

        ReescribirArchivo(tramites);
    }
}

public List<Tramite> TramiteConsultaPorEtiqueta(string etiqueta){
    return ListarTramites().Where(t =>t.etiqueta==etiqueta);
}
}
