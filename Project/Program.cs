using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.DbContexts;
using Project.SeedDataGenerators;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                // Get the instance of DataItemContext in  services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DataItemContext>();

                // Call the DataItemSeedDataGenerator to create seed data
                DataItemSeedDataGenerator.GenerateDataItemSeedData(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
