using BidMatch.Application.Abstraction.Authentication;
using BidMatch.Application.Abstraction.Clock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BidMatch.Domain.Users.Entities;
using BidMatch.Infrastructure.Authentication;
using BidMatch.Infrastructure.Clock;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BidMatch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        AddPersistence(services, configuration);

        AddAuthentication(services, configuration);

        //AddAuthorization(services);

        AddHealthChecks(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ??
                               throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        //services.AddScoped<IUserRepository, UserRepository>();

        //services.AddScoped<IApartmentRepository, ApartmentRepository>();

        //services.AddScoped<IBookingRepository, BookingRepository>();

        //services.AddScoped<IReviewRepository, ReviewRepository>();
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        //services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));
        //services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddHttpContextAccessor();

        services.AddScoped<IUserContext, UserContext>();
    }

    private static void AddHealthChecks(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddSqlServer(
                configuration.GetConnectionString("Database"), // Get the connection string for the SQL Server database
                name: "SQL Server", // Optional: Specify a custom name for the check
                failureStatus: HealthStatus.Unhealthy, // Set the failure status if the check fails
                tags: new[] { "db", "sql" } // Optional: Assign tags for grouping
            );
    }
}