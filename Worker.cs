namespace variables_entorno;
using Microsoft.Extensions.Options;
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;
    private readonly PositionOptions _positionOptions;

    public Worker(ILogger<Worker> logger, IConfiguration configuration, IOptions<PositionOptions> positionOptions)
    {
        _logger = logger;
        _configuration = configuration;
        _positionOptions = positionOptions.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            string user = _configuration.GetSection("ApiAmazon")["user"];
            string password = _configuration.GetSection("ApiAmazon")["password"];
            // password es una variable de entorno
            
            _logger.LogInformation($"Usuario: {user}, Password: {password}");
            _logger.LogInformation(_positionOptions.ToString());
            await Task.Delay(1000, stoppingToken);
        }
    }
}
