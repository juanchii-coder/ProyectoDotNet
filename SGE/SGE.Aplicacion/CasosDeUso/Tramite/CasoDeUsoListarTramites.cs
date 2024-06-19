namespace SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public class CasoDeUsoListarTramites(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar()
    {
        return repo.ListarTramites();
    }
}