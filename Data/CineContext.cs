using Microsoft.EntityFrameworkCore;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data
{
    public class CineContext : DbContext
    {
        public CineContext(DbContextOptions options) : base(options)
        {

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