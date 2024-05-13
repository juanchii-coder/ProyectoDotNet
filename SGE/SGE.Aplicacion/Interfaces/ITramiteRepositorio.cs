namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(Tramite tramite, int idUsuario); // Crear trámite
    void TramiteBaja(int id); // Eliminar trámite
    void TramiteModificacion(int id, string etiqueta, int idUsuario); // Modificar trámite
    List<Tramite> TramiteConsultaTodos(); // Consultar todos los trámites
    List<Tramite> TramitesPorEtiqueta(EtiquetaTramite etiqueta); // Consultar trámites por etiqueta
    Tramite TramiteConsultaPorId(int id);
}
