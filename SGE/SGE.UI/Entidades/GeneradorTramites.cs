namespace SGE.UI;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public static class GeneradorTramites
{

    public static Tramite GenerarEscritoPresentado(int expId)
    {
        Tramite tramite = new Tramite();
        tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;
        tramite.Contenido = "Un contenido de Tramite";
        tramite.ExpedienteId = expId;
        return tramite;
    }

    public static Tramite GenerarTramiteContenidoNull(int expId)
    {
        Tramite tramite = new Tramite();
        tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;
        tramite.Contenido = null;
        tramite.ExpedienteId = expId;
        return tramite;
    }

    public static Tramite GenerarTramiteContenidoVacio(int expId)
    {
        Tramite tramite = new Tramite();
        tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;
        tramite.Contenido = "";
        tramite.ExpedienteId = expId;
        return tramite;
    }
}