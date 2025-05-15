 using TANE.Domain.Entities;

 namespace TANE.Application.Dtos.Skabeloner
{
    public class RejseplanSkabelonReadDto
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public List<TurSkabelon> Ture { get; set; } = new();
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}

