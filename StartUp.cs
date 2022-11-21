using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo
{
    public static class StartUp
    {
        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CineContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CineDBCS")));

            builder.Services.AddIdentity<Usuario, Rol>().AddEntityFrameworkStores<CineContext>();

            builder.Services.Configure<IdentityOptions>(opciones =>
                {
                    opciones.Password.RequireNonAlphanumeric = false;
                    opciones.Password.RequireLowercase = false;
                    opciones.Password.RequireUppercase = false;
                    opciones.Password.RequireDigit = false;
                    opciones.Password.RequiredLength = 8;
                }
            );

            builder.Services.AddControllersWithViews();
        }
        private static void Configure(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}