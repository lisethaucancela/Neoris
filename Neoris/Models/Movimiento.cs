
using System.ComponentModel.DataAnnotations;

namespace Neoris.DTOs
{
    public class Movimiento
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }

        public decimal? Movimientos { get; set; }
        public string? TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal? Saldo { get; set; }
        public string NumeroCuenta { get; set; }
        public Cuenta? Cuenta { get; set; }
    }
}
