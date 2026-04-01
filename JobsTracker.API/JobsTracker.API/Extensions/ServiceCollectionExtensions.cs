using JobsTracker.Application.Interfaces;
using JobsTracker.Application.UseCases;
using JobsTracker.Domain.Interfaces;
using JobsTracker.Infrastructure.Authentication;
using JobsTracker.Infrastructure.Persistence;
using JobsTracker.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobsTracker.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<INoteService, NoteService>();

            // Auth helpers
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
