using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RFID.Application.Abstractions;
using RFID.Domain.Entities;
using RFID.Infrastructure.Persistence;
using RFID.Infrastructure.Services;
using System.Security.Claims;
using System.Text;

namespace RFID.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IHashService, HashService>();
            services.AddScoped<ITokenService, JWTService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidAudience = configuration["JWTConfiguration:ValidAudience"],
                     ValidIssuer = configuration["JWTConfiguration:ValidIssuer"],
#pragma warning disable
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTConfiguration:Secret"]))
#pragma warning restore
                 };
             });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, nameof(RFIDAdmin));
                });
            });

            return services;
        }
    }
}