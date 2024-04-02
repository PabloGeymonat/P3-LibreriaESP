﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240402194843_NombreDeLaMigracion6")]
    partial class NombreDeLaMigracion6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaDefuncion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NacionalidadId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Domain.Models.DetalleFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("FacturaDeCompraId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PublicacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacturaDeCompraId");

                    b.HasIndex("PublicacionId");

                    b.ToTable("DetallesFactura");
                });

            modelBuilder.Entity("Domain.Models.Editorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.Property<int>("PaisOrigenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.HasIndex("PaisOrigenId");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("Domain.Models.FacturaDeCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Impuestos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VencimientoPago")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("FacturasDeCompra");
                });

            modelBuilder.Entity("Domain.Models.Nacionalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nacionalidades");
                });

            modelBuilder.Entity("Domain.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Domain.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Domain.Models.Publicacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadPaginas")
                        .HasColumnType("int");

                    b.Property<int>("EditorialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenPortada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioSugerido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("TemaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EditorialId");

                    b.HasIndex("TemaId");

                    b.ToTable("Publicaciones");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.PublicacionAutor", b =>
                {
                    b.Property<int>("PublicacionId")
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.HasKey("PublicacionId", "AutorId");

                    b.HasIndex("AutorId");

                    b.ToTable("PublicacionAutor");
                });

            modelBuilder.Entity("Domain.Models.Resena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PublicacionId")
                        .HasColumnType("int");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublicacionId");

                    b.ToTable("Resenas");
                });

            modelBuilder.Entity("Domain.Models.Tema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Temas");
                });

            modelBuilder.Entity("Domain.Models.Libro", b =>
                {
                    b.HasBaseType("Domain.Models.Publicacion");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Libros", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Revista", b =>
                {
                    b.HasBaseType("Domain.Models.Publicacion");

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("TablaContenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Revistas", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Autor", b =>
                {
                    b.HasOne("Domain.Models.Nacionalidad", "Nacionalidad")
                        .WithMany()
                        .HasForeignKey("NacionalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nacionalidad");
                });

            modelBuilder.Entity("Domain.Models.DetalleFactura", b =>
                {
                    b.HasOne("Domain.Models.FacturaDeCompra", "FacturaDeCompra")
                        .WithMany("DetallesCompra")
                        .HasForeignKey("FacturaDeCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("PublicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacturaDeCompra");

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Domain.Models.Editorial", b =>
                {
                    b.HasOne("Domain.Models.Pais", null)
                        .WithMany("Editoriales")
                        .HasForeignKey("PaisId");

                    b.HasOne("Domain.Models.Pais", "PaisOrigen")
                        .WithMany()
                        .HasForeignKey("PaisOrigenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaisOrigen");
                });

            modelBuilder.Entity("Domain.Models.FacturaDeCompra", b =>
                {
                    b.HasOne("Domain.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Domain.Models.Publicacion", b =>
                {
                    b.HasOne("Domain.Models.Editorial", "Editorial")
                        .WithMany()
                        .HasForeignKey("EditorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Tema", "Tema")
                        .WithMany()
                        .HasForeignKey("TemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editorial");

                    b.Navigation("Tema");
                });

            modelBuilder.Entity("Domain.Models.PublicacionAutor", b =>
                {
                    b.HasOne("Domain.Models.Autor", "Autor")
                        .WithMany("Publicaciones")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Publicacion", "Publicacion")
                        .WithMany("Autores")
                        .HasForeignKey("PublicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Domain.Models.Resena", b =>
                {
                    b.HasOne("Domain.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("PublicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Domain.Models.Libro", b =>
                {
                    b.HasOne("Domain.Models.Publicacion", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.Libro", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Revista", b =>
                {
                    b.HasOne("Domain.Models.Publicacion", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.Revista", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Autor", b =>
                {
                    b.Navigation("Publicaciones");
                });

            modelBuilder.Entity("Domain.Models.FacturaDeCompra", b =>
                {
                    b.Navigation("DetallesCompra");
                });

            modelBuilder.Entity("Domain.Models.Pais", b =>
                {
                    b.Navigation("Editoriales");
                });

            modelBuilder.Entity("Domain.Models.Publicacion", b =>
                {
                    b.Navigation("Autores");
                });
#pragma warning restore 612, 618
        }
    }
}