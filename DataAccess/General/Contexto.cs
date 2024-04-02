using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Contexto: DbContext
    {
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; } // Esto incluirá tanto Libros como Revistas
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Revista> Revistas { get; set; }
        public DbSet<Resena> Resenas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<FacturaDeCompra> FacturasDeCompra { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        public DbSet<PublicacionAutor> PublicacionAutor { get; set; } // Clase de asociación para la relación muchos a muchos
        
        public Contexto(DbContextOptions options): base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definir FK de nacionalidad en Autor
            modelBuilder.Entity<Autor>()
                .HasOne(a => a.Nacionalidad)  // Un Autor tiene una Nacionalidad
                .WithMany(n => n.Autores)     // Una Nacionalidad tiene muchos Autores
                .HasForeignKey(a => a.NacionalidadId);  // Clave foránea en Autor
            
            //definir FK de paises en Editorial
            modelBuilder.Entity<Editorial>()
                .HasOne(p => p.PaisOrigen)  // Una Editorial tiene un pais de origen
                .WithMany(n => n.Editoriales)     // Un Pais tiene varias editoriales
                .HasForeignKey(p => p.PaisOrigenId);  // Clave foránea en en Nacionalidad
            
            
            //definir FK de Temas en Publicacion
            modelBuilder.Entity<Publicacion>()
                .HasOne(p => p.Tema)  // Una Publicacion tiene un Tema
                .WithMany(t => t.Publicaciones)     // Un Tema tiene varias Publicaciones
                .HasForeignKey(p => p.TemaId);  // Clave foránea en en TemaId
            
            //definir FK de Edotorial en Publicacion
            modelBuilder.Entity<Publicacion>()
                .HasOne(p => p.Editorial)  // Una Publicacion tiene un Tema
                .WithMany(t => t.Publicaciones)     // Un Tema tiene varias Publicaciones
                .HasForeignKey(p => p.EditorialId);  // Clave foránea en en TemaId

            
            
            // Configuración de la herencia entre Publicacion, Libro y Revista
            modelBuilder.Entity<Libro>().ToTable("Libros");
            modelBuilder.Entity<Revista>().ToTable("Revistas");

            // Relación de muchos a muchos entre Publicacion y Autor
            modelBuilder.Entity<PublicacionAutor>()
                .HasKey(pa => new { pa.PublicacionId, pa.AutorId });

            modelBuilder.Entity<PublicacionAutor>()
                .HasOne(pa => pa.Publicacion)
                .WithMany(p => p.Autores)
                .HasForeignKey(pa => pa.PublicacionId);

            modelBuilder.Entity<PublicacionAutor>()
                .HasOne(pa => pa.Autor)
                .WithMany(a => a.Publicaciones)
                .HasForeignKey(pa => pa.AutorId);

            // Configuración de FacturaDeCompra
            modelBuilder.Entity<FacturaDeCompra>()
                .HasOne(fc => fc.Proveedor)
                .WithMany()
                .HasForeignKey(fc => fc.ProveedorId);

            // Configuración de DetalleFactura
            modelBuilder.Entity<DetalleFactura>()
                .HasOne(df => df.FacturaDeCompra)
                .WithMany(f => f.DetallesCompra)
                .HasForeignKey(df => df.FacturaDeCompraId);

            modelBuilder.Entity<DetalleFactura>()
                .HasOne(df => df.Publicacion)
                .WithMany()
                .HasForeignKey(df => df.PublicacionId);
           
            base.OnModelCreating(modelBuilder);
        }








    }

    
}
