﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;

#nullable disable

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data.Migrations
{
    [DbContext(typeof(CineContext))]
    partial class CineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaLanzamiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activa")
                        .HasColumnType("bit");

                    b.Property<int>("CantidadButacas")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("SalaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ButacasDisponibles")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadButacas")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroDeSala")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaID")
                        .HasColumnType("int");

                    b.Property<string>("TipoSala")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaID");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Cliente", b =>
                {
                    b.HasBaseType("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Usuario");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Empleado", b =>
                {
                    b.HasBaseType("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Usuario");

                    b.Property<string>("Legajo")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Pelicula", b =>
                {
                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Genero", "Genero")
                        .WithMany("Peliculas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Reserva", b =>
                {
                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Sala", "Sala")
                        .WithMany("Reservas")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Sala", b =>
                {
                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Pelicula", "Pelicula")
                        .WithMany("Salas")
                        .HasForeignKey("PeliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Pelicula", b =>
                {
                    b.Navigation("Salas");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Sala", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
