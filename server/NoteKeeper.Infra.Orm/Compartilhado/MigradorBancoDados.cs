using Microsoft.EntityFrameworkCore;

namespace NoteKeeper.Infra.Orm.Compartilhado
{
    public static class MigradorBancoDados
    {
        public static bool AtualizarBancoDados(DbContext dbContext)
        {
           var qtdMigracoesPendets =  dbContext.Database.GetPendingMigrations().Count();

            if(qtdMigracoesPendets == 0)
            {
                Console.WriteLine("Nenhuma migração pendente, continuando...");

                return false;
            }

            Console.WriteLine("Aplicando migrações pendentes, isso pode demorar alguns segundos...");

            dbContext.Database.Migrate();

            return true;
        }
    }
}
