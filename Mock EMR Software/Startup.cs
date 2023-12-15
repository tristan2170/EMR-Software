using Microsoft.EntityFrameworkCore;
using Mock_EMR_Software.DAL;

namespace Mock_EMR_Software
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure DbContext
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("YourDatabaseConnection"));
            });

            // Other services configuration...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configure for production...
            }

            // Ensure migrations are applied during application startup
            dbContext.Database.Migrate();

            // Other middleware configuration...
        }
    }
}


