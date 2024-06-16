namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public interface ITramiteRepositorio
{
    List<Tramite> ListarTramites();
    void TramiteAlta(Tramite tramite, int idUsuario); // Crear trámite
    void TramiteBaja(int id); // Eliminar trámite
    void TramiteModificacion(int id, string contenido, EtiquetaTramite etiqueta, int idUsuario); // Modificar trámite
    List<Tramite> TramiteConsultaTodos(); // Consultar todos los trámites
    List<Tramite> TramitesPorEtiqueta(EtiquetaTramite etiqueta); // Consultar trámites por etiqueta
    Tramite TramiteConsultaPorId(int id);
}
