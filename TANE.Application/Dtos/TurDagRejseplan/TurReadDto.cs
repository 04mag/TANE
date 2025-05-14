using TANE.Domain.Entities;

namespace TANE.Application.Dtos
{
    public class TurReadDto
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public double Pris { get; set; }
        public DateTime? TurStartTidspunkt { get; set; }
        public DateTime? TurSlutTidspunkt { get; set; }
        public List<Dag>? Dage { get; set; }
        public int? RejseplanId { get; set; }
        public int? Sekvens { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
