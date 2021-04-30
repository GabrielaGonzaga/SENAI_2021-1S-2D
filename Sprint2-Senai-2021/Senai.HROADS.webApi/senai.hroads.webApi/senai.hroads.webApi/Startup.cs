using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai.hroads.webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Add o serviço swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "senai.hraods.webApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });


            services
                //Forma de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                //Definição dos parâmetros

                .AddJwtBearer("JwtBearer", options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         //quem esta solicitando a ação
                         ValidateIssuer = true,

                         //quem esta recebendo a ação
                         ValidateAudience = true,

                         //tempo de expiração
                         ValidateLifetime = true,

                         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Semprepea10_usuarios")),

                         //twmpo de expiração
                         ClockSkew = TimeSpan.FromMinutes(45),

                         //Nome do issuer, de onde está vindo 
                         ValidIssuer = "Inlock.webApi",

                         //nome do audience, para aonde vai
                         ValidAudience = "Inlock.webApi"
                     };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "senai.hroads.webApi");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}
