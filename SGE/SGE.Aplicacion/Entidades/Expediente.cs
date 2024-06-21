namespace SGE.Aplicacion.Entidades;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SGE.Aplicacion.Enumerativos;

public class Expediente
{
  public int Id { get; set; }
  public String? Caratula { get; set; }
  public DateTime FechaCreacion { get; set; }
  public DateTime UltimaModificacion { get; set; }
  public int IdUsuarioModificacion { get; set; }//ultimo usuario que modifico el expediente
  public EstadoExpediente Estado { get; set; }

  public override string ToString()
  {
    return $@"
    Expedeinte N°{Id} 
    Caratula: {Caratula}
    Fecha de Creacion: {FechaCreacion}
    Fecha de la Ultima Modificacion: {UltimaModificacion}
    Modificado por: {IdUsuarioModificacion}
    Estado del Expediente: {Enum.GetName(typeof(EstadoExpediente), Estado)}
    ";
  }
}
