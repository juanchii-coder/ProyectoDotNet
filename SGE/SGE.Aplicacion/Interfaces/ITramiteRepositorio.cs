﻿namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public interface ITramiteRepositorio
{
    List<Tramite> ListarTramites();
    void TramiteAlta(Tramite tramite, int idUsuario); // Crear trámite
    void TramiteBaja(int id); // Eliminar trámite
    void TramiteModificacion(int id, Tramite tramite, int idUsuario); // Modificar trámite
    List<Tramite> TramitesPorEtiqueta(EtiquetaTramite etiqueta); // Consultar trámites por etiqueta
    Tramite? TramiteConsultaPorId(int id);
}
