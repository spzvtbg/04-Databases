namespace ProductShop.Services
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Services.Contracts;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiseBuilder
    {
        public static TService GetProvider<TService>()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<ProductShopDbContext>(c => c.UseSqlServer(ConnectionProvider.Connection));

            // Common context connection
            //services.AddDbContext<ProductShopDbContext>(c => c.UseSqlServer(ConnectionProvider.Common));

            services.AddTransient<JsonService>();

            services.AddAutoMapper(p => p.AddProfile<AutoMapperProfile>());

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetService<TService>();
        }
    }
}
