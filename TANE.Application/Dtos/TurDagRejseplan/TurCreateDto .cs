namespace TANE.Application.Dtos
{
    public class TurCreateDto
    {
        //public List<int> RejseplanIds { get; set; } = new();

        public string? Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public double Pris { get; set; } = 0;

        public List<DagCreateDto> Dage { get; set; } = new();

        public DateTime? TurStartTidspunkt { get; set; } = DateTime.Today;
        public DateTime? TurSlutTidspunkt { get; set; } = DateTime.Today.AddDays(7);

        public int? Sekvens{ get; set; }
    }
}
