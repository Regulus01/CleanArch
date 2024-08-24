using CleanArchMvc.Application.Interface;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });

        AddRepositories(services);
        AddServices(services);
        AddMappers(services);
        AddMediatr(services);

    }

    private static void AddMediatr(IServiceCollection services)
    {
        services.AddMediatR(config =>
        { 
            config.RegisterServicesFromAssemblies(typeof(GetProductByIdQuery).Assembly);
            config.RegisterServicesFromAssemblies(typeof(GetProductsQuery).Assembly);
            
            config.RegisterServicesFromAssemblies(typeof(ProductCreateCommand).Assembly);
            config.RegisterServicesFromAssemblies(typeof(ProductRemoveCommand).Assembly);
            config.RegisterServicesFromAssemblies(typeof(ProductUpdateCommand).Assembly);
        });
    }
    
    private static void AddMappers(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        services.AddAutoMapper(typeof(DtoToCommandMappingProfile));
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}