using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos.Skabeloner
{
    public class RejseplanSkabelonCreateDto
    {
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }

        public List<TurSkabelonCreateDto>? Ture { get; set; } 

        
}
}
