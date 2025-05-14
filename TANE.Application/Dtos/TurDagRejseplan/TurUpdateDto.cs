using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos
{
    public class TurUpdateDto
    {

        //public ICollection<Rejseplan> Rejseplaner { get; set; } = new List<Rejseplan>();
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public double? Pris { get; set; }
        public DateTime? TurStartTidspunkt { get; set; }
        public DateTime? TurSlutTidspunkt { get; set; }
         public List<DagUpdateDto>? Dage { get; set; }

        public int? Sekvens { get; set; }

        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
