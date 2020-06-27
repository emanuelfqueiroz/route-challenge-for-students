using Microsoft.EntityFrameworkDomain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace TouristChallenge1.InfraStructure.DI
{
    public class Loader
    {
        internal static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IDocumentRepository, DocumentRepository>();
            //services.AddTransient<IDocumentService, DocumentService>();

            //services.AddScoped<ITouristRepository, TouristRepository>();
            //services.AddTransient<IDocumentStorage, FileSystemDocumentStorage>();

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddDbContext<TouristChallengeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
