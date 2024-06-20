using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Servicios;

public class EspecificacionCambioEstado
{
    public static Expediente CambiarEstado(Expediente expediente, Tramite ultimoTramite) {
        switch (ultimoTramite.Etiqueta)
        {
            case EtiquetaTramite.Resolucion:
                expediente.Estado = EstadoExpediente.ConResolucion;
                break;
            case EtiquetaTramite.PaseAEstudio:
                expediente.Estado = EstadoExpediente.ParaResolver;
                break;
            case EtiquetaTramite.Notificacion:
                expediente.Estado = EstadoExpediente.EnNotificacion;
                break;
            case EtiquetaTramite.PaseAlArchivo:
                expediente.Estado = EstadoExpediente.Finalizado;
                break;
        }
        return expediente;
    }
}
