using Serilog;

namespace NoteKeeper.WebApi.Config;

public static class SerilogConfigExtensions
{
    public static void ConfigureSerilog(this IServiceCollection services, ILoggingBuilder logging)
    {
        //configuração do serilog
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        //limpa  o log da microsoft
        logging.ClearProviders();

        //cria um novo serviço de log
        services.AddLogging(builder => builder.AddSerilog(dispose: true));
    }
}
