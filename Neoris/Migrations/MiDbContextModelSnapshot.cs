﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Neoris.Data;

#nullable disable

namespace Neoris.Migrations
{
    [DbContext(typeof(MiDbContext))]
    partial class MiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Neoris.DTOs.Cuenta", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoCuenta")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("NumeroCuenta");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Neoris.DTOs.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Movimientos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoMovimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("Neoris.DTOs.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);

                    b.HasDiscriminator().HasValue("Persona");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Neoris.DTOs.Cliente", b =>
                {
                    b.HasBaseType("Neoris.DTOs.Persona");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.ToTable("Cliente", (string)null);

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Neoris.DTOs.Cuenta", b =>
                {
                    b.HasOne("Neoris.DTOs.Cliente", "Cliente")
                        .WithMany("Cuentas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Neoris.DTOs.Movimiento", b =>
                {
                    b.HasOne("Neoris.DTOs.Cuenta", "Cuenta")
                        .WithMany("Movimientos")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("Neoris.DTOs.Cuenta", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("Neoris.DTOs.Cliente", b =>
                {
                    b.Navigation("Cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
