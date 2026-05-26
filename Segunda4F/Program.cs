using Microsoft.EntityFrameworkCore;
using Segunda4F.Components;
using Segunda4F.Data;
using Segunda4F.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DirectorioDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection")));

builder.Services.AddScoped<
    IRepositorioClientes,
    RepositorioClientes>();

builder.Services.AddScoped<
    IRepositorioIntereses,
    RepositorioIntereses>();

builder.Services.AddScoped<
    IRepositorioTipoClientes,
    RepositorioTipoClientes>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context =
        scope.ServiceProvider
        .GetRequiredService<DirectorioDBContext>();

    context.Database.EnsureCreated();

    if (!context.TipoClientes.Any())
    {
        context.TipoClientes.AddRange(
            new TipoCliente
            {
                Nombre = "Frecuente"
            },
            new TipoCliente
            {
                Nombre = "Nuevo"
            },
            new TipoCliente
            {
                Nombre = "Premium"
            });

        context.SaveChanges();
    }

    if (!context.Intereses.Any())
    {
        context.Intereses.AddRange(
            new Interes
            {
                Nombre = "Tecnología"
            },
            new Interes
            {
                Nombre = "Deportes"
            },
            new Interes
            {
                Nombre = "Videojuegos"
            });

        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        "/Error",
        createScopeForErrors: true);

    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();