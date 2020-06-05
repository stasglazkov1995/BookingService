using BookMe.BookingService.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookMe.BookingService.Host.Extensions
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                try
                {
                    db.Database.EnsureCreated();
                    db.Database.Migrate();
                }
                catch
                {

                }
            }

            return app;
        }
    }
}
