﻿namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Validadores;
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo, ExpedienteValidador val)
{
  private const string ERROR_MESSAGE = "Error en la Consulta - ";
  public Expediente Ejecutar(int idExpediente, int idUsuario)
  {
    Expediente expediente = repo.ExpedienteConsultaPorId(idExpediente);
    if (expediente == null)
    {
      throw new RepositorioException(ERROR_MESSAGE + $"Expediente {idExpediente} No Existe");
    }
    if (!val.EsExpedienteValido(idUsuario, expediente))
    {
      throw new ValidacionException(ERROR_MESSAGE + $"id de usuario = {idUsuario} debe ser > 0");
    }
    return expediente;
  }
}
