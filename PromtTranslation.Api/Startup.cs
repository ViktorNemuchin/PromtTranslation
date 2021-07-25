using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromtTranslation.Services.Interface;
using PromtTranslation.Services.Implementation;
using PromtTranslation.Dtl.Context;
using PromtTranslation.Dtl.UnitOfWowrk.Implementation;
using PromtTranslation.Dtl.UnitOfWowrk.Interface;
using PromtTranslation.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using PromtTranslation.Domain.Dto;
using System.Net.Http;

namespace PromtTranslation.Api
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
            var customConfiguration = Configuration.Get<DbConfigurationDto>();
            services.AddControllers();
            services.AddHttpClient();
            services.AddScoped<ITranslationService,TranslationService>(
                x => new TranslationService(x.GetRequiredService<ITranslatioonUnitOfWork>(),
                x.GetRequiredService<HttpClient>(),
                x.GetRequiredService<ILoggerFactory>(),
                customConfiguration.PromtUrl));
            services.AddScoped<ITranslatioonUnitOfWork, TranslationUnitOfWork>();
            services.AddDbContext<TranslationDbContext>(options =>
            {
                OptionsHelper.SetConnectionString(customConfiguration.DbType, options, Configuration);
                options.EnableSensitiveDataLogging();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PromtTranslation.Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TranslationDbContext>();
                context.Database.Migrate();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PromtTranslation.Api v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
