using System.ComponentModel.DataAnnotations;

namespace TANE.Rejseplan.Application.Dtos
{
    public class DagUpdateDto
    {
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public List<string> Aktiviteter { get; set; } = new();
        public List<string> Måltider { get; set; } = new();
        public string Overnatning { get; set; }
        public double Pris { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
        public int Sekvens { get; set; } // Rækkefølge af dagen i turen 
    }
}
