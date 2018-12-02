namespace Emploies.Application.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Emploies.Data;
    using Emploies.Services;
    using Emploies.Connection;

    internal static class CommonService 
    {
        public static TService GetProvider<TService>()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmploiesContext>(c => c.UseSqlServer(ConnectionStrings.Own));

            serviceCollection.AddTransient<EmploiesService>(); // IService, EmploiesService

            serviceCollection.AddAutoMapper(c => c.AddProfile<MappingProfile>());

            ServiceProvider provider =  serviceCollection.BuildServiceProvider();

            var service = provider.GetService<TService>();
            return service;
        }
    }
}
