using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.Infra.Orm.Compartilhado;

namespace NoteKepper.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var novaCategoria = new Categoria("Mercado");

        var optionsBuilder = new DbContextOptionsBuilder<NoteKeeperDbContext>();

        var configuracao = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuracao.GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        var dbContext = new NoteKeeperDbContext(optionsBuilder.Options);

        dbContext.Add(novaCategoria);

        dbContext.SaveChanges();
    }
}