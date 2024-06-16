using SGE.UI.Components;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;


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
builder.Services.AddTransient<CasoDeUsoTramiteModificaion>();
builder.Services.AddTransient<CasoDeUsoTramitePorEtiqueta>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpediente>();
builder.Services.AddScoped<ITramiteRepositorio, Repositoriotramite>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionProvisorio>();

using (var scope = app.Services.CreateScope())
{
    var constructorInstance = new Constructor();
    constructorInstance.Build();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
