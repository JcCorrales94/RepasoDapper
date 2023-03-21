using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepasoDapper.Repositorie;
using RepasoDapper.Repositorie.Authors;
using RepasoDapper.Repositorie.Books;
using RepasoDapper.Servicies.Authors;
using RepasoDapper.Servicies.Books;
using RepasoDapper.Servicies.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Configuration
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureDataBase(this IServiceCollection services)
        {
           return services.AddDbContext<DatabaseContext>(options =>
             {
                 options.UseSqlServer("Data Source=PC-TORREPRINCIP\\SQLEXPRESS01;Integrated Security=True; Initial Catalog=EjercicioEFCore; TrustServerCertificate=True");
             });
        }
        public static IServiceCollection configureServices(this IServiceCollection services)
        {
            return services.AddSingleton<IInitDataBaseServices, InitDataBaseServices>()
                    .AddSingleton<IBooksServices, BooksServices>()
                    .AddSingleton<IAuthorsServices, AuthorsServices>();

        }
        public static IServiceCollection ConfigureRepositories (this IServiceCollection services)
        {
            return services.AddSingleton<IBooksRepository, BooksRepository>()
                           .AddSingleton<IAuthorsRepository, AuthorsRepository>();
        }
        public static IServiceCollection AddConfigurationConfigFile(this IServiceCollection services)
        {
            return services.AddTransient<IConfiguration>(sp =>
            {
                var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
                return configurationBuilder.Build();
            });
        }
    }
}
