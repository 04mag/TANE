using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos
{
    public class DagCreateDto
    {
        
        public string? Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public string? Aktiviteter { get; set; }
        public string? Måltider { get; set; } 
        public string? Overnatning { get; set; }
        public int? Sekvens { get; set; }
    }
}

