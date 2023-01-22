﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeem.Core.Data;
using Zeem.Core.Infrastructure;
using Zeem.Data;
using Zeem.Service.Infrastructure;
using ZeemFacade.Framework;
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

            //find mapper configurations provided by other assemblies
            var type = typeof(IOrderedMapperProfile);
            var mapperConfigurations = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName.StartsWith("Zeem"))
                .SelectMany(s => s.GetTypes().Where(x => x.IsClass && !x.IsAbstract))
                .Where(p => type.IsAssignableFrom(p));
            //create and sort instances of mapper configurations
            var instances = mapperConfigurations
                .Select(mapperConfiguration => (IOrderedMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                }

            });

            //register
            AutoMapperConfiguration.Init(config);

            return services;
        }
    }
}
