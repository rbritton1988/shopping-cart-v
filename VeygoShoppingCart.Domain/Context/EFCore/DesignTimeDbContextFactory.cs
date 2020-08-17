using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace VeygoShoppingCart.Domain.Context.EFCore
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EFCoreContext>
    {
        public EFCoreContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();
            var connectionString = configuration["VeygoShoppingCartDatabaseConnectionString"];
            var dbContextOptions = new DbContextOptionsBuilder<EFCoreContext>().UseNpgsql(connectionString).Options;
            return new EFCoreContext(dbContextOptions);
        }
    }
}
