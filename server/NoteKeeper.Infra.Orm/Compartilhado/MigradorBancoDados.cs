using Microsoft.EntityFrameworkCore;

namespace NoteKeeper.Infra.Orm.Compartilhado
{
    public static class MigradorBancoDados
    {
        public static bool AtualizarBancoDados(DbContext dbContext)
        {
           var qtdMigracoesPendets =  dbContext.Database.GetPendingMigrations().Count();

           if(qtdMigracoesPendets == 0) return false;

            dbContext.Database.Migrate();

            return true;
        }
    }
}
