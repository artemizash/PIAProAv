using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateCSharp.Data;
using TemplateCSharp.Data.Repositories;
using TemplateCSharp.Forms;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Services;

ApplicationConfiguration.Initialize();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile(
        "appsettings.json",
        optional: false,
        reloadOnChange: false)
    .Build();

ServiceCollection services = new();

services.AddSingleton(configuration);

services.AddTransient<DatabaseConnection>();
services.AddTransient<IUsuarioRepository, UsuarioRepository>();
services.AddTransient<IClienteRepository, ClienteRepository>();
services.AddTransient<IUsuarioService, UsuarioService>();
services.AddTransient<IClienteService, ClienteService>();
services.AddTransient<IAccesoService, AccesoService>();

services.AddTransient<FrmUsuarios>();
services.AddTransient<FrmClientes>();
services.AddTransient<FrmAcceso>();
services.AddTransient<FrmEstadios>();
services.AddTransient<FrmZonas>();
services.AddTransient<FrmAsientos>();
services.AddTransient<FrmEquipos>();
services.AddTransient<FrmPartidos>();
services.AddTransient<FrmVentas>();
services.AddTransient<FrmCancelaciones>();
services.AddTransient<FrmFacturas>();
services.AddTransient<FrmReporteVentas>();
services.AddTransient<FrmReporteOcupacion>();
services.AddTransient<FrmHistorialClientes>();
services.AddTransient<FrmPrincipal>();

using ServiceProvider serviceProvider =
    services.BuildServiceProvider();

FrmPrincipal form =
    serviceProvider.GetRequiredService<FrmPrincipal>();

Application.Run(form);
