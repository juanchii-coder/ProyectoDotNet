﻿namespace SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo, IServicioExpedienteValidador val)
{
  private const string ERROR_MESSAGE = "Error en la Consulta - ";
  public Expediente Ejecutar(int idExpediente, int idUsuario)
  {
    Expediente? expediente = repo.ExpedienteConsultaPorId(idExpediente);
    if (expediente == null)
    {
      throw new RepositorioException(ERROR_MESSAGE + $"Expediente {idExpediente} No Existe");
    }
    if (!val.ValidarExpediente(idUsuario, expediente))
    {
      throw new ValidacionException(ERROR_MESSAGE + $"id de usuario = {idUsuario} debe ser > 0");
    }
    return expediente;
  }
}
