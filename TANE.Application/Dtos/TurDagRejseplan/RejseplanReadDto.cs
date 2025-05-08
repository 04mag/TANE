using System.ComponentModel.DataAnnotations;
using TANE.Application.Dtos.TurDagRejseplan;

namespace TANE.Application.Dtos
{
    public class RejseplanReadDto
    {
        public int Id { get; set; }

        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public int? KundeId { get; set; }
        public int? AntalVoksne { get; set; }
        public int? AntalBørn { get; set; }
        public string? Lufthavn { get; set; }
        public double? FlyPris { get; set; }
        public int? AntalDage { get; set; }
        public DateTime? AfrejseTidspunkt { get; set; }
        public List<int>? TurIds { get; set; } = new();
        public List<TurUpdateDto> Ture { get; set; } = new();
        public string OpfølgningNote { get; set; }
        public RejseplanStatusDto? RejseplanStatus { get; set; }
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
