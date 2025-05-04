using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos
{
    public class DagUpdateDto
    {
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Aktiviteter { get; set; }
        public string Måltider { get; set; }
        public string Overnatning { get; set; }
        public double Pris { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
        public int Sekvens { get; set; } // Rækkefølge af dagen i turen 
    }
}
