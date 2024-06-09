using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Filmsammlung.Data;
using Filmsammlung.Services.Interfaces;
using Filmsammlung.Services.Services;
using Microsoft.OpenApi.Models;

namespace FilmSammlung
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddDbContext<NotenContext>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller/Home}/{action=Index}/{id?}");

            //});
        }
    }
}
