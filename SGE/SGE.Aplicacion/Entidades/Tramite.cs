namespace SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

public class Tramite
{
  public int Id { get; set; }
  public int ExpedienteId { get; set; }
  public EtiquetaTramite Etiqueta { get; set; }
  public string? Contenido { get; set; }
  public DateTime FechaCreacion { get; set; }
  public DateTime UltimaModificacion { get; set; }
  public int IdUsuarioUltimaModificacion { get; set; }

  public override string ToString()
  {
    return $@"
    Trámite N°{Id} 
    Expediente asociado: {ExpedienteId}
    Etiqueta: {Etiqueta}
    Contenido: {Contenido}
    Fecha de Creación: {FechaCreacion}
    Fecha de la Última Modificación: {UltimaModificacion}
    Modificado por el usuario con ID: {IdUsuarioUltimaModificacion}
    ";
  }
}
