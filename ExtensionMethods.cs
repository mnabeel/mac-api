using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace MacApi {
    public static class ExtensionMethods {
        public static IWebHost MigrateDatabase<T>(this IWebHost webHost) where T : DbContext {
            using (var scope = webHost.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                }
                catch (Exception exception) {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occured while migrating the database.");
                }
            }
            return webHost;
        }
    }
}