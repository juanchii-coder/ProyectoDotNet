namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface IServicioExpedienteValidador
{   
    bool ValidarExpediente(int idUsuario, Expediente expediente);
}
