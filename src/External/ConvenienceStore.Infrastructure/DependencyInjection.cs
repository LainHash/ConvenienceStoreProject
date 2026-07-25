using ConvenienceStore.Application.Services.Authentication;
using ConvenienceStore.Application.Services.Storage;
using ConvenienceStore.Contract.Settings.Authentication;
using ConvenienceStore.Contract.Settings.Storage;
using ConvenienceStore.Infrastructure.Services.Authentication;
using ConvenienceStore.Infrastructure.Services.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ConvenienceStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // ── Cloudinary ───────────────────────────────────────────────────
            services.Configure<CloudinarySettings>(
                configuration.GetSection(CloudinarySettings.SectionName));
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            // ── Authentication & Security ────────────────────────────────────
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            //services.AddScoped<IEmailService, EmailService>();

            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            if (jwtSettings is not null)
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });
            }

            return services;
        }
    }
}
