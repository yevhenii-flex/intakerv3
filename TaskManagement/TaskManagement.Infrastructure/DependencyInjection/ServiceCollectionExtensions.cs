using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<TaskDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}