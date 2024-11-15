using Microsoft.AspNetCore.Identity;
using NoteKeeper.Dominio.ModuloAutenticacao;
using NoteKeeper.Infra.Orm.Compartilhado;
using NoteKeeper.WebApi.ModuloAutenticacao;

namespace NoteKeeper.WebApi.Identity;

public static class IdentityDependecyInjection
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddScoped<ServicoAutenticacao>();
        services.AddScoped<ITenantProvider, ApiTenantProvider>();

        services.AddIdentity<Usuario, Cargo>(options =>
        {
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<NoteKeeperDbContext>()
        .AddDefaultTokenProviders();
    }
}
