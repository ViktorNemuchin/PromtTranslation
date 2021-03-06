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
using PromtTranslation.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PromtTranslation.Domain.Dto;
using Microsoft.Extensions.Logging;

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
                    var customConfiguration = hostContext.Configuration.Get<DbConfigurationDto>();
                    services.AddHttpClient();
                    services.AddScoped<ITranslationService, TranslationService>(x => new TranslationService(
                        x.GetRequiredService<ITranslatioonUnitOfWork>(),
                        x.GetRequiredService<HttpClient>(),
                        x.GetRequiredService<ILoggerFactory>(),
                        customConfiguration.PromtUrl));
                    services.AddScoped<ISendTranslationService, SendTranslationService>(
                        x => new SendTranslationService(x.GetRequiredService<ITranslatioonUnitOfWork>(), 
                        x.GetRequiredService<HttpClient>(), customConfiguration.BankOfIdeasUrl));
                    services.AddDbContext<TranslationDbContext>(options =>
                    {
                        OptionsHelper.SetConnectionString(customConfiguration.DbType, 
                            options, 
                            hostContext.Configuration);
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
