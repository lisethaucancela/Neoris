namespace Neoris.DTOs
{
    public class Cliente : Persona
    { 
    public string Contraseña { get; set; }
    public Boolean Estado { get; set; }
    public ICollection<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
        public string Discriminator { get; set; }


    }
}
