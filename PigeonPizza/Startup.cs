using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PigeonPizza.Contexts;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using PigeonPizza.Data;

namespace PigeonPizza
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var version = Configuration["Meta:Version"];
            var appname = Configuration["Meta:Name"];
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            #region custom services

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = appname, Version = version });
            });
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(appname);
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            // Example endpoint: �/swagger/v1.0.0/swagger.json�
            app.UseSwaggerUI(c => c.SwaggerEndpoint(GetSwaggerEndpoint(), string.Concat(
                Configuration["Meta:Name"].ToString(),
                " ",
                Configuration["Meta:Version"].ToString()))); // Example: �PigeonPizza v1.0.0�

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(ConfigureRoutes);

            // Seed Database
            SeedTheData(app);
        }

        #region Helpers

        private void SeedTheData(IApplicationBuilder app)
        {
            DbDataSeeder.SeedPrimitives(app);
            DbDataSeeder.SeedTemplates(app);
        }

        private void ConfigureRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
        }

        private string GetSwaggerEndpoint()
        {
            string versionWithoutPoints = Configuration["Meta:Version"].ToString();
            return $"/swagger/{versionWithoutPoints}/swagger.json";
        }
        #endregion
    }
}
