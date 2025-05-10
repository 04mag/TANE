namespace TANE.Application.Dtos
{
    public class TurReadDto
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }
        public DateTime TurStartTidspunkt { get; set; }
        public DateTime TurSlutTidspunkt { get; set; }
        public List<DagReadDto> Dage { get; set; } = new();
        public int? RejseplanId { get; set; } = new();
        public int Sekvens { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
