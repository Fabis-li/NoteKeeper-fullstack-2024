using NoteKeeper.Dominio.Compartilhado;
using NoteKeeper.Infra.Orm.Compartilhado;

namespace NoteKeeper.WebApi.Config
{
    public static class DbContextExtensions
    {
        public static bool AutoMigrateDataBase(this IApplicationBuilder app)
        {
            {
                using var scope = app.ApplicationServices.CreateScope();

                var dbCotnext = scope.ServiceProvider.GetRequiredService<IContextoPersistencia>();

                bool migracaoConcluida = false;

                if (dbCotnext is NoteKeeperDbContext dbContext)
                {
                   migracaoConcluida = MigradorBancoDados.AtualizarBancoDados(dbContext);
                }

                return migracaoConcluida;
            }
        }
    }
}
