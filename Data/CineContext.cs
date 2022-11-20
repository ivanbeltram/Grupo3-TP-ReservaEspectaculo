using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data
{
    public class CineContext : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
    {
        public CineContext(DbContextOptions<CineContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Cliente> Cliente { get; set; }
        public DbSet<ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Empleado> Empleado { get; set; }
        public DbSet<Rol>Roles { get; set; }

    }
}