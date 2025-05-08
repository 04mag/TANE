namespace TANE.Application.Dtos
{
    public class TurCreateDto
    {
        //public List<int> RejsePlanIds { get; set; } = new();

        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }
        public DateTime TurStartTidspunkt { get; set; }
        public DateTime TurSlutTidspunkt { get; set; }

        public int Sekvens { get; set; }
    }
}
