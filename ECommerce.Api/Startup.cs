using ECommerce.Api.Core;
using ECommerce.Data.DAL;
using ECommerce.Data.DAL.Abstract;
using ECommerce.Data.DAL.Concrete;
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
            services.AddControllers();
            var eCommerceDb = Configuration.GetConnectionString("ECommerceDb");
            services.AddDbContext<ECommerceContext>(opt => opt.UseMySQL(eCommerceDb));
            services.AddScoped<ECommerceContext, ECommerceContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped <IUploadFile, UploadFile>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            //services.AddDbContext<EmotiContext>(opt => opt.UseSqlServer(emotiDB));

            services.AddSwaggerDocument(con => {
                con.PostProcess = (doc =>
                {
                    doc.Info.Title = "MessageApi";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Email = "ihsanguc.33@gmail.com",
                        Name = "Ýhsan Güç",
                        Url = "https://www.linkedin.com/in/ihsan-g%C3%BC%C3%A7-873024156/"
                    };
                });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ECommerceContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            app.UseAuthentication();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
