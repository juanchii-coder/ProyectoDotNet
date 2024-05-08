namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool EsTramiteValido(int idUsuario, Tramite tramite) {
        return (idUsuario > 0) && (tramite.Contenido != null) && (tramite.Contenido != "");
    }
}
