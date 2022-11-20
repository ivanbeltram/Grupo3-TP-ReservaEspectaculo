﻿using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;

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
            // Add services to the container.
            builder.Services.AddDbContext<CineContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CineDBCS")));
            builder.Services.AddIdentity<Usuario, Rol>().AddEntityFrameworkStores<CineContext>();
            builder.Services.Configure<IdentityOptions>(opciones =>
                {
                  opciones.Password.RequiredLength = 8;
                }
            );
            builder.Services.AddControllersWithViews();

        }
        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
