using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PigeonPizza.Contexts;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;

namespace PigeonPizza
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IApplicationBuilder app, IWebHostEnvironment env)
        {
            Configuration = configuration;
            App = app;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IApplicationBuilder App { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var version = Configuration["Meta:Version"];
            var appname = Configuration["Meta:Name"];
            services.AddControllers();
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
        public void Configure()
        {
            if (Env.IsDevelopment())
            {
                App.UseDeveloperExceptionPage();
                App.UseSwagger();
                // Example endpoint: «/swagger/v1_0_0/swagger.json»
                App.UseSwaggerUI(c => c.SwaggerEndpoint(GetSwaggerEndpoint(), string.Concat(
                    Configuration["Meta:Name"].ToString(),
                    " ",
                    Configuration["Meta:Version"].ToString()))); // Example: «PigeonPizza v1.0.0»
            }

            App.UseHttpsRedirection();

            App.UseRouting();

            App.UseAuthorization();

            App.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Helpers
        public string GetSwaggerEndpoint()
        {
            string versionWithoutPoints = Configuration["Meta:Version"].ToString().Replace('.', '_');
            string fullname = string.Concat(
                Configuration["Meta:Name"].ToString(), 
                " ", 
                Configuration["Meta:Version"].ToString());
            return $"/swagger/{versionWithoutPoints}/swagger.json";
        }
        #endregion
    }
}
