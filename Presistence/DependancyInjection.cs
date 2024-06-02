using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Presistence.Context;
using Presistence.Repositories;
using Presistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public static class DependancyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        { 

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName));
            });


            services.AddIdentity<AppUser, IdentityRole>()
                 .AddEntityFrameworkStores<AppIdentityDbContext>();


            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();



            services.AddScoped<IAttachmentGroupRepository, AttachmentGroupRepository>();
            services.AddScoped<IAttachmentGroupService, AttachmentGroupService>();


            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateIssuer = true,
                  ValidIssuer = configuration["JWT:VaildIssuer"],
                  ValidateAudience = true,
                  ValidAudience = configuration["JWT:VaildAudience"],
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
              });


            services.AddAuthorization();





        }
    }
}
