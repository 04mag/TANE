using System.ComponentModel.DataAnnotations;

 namespace TANE.Application.Dtos.Skabeloner
{
    public class TurSkabelonUpdateDto
    {
        public int Id { get; set; }
        //public ICollection<Rejseplan> Rejseplaner { get; set; } = new List<Rejseplan>();
        public List<int> RejseplanSkabelonIds { get; set; } = new();

        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }
        public List<DagSkabelonCreateDto> Dage { get; set; }

        [Required(ErrorMessage = "RowVersion is required")]
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
