using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Business.Abstract;
using InsureApp.Business.Concrate;
using InsureApp.DataAccess.Abstract;
using InsureApp.DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using InsureApp.Models;
using InsureApp.Middlewares;
using Microsoft.Extensions.Logging;
using InsureApp.Entities;
using Microsoft.AspNetCore.Identity;

namespace InsureApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Data Source=DESKTOP-N2T7QUB;Database=InsuranceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IMusteriService, MusteriManager>(); // Olurda IMusteriService istenirse manager örneği oluştur ve onu ver. Bizim yerimize arkada new yapar ve onu verir.
            services.AddScoped<IMusteriDal, EfMusteriDal>(); // Olurda IMusteriDal istenirse EntitiyFramework ile çalışacağımız için ona EntityFrameworkDal ver.
            services.AddMvc();


            services.AddScoped<IPoliceService, PoliceManager>();
            services.AddScoped<IPoliceDal, EfPoliceDal>(); // Olurda IMusteriDal istenirse EntitiyFramework ile çalışacağımız için ona EntityFrameworkDal ver.
            services.AddScoped<IPoliceTuruService, PoliceTuruManager>(); // Olurda IMusteriService istenirse manager örneği oluştur ve onu ver. Bizim yerimize arkada new yapar ve onu verir.
            services.AddScoped<IPolice_TuruDal, EfPoliceturuDal>(); // Olurda IMusteriDal istenirse EntitiyFramework ile çalışacağımız için ona EntityFrameworkDal ver.
            services.AddMvc();

            services.AddScoped<IOdemelerService, OdemelerManager>();
            services.AddScoped<IOdemelerDal, EfOdemelerDal>();
            services.AddMvc();

            services.AddScoped<IAracService,AracManager>();
            services.AddScoped<IAracDal, EfAracDal>();
            services.AddScoped<IKonut_DigerService, Konut_DigerManager>();
            services.AddScoped<IKonut_DigerDal, EfKonut_DigerDal>();
            services.AddMvc();

            services.AddScoped<ICariService, CariManager>();
            services.AddScoped<ICariDal, EfCariDal>();
            services.AddMvc();

            services.AddDbContext<CustomIdentityDbContext>//Identity Kayıt Yapılacak Veri tabanı
                (options => options.UseSqlServer("Data Source=DESKTOP-N2T7QUB;Database=InsuranceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddIdentity<CustomIdentityUser,CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            
            
            // Farklı bir Framework veya Manager kullanmamız gerekirse sadece bunları değiştirmemiz yeterlidir, uygulamada başka birşeyleri değiştirmeye gerek duymayız.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory )
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseFileServer(); //static dosyaları tut.
            app.UseNodeModules(env.ContentRootPath);
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
