using System.ComponentModel.DataAnnotations;


namespace TANE.Domain.Entities
{
    public class Kunde
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fornavn er påkrævet")]
        [StringLength(50, ErrorMessage = "Fornavn må ikke være længere end 50 tegn")]
        public string Fornavn { get; set; } = string.Empty;

        [Required(ErrorMessage = "Efternavn er påkrævet")]
        [StringLength(50, ErrorMessage = "Efternavn må ikke være længere end 50 tegn")]
        public string Efternavn { get; set; } = string.Empty;
        
        [EmailAddress(ErrorMessage = "Email er ikke valid")]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(20, ErrorMessage = "Telefonnummer må ikke være længere end 20 tegn")]
        public string TlfNummer { get; set; } = string.Empty;

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();


        public Kunde()
        {
            
        }

        public Kunde(string fornavn, string efternavn, string email, string tlfNummer)
        {
            this.Fornavn = fornavn;
            this.Efternavn = efternavn;
            this.Email = email;
            this.TlfNummer = tlfNummer;
        }
    }
}
