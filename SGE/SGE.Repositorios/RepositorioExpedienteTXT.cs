﻿using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
  readonly string _nombreArch="expedientes.txt";
  public void ExpedienteAlta(Expediente expediente,int idUsuario)
  {
    int nuevoId=ObtenerUltimoId();
    expediente.Id=nuevoId;
    expediente.FechaCreacion=DateTime.Now;
    expediente.UltimaModificacion=DateTime.Now;
    expediente.IdUsuario=idUsuario;
    expediente.Estado=EstadoExpediente.RecienIniciado;

    using var sw = new StreamWriter(_nombreArch, true);
    sw.WriteLine(expediente.Id);
    sw.WriteLine(expediente.Caratula);
    sw.WriteLine(expediente.FechaCreacion);
    sw.WriteLine(expediente.UltimaModificacion);
    sw.WriteLine(expediente.IdUsuario);
    sw.WriteLine(expediente.Estado);
  }

  public void ExpedienteBaja(int id)
  {
    var expediente = ListarExpediente();
    var expedienteEliminar = expediente.Find(p => p.Id == id);
    if (expedienteEliminar != null)
    {
      expediente.Remove(expedienteEliminar);

      ReescribirArchivo(expediente);
    }
  }

  public void ExpedienteModificacion(int id,string caratula,int idUsuario)
  {
    var expediente = ListarExpediente();
    var index = expediente.FindIndex(e => e.Id == id);
    if (index >= 0)
    {
      expediente[index].Caratula=caratula;
      expediente[index].IdUsuario=idUsuario;
      expediente[index].UltimaModificacion=DateTime.Now;

      ReescribirArchivo(expediente);
    }
  }

  public void ExpedienteConsultaPorId(int id)
  {
    List<Expediente> expediente=ListarExpediente();
    var index = expediente.FindIndex(e => e.Id == id);
    
    expediente[index].ToString();

  }

  public void ExpedienteConsultaTodos()
  {
    List<Expediente> expediente=ListarExpediente();
    foreach (var e in expediente)
    {
      e.ToString();
    }
  }

  private List<Expediente> ListarExpediente(){
    var resultado=new List<Expediente>();
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      var expediente=new Expediente();
      expediente.Id = int.Parse(sr.ReadLine() ?? "");
      expediente.Caratula=sr.ReadLine()?? "";
      expediente.FechaCreacion=DateTime.Parse(sr.ReadLine()?? "");
      expediente.UltimaModificacion=DateTime.Parse(sr.ReadLine()?? "");
      expediente.IdUsuario = int.Parse(sr.ReadLine() ?? "");
      expediente.Estado=(EstadoExpediente)Enum.Parse(typeof(EstadoExpediente),(sr.ReadLine()?? ""));
    }
    return resultado;
  }

  private int ObtenerUltimoId()
  {
    if (!File.Exists(_nombreArch))
      return 0; // Si el archivo no existe, comenzamos desde 0
            
    int ultimoId = 0;
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      ultimoId = int.Parse(sr.ReadLine() ?? "0");
      // Saltar nombre y precio
      sr.ReadLine(); 
      sr.ReadLine();
      sr.ReadLine();
      sr.ReadLine();
      sr.ReadLine();
    }
    return ultimoId;
  }

  private void ReescribirArchivo(List<Expediente> expediente)
  {
    using var sw = new StreamWriter(_nombreArch, false);
    foreach (var e in expediente)
    {
      sw.WriteLine(e.Id);
      sw.WriteLine(e.Caratula);
      sw.WriteLine(e.FechaCreacion);
      sw.WriteLine(e.UltimaModificacion);
      sw.WriteLine(e.IdUsuario);
      sw.WriteLine(e.Estado);
    }
  }
}
