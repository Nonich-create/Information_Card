using Information_Card.Application.Interfaces;
using Information_Card.Application.Services;
using Information_Card.Core.Entities;
using Information_Card.Core.Repositories.Base;
using Information_Card.Infrastructure.Data;
using Information_Catd.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Threading.Tasks;
using Information_Catd.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Information_Card.Infrastructure.Repository.Base;

namespace Information_Card.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
 
            var repositoryType = Configuration.GetSection("ChooseData:Repository").Value;
          
            if (repositoryType == "File")
            {
                services.AddScoped<IRepository<Employee>, RepositoryFile<Employee>>();
                services.AddScoped<IFileDataAccess, FileDataAccess>();
                
            }
            else
            if(repositoryType == "DB")
            {
                         services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Information_Card.Api")));
                // dotnet ef database update
                services.AddScoped<IRepository<Employee>, Repository<Employee>>();
                SeedDatabase(services.BuildServiceProvider());
            }

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                  
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }
            
            app.UseHttpsRedirection();
 
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        static async Task SeedDatabase(ServiceProvider host)
        {
                try
                {
                    var context = host.GetRequiredService<Context>();
                    await ContextSeed.SeedAsync(context);
                }
                catch (Exception exception)
                {
                }
        }
    }
}
