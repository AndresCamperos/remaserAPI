using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using remaserAPI.Data;
using remaserAPI.Data.Repositories;
using remaserAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace remaserAPI
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

            services.AddControllers();
            #region Connections
            //SQL Connection*
            services.AddDbContext<RemaserDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            //MySQL
            //services.AddDbContext<RemaserDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));
            #endregion
            #region Scopeds
            services.AddScoped<IPersonsHttpServices, PersonRepository>();
            services.AddScoped<IBuildingsHttpServices, BuildingRepository>();
            services.AddScoped<IUsersHttpServices, UserRepository>();
            #endregion
            #region JWT

            var secretkey = Configuration.GetValue<string>("SecretKey");
            var keyBytes = Encoding.UTF8.GetBytes(secretkey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;// https
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "remaserAPI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            #region Configuracion de CORS
            app.UseCors(options =>
            {
                options.WithOrigins("*");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            #endregion
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "remaserAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication(); //jwt
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
