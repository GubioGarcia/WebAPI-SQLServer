﻿// <auto-generated />
using System;
using API_SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_SQLServer.Migrations
{
    [DbContext(typeof(ABCIncContext))]
    partial class ABCIncContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_SQLServer.Entities.Cargos", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cargo_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoId"));

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int")
                        .HasColumnName("departamento_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<int>("salario")
                        .HasColumnType("int")
                        .HasColumnName("salario");

                    b.HasKey("CargoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("API_SQLServer.Entities.Departamentos", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("departamento_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartamentoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("API_SQLServer.Entities.Funcionarios", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("funcionario_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"));

                    b.Property<int>("CargoId")
                        .HasColumnType("int")
                        .HasColumnName("cargo_id");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_contratacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
