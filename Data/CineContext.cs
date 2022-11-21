using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data
{
    public class CineContext : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
    {
        public CineContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Usuarios");

            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UsuariosRoles");
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}