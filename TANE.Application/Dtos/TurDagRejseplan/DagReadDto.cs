namespace TANE.Rejseplan.Application.Dtos
{
    public class DagReadDto
    {
        public int Id { get; set; }
      //  public List<int> TurIds { get; set; } = new();
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public List<string> Aktiviteter { get; set; } = new();
        public List<string> Måltider { get; set; } = new();
        public string Overnatning { get; set; }
        public double Pris { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
