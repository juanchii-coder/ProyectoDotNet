using SGE.Aplicacion;
using SGE.Repositorios;

// Generar Entidades: Expediente y Tramite
ITramiteRepositorio tramRepo = new RepositorioTramiteTXT();
IExpedienteRepositorio expRepo = new RepositorioExpedienteTXT();
ExpedienteValidador expVal = new ExpedienteValidador();

// Generar Servicios
IServicioAutorizacion auto = new ServicioAutorizacionProvisorio();
TramiteValidador val = new TramiteValidador();
ServicioActualizacionEstado servActualizacion = new ServicioActualizacionEstado(tramRepo,expRepo);



//usuarios
int idUsuario1 = 1;
int idUsuario2 = 2;
int idUsuarioNegativo = -1;

Console.WriteLine("Altas, Consultas, Modificaciones y Bajas - Efectivas");
Console.WriteLine();
try
{
    Expediente exp1 = GeneradorExpedientes.GenerarExpediente();
    Expediente exp2 = GeneradorExpedientes.GenerarExpediente();

    Tramite t1 = GeneradorTramites.GenerarEscritoPresentado(1);
    Tramite t2 = GeneradorTramites.GenerarEscritoPresentado(1);

    //testear Altas
    CasoDeUsoExpedienteAlta expCasoAlta = new CasoDeUsoExpedienteAlta(expRepo,auto,expVal);
    expCasoAlta.Ejecutar(exp1, idUsuario1, Permiso.ExpedienteAlta);
    expCasoAlta.Ejecutar(exp2, idUsuario1, Permiso.ExpedienteAlta);
    Console.WriteLine("Expedientes dados de alta");

    CasoDeUsoTramiteAlta tramCasoAlta = new CasoDeUsoTramiteAlta(tramRepo,auto,val,servActualizacion);
    tramCasoAlta.Ejecutar(t1,idUsuario1,Permiso.TramiteAlta);
    tramCasoAlta.Ejecutar(t2,idUsuario1,Permiso.TramiteAlta);
    Console.WriteLine("Tramites dados de alta");

    //testear Consultas (todos)
    CasoDeUsoExpedienteConsultaPorId expCasoConsulta = new CasoDeUsoExpedienteConsultaPorId(expRepo, expVal);
    Expediente expConsultado = expCasoConsulta.Ejecutar(1,idUsuario2);
    Console.WriteLine("Consulta del expediente 1 finalizada efectivamente: " + expConsultado);

    //testear Modificaciones
    expConsultado.Caratula = " - Caratula Modificada para este Expediente -";
    CasoDeUsoExpedienteModificacion expCasoModificacion = new CasoDeUsoExpedienteModificacion(expRepo,auto,expVal);
    expCasoModificacion.Ejecutar(expConsultado, idUsuario1, Permiso.ExpedienteModificacion);
    Console.WriteLine("Expediente modificado efectivamente");
    expConsultado = expCasoConsulta.Ejecutar(1,idUsuario2);
    Console.WriteLine("Consulta del expediente 1 finalizada efectivamente: " + expConsultado);
    
    CasoDeUsoTramitePorEtiqueta tramCasoConsultaEtiqueta= new CasoDeUsoTramitePorEtiqueta(tramRepo);
    List<Tramite> listaTramiteEtiqueta= tramCasoConsultaEtiqueta.Ejecutar(EtiquetaTramite.EscritoPresentado);
    foreach(Tramite tram in listaTramiteEtiqueta){
        Console.WriteLine(tram);
    }

    Tramite ultimoTramite= listaTramiteEtiqueta.Where(t=>t.ExpedienteId==1).Last();
    Console.WriteLine("ultimo Tramite");
    Console.WriteLine(ultimoTramite);
    ultimoTramite.Etiqueta=EtiquetaTramite.PaseAEstudio;
    CasoDeUsoTramiteModificacion tramCasoModificacion= new CasoDeUsoTramiteModificacion(tramRepo,auto,val,servActualizacion);
    tramCasoModificacion.Ejecutar(ultimoTramite,idUsuario1,Permiso.TramiteModificacion);
    Console.WriteLine("Modificacion de tramite finalizado");
    listaTramiteEtiqueta= tramCasoConsultaEtiqueta.Ejecutar(EtiquetaTramite.EscritoPresentado);
    /*foreach(Tramite tram in listaTramiteEtiqueta){
        Console.WriteLine(tram);
    }*/
    ultimoTramite= listaTramiteEtiqueta.Where(t=>t.ExpedienteId==1).Last();
    Console.WriteLine(ultimoTramite);

    //testear Bajas
    CasoDeUsoExpedienteBaja expCasoBaja = new CasoDeUsoExpedienteBaja(expRepo,auto,tramRepo);
    expCasoBaja.Ejecutar(0,idUsuario1,Permiso.ExpedienteBaja);
    Console.WriteLine("Expediente dado de baja Efectivamente - el expediente de id = 0 no debe estar en el archivo expedientes.txt");

    CasoDeUsoTramiteBaja tramCasoBaja = new CasoDeUsoTramiteBaja(tramRepo,auto);
    tramCasoBaja.Ejecutar(0,1,Permiso.TramiteBaja);
    Console.WriteLine("Tramite dado de baja Efectivamente - el tramite de id = 0 no debe estar en el archivo tramites.txt");

    //consuta de nuevo(todos)
    CasoDeUsoExpedienteConsultaTodos expCasoConsultaTodos = new CasoDeUsoExpedienteConsultaTodos(expRepo);
    List<Expediente> expedientes= expCasoConsultaTodos.Ejecutar();
    foreach (Expediente expediente in expedientes) {
        Console.WriteLine(expediente);
    }

    CasoDeUsoTramitePorEtiqueta tramCasoPorEtiqueta = new CasoDeUsoTramitePorEtiqueta(tramRepo);
    List<Tramite> tramites = tramCasoPorEtiqueta.Ejecutar(EtiquetaTramite.EscritoPresentado);
    foreach (Tramite tramite in tramites) {
        Console.WriteLine(tramite);
    }
    Console.WriteLine("Lista de tramites por etiqueta");

}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}
Console.WriteLine("-------------------------------------");
Console.WriteLine("");

Console.WriteLine("Tramites con contenido null o string vacio:");
Console.WriteLine();
try{
    Tramite t2Null = GeneradorTramites.GenerarTramiteContenidoNull(2);

     CasoDeUsoTramiteAlta tAlta1 = new CasoDeUsoTramiteAlta(tramRepo,auto,val,servActualizacion);
    tAlta1.Ejecutar(t2Null,idUsuario1,Permiso.TramiteAlta);

}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

try{
    Tramite t3Vacio = GeneradorTramites.GenerarTramiteContenidoVacio(2);

     CasoDeUsoTramiteAlta tAlta1 = new CasoDeUsoTramiteAlta(tramRepo,auto,val,servActualizacion);
    tAlta1.Ejecutar(t3Vacio,idUsuario1,Permiso.TramiteAlta);

}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

Console.WriteLine("----------------------------------");

Console.WriteLine("Error por Autorizacion");
Console.WriteLine();
try{
    Expediente expediente = GeneradorExpedientes.GenerarExpediente();
    CasoDeUsoExpedienteAlta expCasoAltaNoAutorizado = new CasoDeUsoExpedienteAlta(expRepo,auto,expVal);
    expCasoAltaNoAutorizado.Ejecutar(expediente,idUsuario2,Permiso.TramiteAlta);

}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

Console.WriteLine("----------------------------------");

Console.WriteLine("Error por Validacion - Tramite y Expediente");
Console.WriteLine();
try
{
    CasoDeUsoExpedienteConsultaPorId expCasoConsulta = new CasoDeUsoExpedienteConsultaPorId(expRepo, expVal);
    Expediente expConsultado = expCasoConsulta.Ejecutar(1,idUsuarioNegativo);

}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

Console.WriteLine("-------------------------------------");
Console.WriteLine("");

Console.WriteLine("Expedientes con caratula null o string vacio:");
Console.WriteLine();
try{
    Expediente expNull = GeneradorExpedientes.GenerarExpedienteCaratulaNull();
    CasoDeUsoExpedienteAlta expCasoAlta = new CasoDeUsoExpedienteAlta(expRepo,auto,expVal);
    expCasoAlta.Ejecutar(expNull,idUsuario1,Permiso.TramiteAlta);

}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

try{
    Expediente expVacio = GeneradorExpedientes.GenerarExpedienteCaratulaVacia();
    CasoDeUsoExpedienteAlta expCasoAlta = new CasoDeUsoExpedienteAlta(expRepo,auto,expVal);
    expCasoAlta.Ejecutar(expVacio,idUsuario1,Permiso.TramiteAlta);
    
}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}

Console.WriteLine("-------------------------------------");
Console.WriteLine("");

Console.WriteLine("Consultar Expediente con id no existente:");
Console.WriteLine();
try{
    // id = 999 no existe
    CasoDeUsoExpedienteConsultaPorId expCasoConsulta = new CasoDeUsoExpedienteConsultaPorId(expRepo, expVal);
    Expediente expConsultado = expCasoConsulta.Ejecutar(999,idUsuario1);

}catch(AutorizacionException au) {
    Console.WriteLine(au.Message);
}catch(RepositorioException re) {
    Console.WriteLine(re.Message);
}catch(ValidacionException va) {
    Console.WriteLine(va.Message);
}catch(Exception e) {
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}