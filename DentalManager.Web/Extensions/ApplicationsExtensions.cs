namespace DentalManager.Web.Extensions
{
    using DentalManager.Web.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;

    public static class ApplicationsExtensions
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<DentalManagerDbContext>();
                    //context.Database.EnsureDeleted();
                    context.Database.Migrate();
                    context.Database.EnsureCreated();

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
