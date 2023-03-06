using ExpenceCalculator.Infrastructure;
using ExpenceCalculator.Application.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ExpenceCalculator.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpenceCalculator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddDbContext<ApplicationContext>(o => o.UseInMemoryDatabase("DataBase"));
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CleanArch;Trusted_Connection=True;"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean Architecture Api", Version = "v1" });
            });

            // Register MediatR services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(BaseEntity))));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture Api"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
