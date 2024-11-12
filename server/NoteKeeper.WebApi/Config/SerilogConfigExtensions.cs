using Serilog;

namespace NoteKeeper.WebApi.Config;

public static class SerilogConfigExtensions
{
    public static void ConfigureSerilog(this IServiceCollection services, ILoggingBuilder logging)
    {
        //configuração do serilog
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithClientIp()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()            
            .WriteTo.Console()
            .WriteTo.NewRelicLogs(
                endpointUrl: "https://log-api.newrelic.com/log/v1",
                applicationName: "note-keeper-api",
                licenseKey: "335d8aedf96a01d0c30e957b9fd733c4FFFFNRAL"
            )
            .CreateLogger();

        //limpa  o log da microsoft
        logging.ClearProviders();

        //cria um novo serviço de log
        services.AddLogging(builder => builder.AddSerilog(dispose: true));
    }
}
