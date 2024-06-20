
using SGE.UI.Components;
using SGE.UI.Entidades;
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Repositorios.Servicios;
using SGE.Repositorios.Configuracion;


var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//agrego servicios y validadores al contenedor
InicializadorPermisos a = new InicializadorPermisos();
a.Inicializar();
builder.Services.AddScoped<GestionExpedienteContext>();
builder.Services.AddTransient<ServicioActualizacionEstado>();
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramitePorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoListarTramites>();
builder.Services.AddTransient<CasoDeUsoLogin>();
builder.Services.AddTransient<CasoDeUsoObtenerTodosLosUsuarios>();
builder.Services.AddTransient<CasoDeUsoObtenerUsuarioPorId>();
builder.Services.AddTransient<CasoDeUsoOtorgarPermisos>();
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddScoped<IServicioCodificacion, ServicioCodificacion>();
builder.Services.AddScoped<IServicioTramiteValidador, ServicioTramiteValidador>();
builder.Services.AddScoped<IServicioExpedienteValidador, ServicioExpedienteValidador>();
builder.Services.AddScoped<IServicioUsuarioValidador, ServicioUsuarioValidador>();
builder.Services.AddScoped<IServicioAutentificador, ServicioAutentificador>();
builder.Services.AddScoped<IServicioPermiso, ServicioPermiso>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpediente>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<IPermisosRepositorio, PermisosRepositorio>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramite>();
builder.Services.AddTransient<EstadoDeUsuario>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
