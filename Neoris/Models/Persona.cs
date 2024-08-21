using System.ComponentModel.DataAnnotations;

namespace Neoris.DTOs
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        public string? Genero { get; set; }
        public int? Edad { get; set; }

        [MaxLength(15)]
        public string? Identificacion { get; set; }

        [MaxLength(100)]
         
        public string Direccion { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Telefono { get; set; }
         

    }
}
