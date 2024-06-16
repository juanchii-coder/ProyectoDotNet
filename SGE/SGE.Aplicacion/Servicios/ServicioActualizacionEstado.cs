namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;

public class ServicioActualizacionEstado(ITramiteRepositorio repoTramite, IExpedienteRepositorio repoExpediente)
{
    public void ActualizarEstado(int idExpediente, int idUsuario)
    {
        var ultimoTramite = repoTramite.ListarTramites().Where(t => t.ExpedienteId == idExpediente).ToList().Last();
        var expediente = repoExpediente.ExpedienteConsultaPorId(idExpediente);
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
        repoExpediente.ExpedienteModificacion(idExpediente, expediente.Caratula, expediente.Estado, idUsuario);
    }
}
