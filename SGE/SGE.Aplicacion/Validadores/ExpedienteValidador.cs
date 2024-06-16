namespace SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Entidades;

public class ExpedienteValidador
{
    public bool EsExpedienteValido(int idUsuario, Expediente expediente)
    {
        return (idUsuario > 0) && (expediente.Caratula != null) && (expediente.Caratula != "");
    }
}
