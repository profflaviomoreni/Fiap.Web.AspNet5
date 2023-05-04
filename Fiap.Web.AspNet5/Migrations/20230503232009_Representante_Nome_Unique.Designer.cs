﻿// <auto-generated />
using Fiap.Web.AspNet5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiap.Web.AspNet5.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230503232009_Representante_Nome_Unique")]
    partial class Representante_Nome_Unique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Web.AspNet5.Models.FornecedorModel", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FornecedorId"));

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Email")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("FornecedorNome")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("FornecedorNome");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("Fiap.Web.AspNet5.Models.RepresentanteModel", b =>
                {
                    b.Property<int>("RepresentanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepresentanteId"));

                    b.Property<string>("NomeRepresentante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RepresentanteId");

                    b.HasIndex("NomeRepresentante")
                        .IsUnique();

                    b.ToTable("Representante");
                });
#pragma warning restore 612, 618
        }
    }
}
