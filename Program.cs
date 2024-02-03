using variables_entorno;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        
        services.AddHostedService<Worker>();
        services.Configure<PositionOptions>(
            configuration.GetSection("Position")
        );
    })
    .Build();

await host.RunAsync();
