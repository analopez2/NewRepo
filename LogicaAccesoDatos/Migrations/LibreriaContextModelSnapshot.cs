﻿// <auto-generated />
using System;
using LogicaAccesoDatos.BaseDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    partial class LibreriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogicaNegocio.Dominio.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoPartido")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Incidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amarillas")
                        .HasColumnType("int");

                    b.Property<int>("RojasAcumAmarillas")
                        .HasColumnType("int");

                    b.Property<int>("RojasDirectas")
                        .HasColumnType("int");

                    b.Property<int?>("SeleccionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeleccionId");

                    b.ToTable("Incidencias");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.IncidenciaPartido", b =>
                {
                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.Property<int>("IncidenciaId")
                        .HasColumnType("int");

                    b.HasKey("PartidoId", "IncidenciaId");

                    b.HasIndex("IncidenciaId");

                    b.ToTable("IncidenciaPartido");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bandera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Pbi")
                        .HasColumnType("int");

                    b.Property<int>("Poblacion")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("RegionId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HoraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("HoraId");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PartidoGrupo", b =>
                {
                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.HasKey("PartidoId", "GrupoId");

                    b.HasIndex("GrupoId");

                    b.ToTable("PartidoGrupo");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regiones");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Seleccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantPotencialApostadores")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("GrupoId");

                    b.HasIndex("PaisId")
                        .IsUnique();

                    b.HasIndex("Telefono")
                        .IsUnique()
                        .HasFilter("[Telefono] IS NOT NULL");

                    b.ToTable("Selecciones");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.SeleccionPartido", b =>
                {
                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.Property<int>("SeleccionId")
                        .HasColumnType("int");

                    b.HasKey("PartidoId", "SeleccionId");

                    b.HasIndex("SeleccionId");

                    b.ToTable("SeleccionPartido");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Incidencia", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Seleccion", "Seleccion")
                        .WithMany()
                        .HasForeignKey("SeleccionId");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.IncidenciaPartido", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Incidencia", "Incidencia")
                        .WithMany()
                        .HasForeignKey("IncidenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Partido", "Partido")
                        .WithMany("Incidencias")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pais", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Partido", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.HasOne("LogicaNegocio.Dominio.Horario", "Hora")
                        .WithMany()
                        .HasForeignKey("HoraId");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PartidoGrupo", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Grupo", "Grupo")
                        .WithMany("PartidoGrupo")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Partido", "Partido")
                        .WithMany()
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Seleccion", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.SeleccionPartido", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Partido", "Partido")
                        .WithMany("SeleccionPartido")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Seleccion", "Seleccion")
                        .WithMany("SeleccionPartido")
                        .HasForeignKey("SeleccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
