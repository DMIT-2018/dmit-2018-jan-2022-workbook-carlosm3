using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ChinookSystem.DAL;
using ChinookSystem.BLL;
#endregion

namespace ChinookSystem
{
    public static class ChinookExtensions
    {
        public static void ChinookSystemBackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            // Register the DbContext class in Chinook with the service collection
            services.AddDbContext<ChinookContext>(options);

            // Add any services that you can create in the class library
            // using .AddTransient<T>(...)

            // About Services
            services.AddTransient<AboutServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<ChinookContext>();
                // Create an instance of the service and return instance
                return new AboutServices(context);
            });

            // Genre Services
            services.AddTransient<GenreServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<ChinookContext>();
                // Create an instance of the service and return instance
                return new GenreServices(context);
            });

            // Album Services
            services.AddTransient<AlbumServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<ChinookContext>();
                // Create an instance of the service and return instance
                return new AlbumServices(context);
            });
        }
    }
}
