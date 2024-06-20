namespace SGE.Repositorios.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Repositorios.Configuracion;


public class ServicioExpedienteValidador : IServicioExpedienteValidador
{
    private readonly GestionExpedienteContext contexto;

    public ServicioExpedienteValidador(GestionExpedienteContext context)
    {
        contexto = context;
    }
    public bool ValidarExpediente(int idUsuario, Expediente expediente)
    {    
    var usuario = contexto.Usuarios.Any(u => u.Id == idUsuario);
    return usuario && !string.IsNullOrEmpty(expediente.Caratula);
    }
    
}