﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_api_health_clinic.Contexts;

#nullable disable

namespace web_api_health_clinic.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20230928194312_Tortuguita")]
    partial class Tortuguita
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("web_api_health_clinic.Domains.Clinica", b =>
                {
                    b.Property<Guid>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<TimeSpan>("HorarioAbertura")
                        .HasColumnType("TIME");

                    b.Property<TimeSpan>("HorarioFechamento")
                        .HasColumnType("TIME");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdClinica");

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Consulta", b =>
                {
                    b.Property<Guid>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Feedback", b =>
                {
                    b.Property<Guid>("IdFeedback")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("IdConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdFeedback");

                    b.HasIndex("IdConsulta");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Medico", b =>
                {
                    b.Property<Guid>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("CHAR(6)");

                    b.Property<string>("Especializacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdClinica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeMedico")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdMedico");

                    b.HasIndex("CRM")
                        .IsUnique();

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Paciente", b =>
                {
                    b.Property<Guid>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid?>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomePaciente")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdPaciente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.TiposUsuario", b =>
                {
                    b.Property<Guid>("IdTiposUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdTiposUsuario");

                    b.ToTable("TiposUsuario");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdTiposUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("CHAR(60)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdTiposUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Consulta", b =>
                {
                    b.HasOne("web_api_health_clinic.Domains.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_api_health_clinic.Domains.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Feedback", b =>
                {
                    b.HasOne("web_api_health_clinic.Domains.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Medico", b =>
                {
                    b.HasOne("web_api_health_clinic.Domains.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_api_health_clinic.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Paciente", b =>
                {
                    b.HasOne("web_api_health_clinic.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("web_api_health_clinic.Domains.Usuario", b =>
                {
                    b.HasOne("web_api_health_clinic.Domains.TiposUsuario", "TiposUsuario")
                        .WithMany()
                        .HasForeignKey("IdTiposUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
