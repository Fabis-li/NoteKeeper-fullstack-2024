using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NoteKeeper.Infra.Orm.Compartilhado
{
    public class NoteKeeperDbContextFactory : IDesignTimeDbContextFactory<NoteKeeperDbContext>
    {
        public NoteKeeperDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NoteKeeperDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new NoteKeeperDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}
