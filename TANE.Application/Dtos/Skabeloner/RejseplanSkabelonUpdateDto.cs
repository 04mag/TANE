using System.ComponentModel.DataAnnotations;

 namespace TANE.Application.Dtos.Skabeloner
{
    public class RejseplanSkabelonUpdateDto
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public List<TurSkabelonUpdateDto> Ture { get; set; } = new();
        [Required]
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
