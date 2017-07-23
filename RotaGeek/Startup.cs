using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using React.AspNet;
using RotaGeek.Configuration;
using RotaGeek.Providers;
using RotaGeek.Repository;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IFormValidationProvider, FormValidationProvider>();
            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
            services.AddTransient<IDocumentClient, DocumentClient>(provider =>
            {
                return new DocumentClient(new Uri(RotaGeekConstant.CosmoDbEndpoint),
                    RotaGeekConstant.CosmoDbPrimaryKey);
            });
            services.AddTransient<IDocumentDbRepository<ContactForm>, DocumentDbRepository<ContactForm>>(provider =>
            {
                var client = provider.GetRequiredService<IDocumentClient>();
                return new DocumentDbRepository<ContactForm>("Form", "FormCollection", client);
            });

            // Add framework services.
            services.AddReact();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseReact(config =>
            {
                config
                    .AddScript("~/Scripts/First.jsx")
                    .AddScript("~/Scripts/Second.jsx");
            });

            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute("default", "{controller=rotageek}/{action=index}"));
        }
    }
}
