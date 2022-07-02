using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Soccer.Core.Entities.TeamAggregate;

namespace Soccer.Infrastructure.Data
{
    public class SoccerContextSeed
    {
        public static async Task SeedAsync(SoccerContext soccerContext,
            ILogger logger,
            int retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                if (soccerContext.Database.IsSqlServer())
                {
                    soccerContext.Database.Migrate();
                }

                if (!await soccerContext.Teams.AnyAsync())
                {
                    await soccerContext.Teams.AddRangeAsync(new List<Team>
                    {
                        new ("Dinamo"), 
                        new ("Steaua"),
                        new ("CSM"),
                        new ("Club Atletic")
                    });

                    await soccerContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(soccerContext, logger, retryForAvailability);
                throw;
            }
        }
    }
}
