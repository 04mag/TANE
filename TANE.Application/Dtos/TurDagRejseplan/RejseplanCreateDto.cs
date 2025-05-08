using System.ComponentModel.DataAnnotations;
using TANE.Application.Dtos.TurDagRejseplan;
using TANE.Domain.Entities;

namespace TANE.Application.Dtos
{
	public class RejseplanCreateDto
    {
        public int? KundeId { get; set; } = 0;
		public int? AntalVoksne { get; set; } = 0;
        public string? Titel { get; set; } = string.Empty;
        public string? Beskrivelse { get; set; } = string.Empty;
        public int? AntalBørn { get; set; } = 0;
		public string? Lufthavn { get; set; } = string.Empty;
		public double? FlyPris { get; set; } = 0;
        public List<int> TurIds { get; set; } = new();
        public List<TurReadDto> Ture { get; set; } = new();
        public int? AntalDage { get; set; } = 0;
		public DateTime? AfrejseTidspunkt { get; set; } = DateTime.Now;
        public string? OpfølgningNote { get; set; } = string.Empty;
        public RejseplanStatusDto? RejseplanStatus { get; set; }

    }
}

