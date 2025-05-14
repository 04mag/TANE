using TANE.Domain.Entities;

namespace TANE.Application.Dtos.Skabeloner
{
    public class TurSkabelonReadDto
    {
        public int Id { get; set; }

        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }
        public List<DagSkabelon> Dage { get; set; } = new();
        //public ICollection<Rejseplan> Rejseplaner { get; set; } = new List<Rejseplan>();
        public List<int> RejseplanIds { get; set; } = new();
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}

