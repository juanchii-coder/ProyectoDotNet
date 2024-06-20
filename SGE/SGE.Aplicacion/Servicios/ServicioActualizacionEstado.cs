namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;

public class ServicioActualizacionEstado(ITramiteRepositorio repoTramite, IExpedienteRepositorio repoExpediente)
{
    public void ActualizarEstado(int idExpediente, int idUsuario)
    {
        var ultimoTramite = repoTramite.ListarTramites().Where(t => t.ExpedienteId == idExpediente).ToList().Last();
        var expediente = repoExpediente.ExpedienteConsultaPorId(idExpediente);
        if(expediente != null) {
            EspecificacionCambioEstado.CambiarEstado(expediente, ultimoTramite);
            repoExpediente.ExpedienteModificacion(idExpediente, expediente, idUsuario);
        }
    }
}
