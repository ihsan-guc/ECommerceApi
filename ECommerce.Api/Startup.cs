using ECommerce.Data.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace ECommerce.Api
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
            var eCommerceDb = Configuration.GetConnectionString("ECommerceDb");
            services.AddDbContext<ECommerceContext>(opt => opt.UseMySQL(eCommerceDb));
            services.AddControllersWithViews();
            //services.AddDbContext<EmotiContext>(opt => opt.UseSqlServer(emotiDB));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ECommerceContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
