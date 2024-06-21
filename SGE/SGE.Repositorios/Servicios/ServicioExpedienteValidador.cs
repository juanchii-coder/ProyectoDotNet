namespace SGE.Repositorios.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Repositorios.Configuracion;


public class ServicioExpedienteValidador : IServicioExpedienteValidador
{
    private readonly GestionExpedienteContext _contexto;

    public ServicioExpedienteValidador(GestionExpedienteContext context)
    {
        _contexto = context;
    }
    public bool ValidarExpediente(int idUsuario, Expediente expediente)
    {    
    var usuario = _contexto.Usuarios.Any(u => u.Id == idUsuario);
    return usuario && !string.IsNullOrEmpty(expediente.Caratula);
    }
    
}
