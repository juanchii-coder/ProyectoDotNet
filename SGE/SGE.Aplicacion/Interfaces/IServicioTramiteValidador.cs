namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface IServicioTramiteValidador
{
    bool ValidarTramite(int idusuario, Tramite tramite);
}
