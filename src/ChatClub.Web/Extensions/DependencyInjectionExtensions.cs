
using ChatClub.Application.Services;
using ChatClub.Domain.Extension;
using ChatClub.Domain.Interfaces.Repositories;
using ChatClub.Domain.Interfaces.Services;
using ChatClub.Infrastructure.Context;
using ChatClub.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChatClub.Web.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddServiceInterfaces(this IServiceCollection services)
        {
            //scoped
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

        }

        public static void AddRepositoryInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString("DataContext")));
        }

        public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            AesExtension.Configure(configuration["AES:Key"], configuration["AES:IV"]);

            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["x-token"];
                        return Task.CompletedTask;
                    },
                };
            }); 
        }
    }
}