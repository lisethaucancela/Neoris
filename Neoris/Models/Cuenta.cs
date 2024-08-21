using System.ComponentModel.DataAnnotations;

namespace Neoris.DTOs
{
    public class Cuenta
    {
        [Key]
        public string NumeroCuenta { get; set; }
        [MaxLength(50)]
        public string? TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public Boolean Estado { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public ICollection<Movimiento>? Movimientos { get; set; } = new List<Movimiento>();
    }
}
