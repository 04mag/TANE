using System.ComponentModel.DataAnnotations;
using TANE.Application.Dtos.TurDagRejseplan;
using TANE.Domain.Entities;

namespace TANE.Application.Dtos
{
	public class RejseplanCreateDto
    {
        public int Id { get; set; } = 0;
        public int? KundeId { get; set; } = 0;
        public string? Titel { get; set; } = string.Empty;
        public string? Beskrivelse { get; set; } = string.Empty;
		public int? AntalVoksne { get; set; } = 0;
        public int? AntalBørn { get; set; } = 0;
		public string? Lufthavn { get; set; } = string.Empty;
		public double? FlyPris { get; set; } = 0;
        public int? AntalDage { get; set; } = 0;
        public double? TotalPris { get; set; }
        public List<TurCreateDto>? Ture { get; set; } 
		public DateTime? AfrejseTidspunkt { get; set; } = DateTime.Now;
        public string? OpfølgningNote { get; set; } = string.Empty;
        public RejseplanStatusDto? RejseplanStatus { get; set; }

    }
}

