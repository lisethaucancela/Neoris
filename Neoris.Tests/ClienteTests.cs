using Microsoft.EntityFrameworkCore;
using Neoris.Data;
using Neoris.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neoris.Tests
{
    public class ClienteTests
    {
        private DbContextOptions<MiDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<MiDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
        }

        [Fact]
        public void Crear_Cliente_Satisfactorio()
        {
            // Arrange
            var options = GetDbContextOptions();

            using (var context = new MiDbContext(options))
            {
                var cliente = new Cliente
                {
                    Id = 1,
                    Nombre = "Oscar",
                    Genero = "M",
                    Edad = 30,
                    Identificacion = "1234567890",
                    Direccion = "Rio",
                    Telefono = "0983586",
                    Contraseña = "1234",
                    Estado = true
                };

                // Act
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }

            using (var context = new MiDbContext(GetDbContextOptions()))
            { 
                var cliente = context.Clientes.Find(1);
                Assert.NotNull(cliente);
                Assert.Equal("Oscar", cliente.Nombre);
                Assert.Equal("Rio", cliente.Direccion);
                Assert.Equal("0983586", cliente.Telefono);
                Assert.Equal("1234", cliente.Contraseña);
                Assert.True(cliente.Estado);
            }
        }
    }
}

