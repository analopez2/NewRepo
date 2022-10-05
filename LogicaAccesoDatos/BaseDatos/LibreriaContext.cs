using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos.BaseDatos
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Seleccion> Selecciones { get; set; }

        public LibreriaContext(DbContextOptions<LibreriaContext> opciones) : base(opciones)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Autor>().ToTable("Autor");
            //modelBuilder.Entity<Autor>().HasIndex(autor => autor.Documento).IsUnique(true);
            //modelBuilder.Entity<Autor>().Property(autor => autor.Documento).IsRequired(true);
            //modelBuilder.Entity<Autor>().Property(autor => autor.Nombre).IsRequired(true).HasMaxLength(50);
            //modelBuilder.Entity<AutorPublicacion>().HasKey(ap => new { ap.AutorId, ap.PublicacionId });
            //base.OnModelCreating(modelBuilder);
        }
    }
}
