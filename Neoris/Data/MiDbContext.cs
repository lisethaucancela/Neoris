using Microsoft.EntityFrameworkCore;
using Neoris.DTOs;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Neoris.Data
{
    public class MiDbContext  : DbContext
    { 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
             .ToTable("Cliente"); // Usa una tabla para Persona y Cliente

            // Configuración para Cliente que hereda de Persona
            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente") // Usa la misma tabla
                .HasBaseType<Persona>(); // Indica que Cliente hereda de Persona


            modelBuilder.Entity<Cuenta>()
      .HasOne(c => c.Cliente)
      .WithMany(cl => cl.Cuentas)
      .HasForeignKey(c => c.ClienteId)
      .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Movimiento>()
        .HasOne(m => m.Cuenta)
        .WithMany(c => c.Movimientos)
        .HasForeignKey(m => m.NumeroCuenta)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
