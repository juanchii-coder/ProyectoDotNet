
using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;


var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
//servicios al contenedor
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramitePorEtiqueta>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpedienteTXT>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramiteTXT>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionProvisorio>();


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
