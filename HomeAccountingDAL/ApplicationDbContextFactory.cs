using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HomeAccountingDAL
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string? connectionString = ConfigurationHelper.GetConnectionString();

            if (connectionString is null)
            {
                throw new Exception("connection string is null");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            return new ApplicationDbContext(options);
        }
    }
}
