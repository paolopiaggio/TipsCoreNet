using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Tips.Data;
using Tips.Model;
using System.IO;

namespace Tips.Api.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    // builder => builder.WithOrigins("http://localhost:8080"));
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            // Add framework services.
            services.AddMvc();
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("in-memory-database"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var context = app.ApplicationServices.GetService<ApiContext>();
            AddTestData(context);
            app.UseMvc();
        }

        private static void AddTestData(ApiContext context)
        {
            var lines = File.ReadAllLines(@"Resources/tips.csv");
            foreach (var line in lines)
            {
                var csvParts = line.Split(',');
                context.Tips.Add(new Tip
                {
                    Id = long.Parse(csvParts[0]),
                    Text = csvParts[1]
                });
                context.SaveChanges();
            }
        }
    }
}
