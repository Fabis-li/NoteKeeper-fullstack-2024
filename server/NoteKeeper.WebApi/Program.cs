using NoteKeeper.WebApi.Config;
using NoteKeeper.WebApi.Identity;
using Serilog;

namespace NoteKeeper.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string politicaCors = "_minhaPoliticaCors";

            //Configura��o de Inje��o de Depend�ncia
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddUserSecrets<Program>();

           builder.Services.ConfigureDbContext(builder.Configuration);

            builder.Services.ConfigureCoreServices();

            builder.Services.ConfigureAutoMapper();

            builder.Services.ConfigureSerilog(builder.Logging, builder.Configuration);

            builder.Services.ConfigureIdentity();

            builder.Services.ConfigureControllerWithFilters();

            builder.Services.ConfigureCors(politicaCors);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();            

            //Middleware de execu��o da API
            var app = builder.Build();

            app.UseGlobalExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI();

            //Migra��es de Banco de Dados
            var migracaoConcluida = app.AutoMigrateDataBase();

            if (migracaoConcluida) Log.Information("Migra��o do banco de dados conclu�da com sucesso");
            else Log.Error("Nenhuma migra��o pendente");

            app.UseHttpsRedirection();

            app.UseCors(politicaCors);

            app.UseAuthorization();

            app.MapControllers();


            try
            {

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal("Ocorreu um erro que ocasionou no fechamento da aplica��o", ex);

                return;
            }
        }
    }
}
