namespace Neoris.DTOs
{
    public class ReporteCuentaDto
    {
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public List<MovimientoDto> Movimientos { get; set; }
    }
}
