namespace SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Entidades;

public class TramiteValidador
{
    public bool EsTramiteValido(int idUsuario, Tramite tramite)
    {
        return (idUsuario > 0) && (tramite.Contenido != null) && (tramite.Contenido != "");
    }
}
