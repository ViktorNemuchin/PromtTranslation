using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PromtTranslation.Services.Helpers
{
    public static class OptionsHelper
    {
        public static void SetConnectionString(string dbType, DbContextOptionsBuilder options, IConfiguration configuration) 
        {
            switch (dbType)
            {
                case "MsSql":
                    options.UseSqlServer(configuration.GetConnectionString("PromtSqlDb"),
                        sqlOptions => sqlOptions.MigrationsAssembly("PromtTranslation.Api"));
                    break;
                case "NpqSql":
                    options.UseNpgsql(configuration.GetConnectionString("PromtDb"),
                        npsqlOptions => npsqlOptions.MigrationsAssembly("PromtTranslation.Api"));
                    break;
            }
        }
    }
}
