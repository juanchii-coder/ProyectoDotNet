namespace SGE.Aplicacion;

public class CasoDeUsoTramitePorEtiqueta(ITramiteRepositorio repo){
  public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
  {
    return repo.TramitesPorEtiqueta(etiqueta);
  }
}