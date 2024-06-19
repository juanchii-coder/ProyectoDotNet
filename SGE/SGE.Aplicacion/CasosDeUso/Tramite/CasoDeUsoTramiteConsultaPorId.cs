namespace SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio repo,CasoDeUsoListarTramites listarTramites)
{
    public Tramite Ejecutar(int id)
    {
        List<Tramite> tramites=listarTramites.Ejecutar();
        Tramite? tramite=tramites.Where(t=>t.Id==id).FirstOrDefault();
        return tramite;
    }
}