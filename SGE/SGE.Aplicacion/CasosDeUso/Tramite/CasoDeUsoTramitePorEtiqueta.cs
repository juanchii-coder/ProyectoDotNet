namespace SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoTramitePorEtiqueta(ITramiteRepositorio repo)
{
  public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
  {
    return repo.TramitesPorEtiqueta(etiqueta);
  }
}