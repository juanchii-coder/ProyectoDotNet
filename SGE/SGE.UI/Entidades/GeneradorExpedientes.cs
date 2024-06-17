namespace SGE.UI;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

public static class GeneradorExpedientes
{

    public static Expediente GenerarExpediente()
    {
        Expediente expediente = new Expediente();
        expediente.Caratula = "Una caratula de Expediente";
        expediente.Estado = EstadoExpediente.RecienIniciado;
        return expediente;
    }

    public static Expediente GenerarExpedienteCaratulaNull()
    {
        Expediente expediente = new Expediente();
        expediente.Caratula = null;
        expediente.Estado = EstadoExpediente.RecienIniciado;
        return expediente;
    }

    public static Expediente GenerarExpedienteCaratulaVacia()
    {
        Expediente expediente = new Expediente();
        expediente.Caratula = "";
        expediente.Estado = EstadoExpediente.RecienIniciado;
        return expediente;
    }
}