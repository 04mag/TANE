using System.ComponentModel.DataAnnotations;
using TANE.Domain.Entities;

namespace TANE.Application.Dtos
{
	public class RejseplanCreateDto
	{
		public int? KundeId { get; set; }
		public int? AntalVoksne { get; set; }
		public string? Titel { get; set; }
		public string? Beskrivelse { get; set; }
		public int? AntalBørn { get; set; }
		public string? Lufthavn { get; set; }
		public double? FlyPris { get; set; }
		public int? AntalDage { get; set; }
		public DateTime? AfrejseTidspunkt { get; set; }
		public string? OpfølgningNote { get; set; }	
	}
}

