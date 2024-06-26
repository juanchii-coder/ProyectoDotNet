namespace SGE.Repositorios.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Repositorios.Configuracion;

public class ServicioTramiteValidador : IServicioTramiteValidador
{
    private readonly GestionExpedienteContext contexto;

    public ServicioTramiteValidador(GestionExpedienteContext context)
    {
        contexto = context;
    }
    public bool ValidarTramite(int idUsuario, Tramite tramite)
    {
    var usuario = contexto.Usuarios.Any(u => u.Id == idUsuario);
    
    return usuario && !string.IsNullOrEmpty(tramite.Contenido);
    }
}