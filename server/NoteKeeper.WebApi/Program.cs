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

            //Configuração de Injeção de Dependência
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

            //Middleware de execução da API
            var app = builder.Build();

            app.UseGlobalExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI();

            //Migrações de Banco de Dados
            var migracaoConcluida = app.AutoMigrateDataBase();

            if (migracaoConcluida) Log.Information("Migração do banco de dados concluída com sucesso");
            else Log.Error("Nenhuma migração pendente");

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
                Log.Fatal("Ocorreu um erro que ocasionou no fechamento da aplicação", ex);

                return;
            }
        }
    }
}
