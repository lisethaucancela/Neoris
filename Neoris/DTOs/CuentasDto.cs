using System.ComponentModel.DataAnnotations;

namespace Neoris.DTOs
{
    public class CuentasDto
    {
        public string NumeroCuenta { get; set; } 
        public string? TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int ClienteId { get; set; }
    }
}
