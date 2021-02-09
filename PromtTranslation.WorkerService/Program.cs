using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz.Core;
using Quartz;
using System.Net.Http;
using PromtTranslation.WorkerService.Extensions;
using PromtTranslation.Dtl.UnitOfWowrk.Interface;
using PromtTranslation.Dtl.UnitOfWowrk.Implementation;
using PromtTranslation.Dtl.Context;
using PromtTranslation.Services.Implementation;
using PromtTranslation.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PromtTranslation.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddScoped<ITranslationService, TranslationService>();
                    services.AddScoped<ISendTranslationService, SendTranslationService>();
                    var conString = hostContext.Configuration.GetSection("ConnectionString").GetChildren();
                    services.AddDbContext<TranslationDbContext>(options =>
                    {
                        options.UseNpgsql(hostContext.Configuration.GetConnectionString("PromtDb"),
                            npsqlOptions => npsqlOptions.MigrationsAssembly("PromtTranslation.Api"));
                        options.EnableSensitiveDataLogging();
                    });
                    services.AddScoped<TranslationDbContext>();
                    services.AddScoped<ITranslatioonUnitOfWork, TranslationUnitOfWork>();
                    services.AddQuartz(q =>
                    {
                        // Use a Scoped container to create jobs. I'll touch on this later
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();
                        q.AddJobAndTrigger<PromtTranslationJob>(hostContext.Configuration);
                        q.AddJobAndTrigger<SendTranslationJob>(hostContext.Configuration); 
                    });
                    services.AddQuartzHostedService(
                        q => q.WaitForJobsToComplete = true
                        );
                });
    }
}
