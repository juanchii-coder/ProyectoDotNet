namespace SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio repo)
{
    public Tramite? Ejecutar(int id)
    {
        return repo.TramiteConsultaPorId(id);
    }
}