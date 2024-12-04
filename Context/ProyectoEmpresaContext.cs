using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProyectoEmpresa.Models;
using ProyectoEmpresa.Controllers;


namespace ProyectoEmpresa.Context
{
    public class ProyectoEmpresaContext : DbContext
    {
        public ProyectoEmpresaContext() : base("name=ProyectoEmpresa")
        {
        }

        public DbSet<Uss> Uss { get; set; }
        public DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configuración para la tabla Usuario
            modelBuilder.Entity<Uss>()
                .ToTable("Uss")
                .HasKey(u => u.Id);

            modelBuilder.Entity<Uss>()
                .Property(u => u.Id)
                .IsRequired()
                .HasColumnName("Id");

            modelBuilder.Entity<Uss>()
                .Property(u => u.Usuario)
                .IsRequired()  // Asegura que UsuarioNombre no sea nulo
                .HasMaxLength(50)  // Limita la longitud a 50 caracteres
                .HasColumnName("Usuario");

            modelBuilder.Entity<Uss>()
                .Property(u => u.Pass)
                .IsRequired()
                .HasMaxLength(100)  // Limita la longitud a 100 caracteres
                .HasColumnName("Pass");

            modelBuilder.Entity<Uss>()
                .Property(u => u.FechaCreacion)
                .IsRequired()// Asegura que la fecha de creación no sea nula
                .HasColumnName("FechaCreacion");

            //Configuración para la tabla Persona
            modelBuilder.Entity<Persona>()
                .ToTable("Persona")
                .HasKey(p => p.IdPersona);

            modelBuilder.Entity<Persona>()
                .Property(p => p.IdPersona)
                .IsRequired()
                .HasColumnName("IdPersona");

            modelBuilder.Entity<Persona>()
                .Property(p => p.Nombre)
                .IsRequired() // Asegura que el Nombre no sea nulo
                .HasMaxLength(50)
                .HasColumnName("Nombre");

            modelBuilder.Entity<Persona>()
                .Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Apellido");

            modelBuilder.Entity<Persona>()
                .Property(p => p.NumeroIdentificacion)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NumeroIdentificacion");

            modelBuilder.Entity<Persona>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Email");

            modelBuilder.Entity<Persona>()
                .Property(p => p.FechaCreacion)
                .IsRequired();

            modelBuilder.Entity<Persona>()
                .Property(p => p.TipoDoc)
                .IsRequired()
                .HasColumnName("TipoDoc");

            base.OnModelCreating(modelBuilder);
        }
    }
}
