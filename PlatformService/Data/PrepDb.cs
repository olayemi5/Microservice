using PlatformService.Model;
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting Migration");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"--> COuld not run migration {ex.Message}");
                }

            }
            else
            {
                if (!context.Platforms.Any())
                {
                    Console.WriteLine("---> Seeding Data ...");

                    context.Platforms.AddRange(
                        new Platform()
                        {
                            Id = 1,
                            Name = "Dotnet",
                            Publisher = "Microsoft",
                            Cost = "Free"
                        },
                        new Platform()
                        {
                            Id = 2,
                            Name = "Sql Server Express",
                            Publisher = "Microsoft",
                            Cost = "Free"
                        },
                        new Platform()
                        {
                            Id = 3,
                            Name = "Kubernetes",
                            Publisher = "MiCLoud Native Computing Foundation",
                            Cost = "Free"
                        }
                    );

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("---> We alreay have data");
                }
            }


        }
    }
}