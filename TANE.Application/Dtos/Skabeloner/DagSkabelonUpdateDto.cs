using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos.Skabeloner
{
    public class DagSkabelonUpdateDto
    {
        public int Id { get; set; }
        public int Sekvens { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;
        public string Aktiviteter { get; set; } = string.Empty;
        public string Måltider { get; set; } = string.Empty;
        public string Overnatning { get; set; } = string.Empty; 
        public byte[] RowVersion { get; set; }
    }
}