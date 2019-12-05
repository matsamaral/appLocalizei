using System;
using System.Reflection;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Brinks.Compusafe.User.API.AutofacModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Internal;
using Localizei.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;


namespace Localizei.API
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Localizer API",
                    Description = "Projeto de API do APP Localizei",
                    Contact = new OpenApiContact
                    {
                        Name = "Mateus Amaral",
                        Email = "mateus.amaral98@hotmail.com",
                        Url = new Uri("https://twitter.com/matsamaral"),
                    }
                });
            });

            services.Configure<ImageStoreDatabaseSettings>(
                Configuration.GetSection(nameof(ImageStoreDatabaseSettings)));

            services.AddSingleton<IImageStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ImageStoreDatabaseSettings>>().Value);            
            
            services.Configure<RecogninSettings>(
                Configuration.GetSection(nameof(RecogninSettings)));

            services.AddSingleton<IRecogninSettings>(sp =>
                sp.GetRequiredService<IOptions<RecogninSettings>>().Value);

            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var container = new ContainerBuilder();

            container.Populate(services);
            container.RegisterModule<InfraModule>();
            container.RegisterModule<ServiceModule>();

            return new AutofacServiceProvider(container.Build());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_ => {
                _.AllowAnyOrigin();
                _.AllowAnyHeader();
                _.AllowAnyMethod();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Localizei API V1");
            });

            app.UseMvc();

        }
    }
}
