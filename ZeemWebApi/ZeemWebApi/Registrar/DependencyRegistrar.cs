using Microsoft.EntityFrameworkCore;
using Zeem.Core.Data;
using Zeem.Core.Infrastructure;
using Zeem.Data;
using Microsoft.Extensions.DependencyInjection;
using Zeem.Service.Infrastructure;
using ZeemFacade.Infrastructure;

namespace ZeemWebApi.Registrar
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var zeemConfig = configuration.GetSection("ZeemConfigurations").Get<ZeemConfig>();
            // Register database
            var optionsBuilder = new DbContextOptionsBuilder<ZeemDbContext>();
            optionsBuilder.UseSqlServer(zeemConfig.ConnectionString);
            services.AddScoped<IDbContext>(context => new ZeemDbContext(optionsBuilder.Options));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            // Register Services
            services.Scan(scan => scan
                .FromAssemblyOf<IZeemRoleService>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            // Register Facade
            services.Scan(scan => scan
                .FromAssemblyOf<IZeemRoleFacade>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Facade")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            return services;
        }
    }
}
