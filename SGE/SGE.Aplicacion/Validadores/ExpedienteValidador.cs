namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool EsExpedienteValido(int idUsuario, Expediente expediente) {
        return (idUsuario > 0) && (expediente.Caratula != null) && (expediente.Caratula != "");
    }
}
