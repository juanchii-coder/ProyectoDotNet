public class Usuario{
  public string? Id { get; set;}
  public string? Nombre { get; set;}
  public string? Apellido{ get; set;}
  public string? Email{ get; set;}
  public string? Contraseña{ get; set;}

  public List<bool> Permisos=new List<bool>{true,false,false,false};//1.poderVer, 2.poderEditar 3.poderEliminar 4.esAdmin
}