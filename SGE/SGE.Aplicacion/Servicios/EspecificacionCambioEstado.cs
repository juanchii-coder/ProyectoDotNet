namespace SGE.Aplicacion;

public class EspecificacionCambioEstado
{
public EstadoExpediente ObtenerNuevoEstado(EtiquetaTramite nuevaEtiqueta)
        {
            switch (nuevaEtiqueta)
            {
                case EtiquetaTramite.Resolucion:
                    return EstadoExpediente.ConResolucion;
                case EtiquetaTramite.PaseAEstudio:
                    return EstadoExpediente.ParaResolver;
                case EtiquetaTramite.PaseAlArchivo:
                    return EstadoExpediente.Finalizado;
                default:
                    return EstadoExpediente.RecienIniciado;
            }
        }
}
