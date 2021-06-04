using AdventureWorks.API.Middlewares;
using AdventureWorks.BLL.Operations;
using AdventureWorks.Core.Abstractions;
using AdventureWorks.Core.Abstractions.Operations;
using AdventureWorks.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.API
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
            services.AddDbContext<AdventureWorksLT2012Context>(context => 
            {
                context.UseSqlServer(Configuration.GetConnectionString("default"));
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options => //CookieAuthenticationOptions
              {
                  //   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
              });
            services.AddControllers();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddScoped<IUserOperations, UserOperations>();
            services.AddScoped<ICustomerOperations, CustomerOperations>();
            services.AddScoped<IProductOperations, ProductOperations>();
            services.AddScoped<ISalesOrderHeaderOperations, SalesOrderHeaderOperations>();
            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
