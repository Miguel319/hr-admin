using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using HR_Admin.Application.Departments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Admin_HR.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebAPIv5", Version = "v1"}); });

            services.AddDbContext<DataContext>(op =>
                op.UseSqlite(config.GetConnectionString(("DefaultConnection")))
            );

            services.AddCors(op =>
            {
                op.AddPolicy("CorsPolicy", policy =>
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("*")
                );
            });

            services.AddMediatR(typeof(List.Handler).Assembly);
            
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}