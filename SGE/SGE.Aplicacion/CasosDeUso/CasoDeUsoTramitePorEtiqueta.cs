namespace SGE.Aplicacion;

public class TramitePorEtiqueta(ITramiteRepositorio repo){
public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
  {
        return repo.TramitePorEtiqueta(etiqueta);
  }
}