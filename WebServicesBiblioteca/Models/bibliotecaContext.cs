using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebServicesBiblioteca.Models
{
    public partial class bibliotecaContext : DbContext
    {
        public bibliotecaContext()
        {
        }

        public bibliotecaContext(DbContextOptions<bibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ejemplare> Ejemplares { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<LineasPrestamo> LineasPrestamos { get; set; } = null!;
        public virtual DbSet<PoliticaPrestamo> PoliticaPrestamos { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<Socio> Socios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SqlExpress; Database=biblioteca; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ejemplare>(entity =>
            {
                entity.HasKey(e => e.IdEjemplar);

                entity.ToTable("ejemplares");

                entity.Property(e => e.IdEjemplar).HasColumnName("id_ejemplar");

                entity.Property(e => e.IdLibro).HasColumnName("id_libro");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Ejemplares)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ejemplares_libros");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro);

                entity.ToTable("libros");

                entity.HasIndex(e => e.Isbn, "IX_isbn")
                    .IsUnique();

                entity.Property(e => e.IdLibro).HasColumnName("id_libro");

                entity.Property(e => e.CantDiasMaxPrestamo).HasColumnName("cant_dias_max_prestamo");

                entity.Property(e => e.FechaEdicion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_edicion");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("isbn");

                entity.Property(e => e.NroEdicion).HasColumnName("nro_edicion");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<LineasPrestamo>(entity =>
            {
                entity.HasKey(e => e.IdLineaPrestamo);

                entity.ToTable("lineas_prestamo");

                entity.Property(e => e.IdLineaPrestamo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_linea_prestamo");

                entity.Property(e => e.Devuelto).HasColumnName("devuelto");

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_devolucion");

                entity.Property(e => e.IdEjemplar).HasColumnName("id_ejemplar");

                entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");

                entity.HasOne(d => d.IdLineaPrestamoNavigation)
                    .WithOne(p => p.LineasPrestamo)
                    .HasForeignKey<LineasPrestamo>(d => d.IdLineaPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lineas_prestamo_ejemplares");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.LineasPrestamos)
                    .HasForeignKey(d => d.IdPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lineas_prestamo_prestamos");
            });

            modelBuilder.Entity<PoliticaPrestamo>(entity =>
            {
                entity.HasKey(e => e.FechaVigencia);

                entity.ToTable("politica_prestamo");

                entity.HasIndex(e => e.FechaVigencia, "IX_politica_prestamo");

                entity.Property(e => e.FechaVigencia)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_vigencia");

                entity.Property(e => e.CantMaxLibrosPend).HasColumnName("cant_max_libros_pend");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo);

                entity.ToTable("prestamos");

                entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");

                entity.Property(e => e.FechaPrestamo)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_prestamo");

                entity.Property(e => e.IdSocio).HasColumnName("id_socio");

                entity.HasOne(d => d.IdSocioNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdSocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prestamos_socios");
            });

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.HasKey(e => e.IdSocio);

                entity.ToTable("socios");

                entity.Property(e => e.IdSocio).HasColumnName("id_socio");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
