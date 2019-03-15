using System;
using Microsoft.Extensions.DependencyInjection;
using NgCoreCRUD.Data;
using NgCoreCRUD.Model.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;


namespace NgCoreCRUD.IoC
{
    public static class Config
    {
        public static void Bind(IServiceCollection services, IConfiguration configuration)
        {
            Action<InMemoryDbContextOptionsBuilder> nop = ax => { };
            services.AddDbContext<GalleryDbContext>(opt => opt.UseInMemoryDatabase("GalleryDb", nop));
            services.Add(new ServiceDescriptor(typeof(IGalleryService), typeof(GalleryServiceFake), ServiceLifetime.Singleton));

            // services.AddDbContext<GalleryDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("GalleryDB"), options => options.CommandTimeout(120)));
            // services.Add(new ServiceDescriptor(typeof(IGalleryService), typeof(GalleryService), ServiceLifetime.Scoped));
        }
    }
}
