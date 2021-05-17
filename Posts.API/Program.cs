using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Posts.API.Database;

namespace Posts.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new PostsContext())
            {
                DbInitializer.Initialize(context);
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
