using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.Core.InterfaceRepositories;
using Week7.Master.MVC.Models;
using Week7.Master.RepositoryEF;
using Week7.Master.RepositoryEF.RepositoriesEF;
using Week7.Master.RepositoryMock;

namespace Week7.Master.MVC
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
            services.AddControllersWithViews();

            //services.AddTransient<ICounterService, CounterService>(); //ad ogni richiesta crea una nuova istanza dell'ogetto a,b => 1 -1
            //services.AddScoped<ICounterService, CounterService>(); // ad ogni richiesta crea solo una sola istanza  => 1 - 2
            services.AddSingleton<ICounterService, CounterService>(); //per tutta la durata dell'applicazione usa solo una stessa istanza => 1-2, 3-4, ecc.

            //qui configuriamo la DI
            services.AddScoped<IBusinessLayer, MainBusinessLayer>();

            //services.AddTransient<ICorsoRepository, RepositoryCorsiMock>();
            //services.AddTransient<IDocenteRepository, RepositoryDocentiMock>();
            //services.AddTransient<ILezioneRepository, RepositoryLezioniMock>();
            //services.AddTransient<IStudenteRepository, RepositoryStudentiMock>();
            services.AddScoped<ICorsoRepository, RepositoryCorsiEF>();
            services.AddScoped<IDocenteRepository, RepositoryDocentiEF>();
            services.AddScoped<ILezioneRepository, RepositoryLezioniEF>();
            services.AddScoped<IStudenteRepository, RepositoryStudentiEF>();
            services.AddScoped<IUtentiRepository, RepositoryUtentiEF>();


            //CONNECTION STRING
            services.AddDbContext<MasterContext>(options =>
           {
               options.UseSqlServer(Configuration.GetConnectionString("EFConnection"));
           });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Login");
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Forbidden");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
