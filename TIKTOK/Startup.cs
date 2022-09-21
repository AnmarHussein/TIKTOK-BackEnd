using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Domain;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;
using TIKTOK.Infra.Domain;
using TIKTOK.Infra.Repoisitory;
using TIKTOK.Infra.Service;

namespace TIKTOK
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Conction DataBase
            services.AddScoped<IDBContext, DBContext>();

            // Add Reposotriy Scoped
            services.AddScoped(typeof(IGenericRepoisitory<>), typeof(GenericRepoisitory<>));
            services.AddScoped<IAdminRepoisitory, AdminRepoisitory>();
            services.AddScoped< IProfileRepoisitory, ProfileRepoisitory>();
            services.AddScoped< IAuthenticationRepoisitory, AuthenticationRepoisitory>();
            services.AddScoped< IProfileUserRepoisitory, ProfileUserRepoisitory>();
            services.AddScoped<IHomePageRepoisitory, HomePageRepoisitory>();
            services.AddScoped<IContactUsRepoisitory, ContactUsRepoisitory>();
            services.AddScoped<ILiveRepoisitory, LiveRepoisitory>();


            // Add Serveis Scoped
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped< IAuthenticationService, AuthenticationService>();
            services.AddScoped< IProfileUserService, ProfileUserService>();
            services.AddScoped< IHomePageService, HomePageService>();
            services.AddScoped< IContactUsService, ContactUsServicecs>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILiveService, LiveService>();


            //JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "https://localhost:44307/",
                    ValidAudience = "https://localhost:44307/",
                };
            });


            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policy",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("policy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
