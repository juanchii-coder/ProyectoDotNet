
namespace SGE.UI;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.Enumerativos;
using SGE.Repositorios;
public class Constructor
{
  ITramiteRepositorio? tramRepo;
  IExpedienteRepositorio? expRepo;
  ExpedienteValidador? expVal;
  IServicioAutorizacion? auto;
  TramiteValidador? val;
  ServicioActualizacionEstado? servActualizacion;
  int idUsuario1 = 1;

  Expediente? exp1;
  Expediente? exp2;

  Tramite? t1;
  Tramite? t2;

  CasoDeUsoExpedienteAlta? expCasoAlta;
  CasoDeUsoTramiteAlta? tramCasoAlta;
  public void Build()
  {

    tramRepo = new RepositorioTramiteTXT();
    expRepo = new RepositorioExpedienteTXT();
    expVal = new ExpedienteValidador();
    auto = new ServicioAutorizacionProvisorio();
    val = new TramiteValidador();
    servActualizacion = new ServicioActualizacionEstado(tramRepo, expRepo);

    exp1 = GeneradorExpedientes.GenerarExpediente();
    exp2 = GeneradorExpedientes.GenerarExpediente();

    t1 = GeneradorTramites.GenerarEscritoPresentado(1);
    t2 = GeneradorTramites.GenerarEscritoPresentado(1);

    expCasoAlta = new CasoDeUsoExpedienteAlta(expRepo, auto, expVal);
    tramCasoAlta = new CasoDeUsoTramiteAlta(tramRepo, auto, val, servActualizacion);

    expCasoAlta.Ejecutar(exp1, idUsuario1, Permiso.ExpedienteAlta);
    expCasoAlta.Ejecutar(exp2, idUsuario1, Permiso.ExpedienteAlta);

    tramCasoAlta.Ejecutar(t1, idUsuario1, Permiso.TramiteAlta);
    tramCasoAlta.Ejecutar(t2, idUsuario1, Permiso.TramiteAlta);
  }
}