﻿// <auto-generated />
using System;
using Agendamento.reposit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agendamento.reposit.Migrations
{
    [DbContext(typeof(SalaContext))]
    [Migration("20200731121705_inicio")]
    partial class inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Agendamento.Dominio.Evento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SalaNome");

                    b.Property<int?>("Salaid");

                    b.Property<DateTime>("data_final");

                    b.Property<DateTime>("data_inicial");

                    b.Property<string>("nome_resp");

                    b.HasKey("id");

                    b.HasIndex("Salaid");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Agendamento.Dominio.Sala", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome");

                    b.HasKey("id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("Agendamento.Dominio.Evento", b =>
                {
                    b.HasOne("Agendamento.Dominio.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("Salaid");
                });
#pragma warning restore 612, 618
        }
    }
}