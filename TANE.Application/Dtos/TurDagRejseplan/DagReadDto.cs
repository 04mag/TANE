namespace TANE.Application.Dtos
{
    public class DagReadDto
    {
        public int Id { get; set; }
      //  public List<int> TurIds { get; set; } = new();
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Aktiviteter { get; set; }
        public string Måltider { get; set; } 
        public string Overnatning { get; set; }
        public int? Sekvens { get; set; }
        public byte[] RowVersion { get; set; }
        public int? TurId { get; set; } // FK til Tur
    }
}
