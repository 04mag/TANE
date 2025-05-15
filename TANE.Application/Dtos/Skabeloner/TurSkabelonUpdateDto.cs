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
        public List<DagSkabelonUpdateDto> Dage { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
        public int Sekvens { get; set; } 
    }
}
