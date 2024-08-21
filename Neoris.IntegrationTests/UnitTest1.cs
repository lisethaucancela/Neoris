using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Neoris.IntegrationTests;

public class UnitTest1
{
    private readonly HttpClient _client;


    [Fact]
    public async Task Post_Cliente_Retorno_Client()
    {
        // Arrange
        var clienteDto = new
        {
            Nombre = "Mary",
            Genero = "F",
            Edad = 28,
            Identificacion = "097892965",
            Direccion = "Rio",
            Telefono = "09785965",
            Contraseña = "1425",
            Estado = true
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/clientes", clienteDto);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        responseBody.Should().Contain("Mary");
        responseBody.Should().Contain("Rio");
    }
}
