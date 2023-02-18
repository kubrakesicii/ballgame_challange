using Business.Abstract;
using Business.Concrete;
using DataAccess.GenericRepository;
using DataAccess.UnitOfWork;

namespace API.Extension
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallServices(this IServiceCollection services)
        {
            // Add services to the container.
            //services.AddScoped<IServiceCollection, Service>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlayerService, PlayerService>();
            return services;
        }
    }
}
