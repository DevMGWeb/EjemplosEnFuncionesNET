﻿// <auto-generated />
using EFCoreEjemplos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreEjemplos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210127020757_EstaBorrado-Estudiante")]
    partial class EstaBorradoEstudiante
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EFCoreEjemplos.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("EFCoreEjemplos.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId")
                        .IsUnique();

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("EFCoreEjemplos.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("bit");

                    b.Property<int>("InstitucionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstitucionId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("EFCoreEjemplos.EstudianteCurso", b =>
                {
                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.HasKey("CursoId", "EstudianteId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("EstudiantesCursos");
                });

            modelBuilder.Entity("EFCoreEjemplos.Institucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instituciones");
                });

            modelBuilder.Entity("EFCoreEjemplos.Direccion", b =>
                {
                    b.HasOne("EFCoreEjemplos.Estudiante", null)
                        .WithOne("Direccion")
                        .HasForeignKey("EFCoreEjemplos.Direccion", "EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreEjemplos.Estudiante", b =>
                {
                    b.HasOne("EFCoreEjemplos.Institucion", null)
                        .WithMany("Estudiantes")
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreEjemplos.EstudianteCurso", b =>
                {
                    b.HasOne("EFCoreEjemplos.Curso", "Curso")
                        .WithMany("EstudianteCursos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreEjemplos.Estudiante", "Estudiante")
                        .WithMany("EstudianteCursos")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("EFCoreEjemplos.Curso", b =>
                {
                    b.Navigation("EstudianteCursos");
                });

            modelBuilder.Entity("EFCoreEjemplos.Estudiante", b =>
                {
                    b.Navigation("Direccion");

                    b.Navigation("EstudianteCursos");
                });

            modelBuilder.Entity("EFCoreEjemplos.Institucion", b =>
                {
                    b.Navigation("Estudiantes");
                });
#pragma warning restore 612, 618
        }
    }
}
