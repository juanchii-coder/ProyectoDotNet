
using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso.Expediente;
using SGE.Aplicacion.CasosDeUso.Tramite;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;


var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//agrego servicios y validadores al contenedor
builder.Services.AddTransient<ExpedienteValidador>();
builder.Services.AddTransient<TramiteValidador>();
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
builder.Services.AddTransient<CasoDeUsoListarTramites>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpediente>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramite>();

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
