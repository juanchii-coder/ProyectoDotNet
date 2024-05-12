namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(ITramiteRepositorio repoTramite,IExpedienteRepositorio repoExpediente,EspecificacionCambioEstado especificacionCambioEstado)
{
   public void ActualizarEstado(int idExpediente)
        {
            var ultimoTramite = repoTramite.ConsultaPorId(idExpediente);
            var nuevaEtiqueta = especificacionCambioEstado.ObtenerNuevaEtiqueta(ultimoTramite.ExpedienteId);

            var expediente = repoExpediente.ConsultaPorId(idExpediente);
            expediente.Estado = especificacionCambioEstado.ObtenerNuevoEstado(nuevaEtiqueta);
            repoExpediente.ExpedienteModificacion(expediente);
        }
}
