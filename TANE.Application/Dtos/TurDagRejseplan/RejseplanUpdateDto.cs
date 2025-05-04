using System.ComponentModel.DataAnnotations;

namespace TANE.Application.Dtos
{
    public class RejseplanUpdateDto
    {
      
        public int KundeId { get; set; }
        public int AntalVoksne { get; set; }
        public int AntalBørn { get; set; }
        public string Lufthavn { get; set; }
        public double FlyPris { get; set; }
        public int AntalDage { get; set; }
        public DateTime AfrejseTidspunkt { get; set; }
       // public List<TurUpdateDto> Ture { get; set; } = new();
        public bool TilbudSendt { get; set; }
        public bool Opfølgning { get; set; }
        public string OpfølgningNote { get; set; }
        public bool TilbudAccepteret { get; set; }
        public bool RejseBooket { get; set; }
        public bool Anulleret { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }  // **Til optimistic concurrency**
    }
}
