using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Soccer.Infrastructure.Identity
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context,
            ILogger logger,
            int retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(context, logger, retryForAvailability);
                throw;
            }
        }
    }
}
