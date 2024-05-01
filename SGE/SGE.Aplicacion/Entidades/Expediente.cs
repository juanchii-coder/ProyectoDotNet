namespace SGE.Aplicacion;

public class Expediente
{
  public int Id{get;set;}
  public String Caratula{get;set;}
  public DateTime FechaCreacion{get;set;}
  public DateTime UltimaModificacion{get;set;}
  public int IdUsuario{get;set;}//ultimo usuario que modifico el expediente
  public EstadoExpediente Estado{get;set;}

  public override string ToString(){
    return "";
  }
}
