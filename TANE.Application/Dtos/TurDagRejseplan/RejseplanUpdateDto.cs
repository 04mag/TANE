using System.ComponentModel.DataAnnotations;
using TANE.Application.Dtos.TurDagRejseplan;
using TANE.Domain.Entities;

namespace TANE.Application.Dtos
{
    public class RejseplanUpdateDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public int? KundeId { get; set; }
        public int? AntalVoksne { get; set; }
        public int? AntalBørn { get; set; }
        public string? Lufthavn { get; set; } // **Til opfølgning*
        public double? FlyPris { get; set; }
        public int? AntalDage { get; set; }
        public DateTime? AfrejseTidspunkt { get; set; }
        public List<TurUpdateDto>? Ture { get; set; } 
        public string? OpfølgningNote { get; set; } 
        [Required]
        public RejseplanStatusDto? RejseplanStatus { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**

    }
}
